using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProdApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

            if (Helper._elementList.Count() > 0) Refresh();

            Editor.OnSaved += Editor_OnSaved;
        }

        private void Editor_OnSaved(object sender, RoutedEventArgs e)
        {
            foreach(var element in ElementList.Items.OfType<NoteButton>())
            {
                element.Update();
            }
        }

        public void Refresh()
        {
            ElementList.Items.Clear();

            foreach (var e in Helper._elementList)
            {
                var element = new NoteButton();
                element.RelatedElement = e;
                ElementList.Items.Add(element);
            }
        }

        

        private void ElementList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Editor.Visibility = Visibility.Visible;

            var selectedElement = (NoteButton)ElementList.SelectedItem;
            if (selectedElement == null) return;
            var selectedObject = selectedElement.RelatedElement;

            Editor.Save();

            if(selectedObject is Note)
                Editor.SetEditedObject((Note)selectedObject);
            else if(selectedObject is ToDo)
                Editor.SetEditedObject((ToDo)selectedObject);
        }

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            var newNote = new Note
            {
                Name = "Untitled",
                Date = DateTime.Now,
                Content = ""
            };

            Helper._elementList.Add(newNote);

            Refresh();
        }

        private void AddTodoButton_Click(object sender, RoutedEventArgs e)
        {
            var newToDo = new ToDo
            {
                Name = "Untitled",
                Date = DateTime.Now,
            };

            Helper._elementList.Add(newToDo);

            Refresh();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = ElementList.SelectedIndex;

            var selectedElement = (NoteButton)ElementList.SelectedItem;
            if (selectedElement == null) return;
            var selectedObject = selectedElement.RelatedElement;

            Helper._elementList.Remove(selectedObject);
            Refresh();



            if (ElementList.Items.Count == 0) Editor.Visibility = Visibility.Collapsed;
            else ElementList.SelectedIndex = selectedIndex - 1;
        }

        private void DoneButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedElement = (NoteButton)ElementList.SelectedItem;
            if (selectedElement == null) return;
            var selectedObject = selectedElement.RelatedElement;

            if (!(selectedObject is ToDo)) return;

            var selectedTodo = selectedObject as ToDo;

            var done = selectedTodo.Tasks.Where(t => t.IsDone).Count();
            var all = selectedTodo.Tasks.Count();


            //Tu wstawcie funckej do czekowania

            Helper.Done = done;
            Helper.toDo = all;

            if (Helper.Done > Helper.toDo)
            {
                var msg = new MessageDialog("To do can not be more than done!!");
                msg.ShowAsync();

                return;
            }

            this.Frame.Navigate(typeof(PointsPage));


            //DeleteButton_Click(sender, e);     
        }

        private void ScoreButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ScoresPage));
        }
    }
}
