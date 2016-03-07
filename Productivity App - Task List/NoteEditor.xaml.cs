using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ProdApp
{
    public sealed partial class NoteEditor : UserControl
    {
        private RichEditBox _editBox;
        private StackPanel _todoStack;

        public ToDo EditedToDo = null;
        public Note EditedNote = null;

        public enum EditorType
        {
            Note,
            Todo
        }

        public static readonly DependencyProperty EditorTypeProperty  = DependencyProperty.Register("EditorType", typeof(EditorType), typeof(NoteEditor), PropertyMetadata.Create(EditorType.Note, OnEditorTypeChanged));

        private static void OnEditorTypeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var obj = dependencyObject as NoteEditor;
            if (obj == null) return;

            switch (obj.Mode)
            {
                case EditorType.Note:
                    obj.SetNoteMode();
                    break;
                case EditorType.Todo:
                    obj.SetTodoMode();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public EditorType Mode
        {
            get { return (EditorType) GetValue(EditorTypeProperty); }
            set { SetValue(EditorTypeProperty, value); }
        }

        private void SetNoteMode()
        {
            EditorGrid.Children.Clear();

            TitleBox.Text = EditedNote.Name;
            NoteDate.Date = new DateTimeOffset(EditedNote.Date);

            var richEditBox = new RichEditBox();
            richEditBox.Margin = new Thickness(0,0,0,80);
            richEditBox.VerticalAlignment = VerticalAlignment.Stretch;
            EditorGrid.Children.Add(richEditBox);

            var saveButton = new AppBarButton
            {
                Icon = new SymbolIcon(Symbol.Save), Label = "Save"
            };
            saveButton.VerticalAlignment = VerticalAlignment.Bottom;
            saveButton.Margin = new Thickness(10);
            saveButton.Click += SaveButtonOnClick;
            EditorGrid.Children.Add(saveButton);


            _editBox = richEditBox;
        }

        private void SaveButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Save();
        }

        private void SetTodoMode()
        {
            EditorGrid.Children.Clear();

            TitleBox.Text = EditedToDo.Name;
            NoteDate.Date = new DateTimeOffset(EditedToDo.Date);

            var stackPanel = new StackPanel();
            EditorGrid.Children.Add(stackPanel);

            var addButton = new AppBarButton
            {
                Icon = new SymbolIcon(Symbol.Add), Name = "addButton", Label = "Add"
            };
            addButton.Click += AddButtonOnClick;

            foreach (var task in EditedToDo.Tasks)
            {
                var taskControl = new TaskControl
                {
                    Text = task.Name,
                    IsDone = task.IsDone,
                    RelatedTask = task
                };
                taskControl.IsDoneChecked += ToDoOnIsDoneChecked;
                taskControl.ContentBoxLostFocus += ToDoOnContentBoxLostFocus;
                taskControl.DeleteClicked += ToDoOnDeleteClicked;
                stackPanel.Children.Add(taskControl);
            }

            stackPanel.VerticalAlignment = VerticalAlignment.Center;
            stackPanel.Children.Add(addButton);

            _todoStack = stackPanel;
        }

        private void AddButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var toDo = new TaskControl();
            toDo.IsDoneChecked += ToDoOnIsDoneChecked;
            toDo.ContentBoxLostFocus += ToDoOnContentBoxLostFocus;
            toDo.DeleteClicked += ToDoOnDeleteClicked;
            _todoStack.Children.Insert(0, toDo);
        }

        private void ToDoOnDeleteClicked(object sender, RoutedEventArgs routedEventArgs)
        {
            _todoStack.Children.Remove((UIElement) sender);
            Save();
        }

        private void ToDoOnContentBoxLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            Save();
        }

        private void ToDoOnIsDoneChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            Save();
        }

        public void SetEditedObject(Note note)
        {
            EditedNote = note;
            Mode = EditorType.Note;
        }

        public void SetEditedObject(ToDo todo)
        {
            EditedToDo = todo;
            Mode = EditorType.Todo;
        }

        public void Save()
        {
            switch (Mode)
            {
                case EditorType.Note:
                    SaveNote();
                    break;
                case EditorType.Todo:
                    SaveToDo();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SaveNote()
        {
            string text = "";
            _editBox.Document.GetText(TextGetOptions.None, out text);
            EditedNote.Content = text;
            EditedNote.Name = TitleBox.Text;
            EditedNote.Date = NoteDate.Date.DateTime;
        }

        private void SaveToDo()
        {
            var tasks = _todoStack.Children.OfType<TaskControl>().Select(c => new CustomTask {Name = c.Text, IsDone = c.IsDone});
            EditedToDo.Tasks = tasks.ToList();
            EditedToDo.Name = TitleBox.Text;
            EditedToDo.Date = NoteDate.Date.DateTime;
        }

        public NoteEditor()
        {
            this.InitializeComponent();
        }
    }
}
