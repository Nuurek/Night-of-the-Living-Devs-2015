using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class NoteButton : UserControl
    {
        private Element _relatedElement;

        public Element RelatedElement
        {
            get { return _relatedElement; }
            set
            {
                _relatedElement = value;
                Title = _relatedElement.Name;
                Date = _relatedElement.Date;
                if(_relatedElement is Note) Type = NoteType.Note;
                else if(_relatedElement is ToDo) Type = NoteType.TodoList;
                else Type = NoteType.Other;
            }
        }

        public void Update()
        {
            Title = _relatedElement.Name;
            Date = _relatedElement.Date;
            if (_relatedElement is Note) Type = NoteType.Note;
            else if (_relatedElement is ToDo) Type = NoteType.TodoList;
            else Type = NoteType.Other;
        }

        public enum NoteType
        {
            Other,
            Note,
            TodoList
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(NoteButton), PropertyMetadata.Create("Untitled", OnTitleChanged ));
        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(DateTime), typeof(NoteButton), PropertyMetadata.Create("1970-01-01", OnDateChanged));
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(SolidColorBrush), typeof(NoteButton), PropertyMetadata.Create(new SolidColorBrush(Windows.UI.Color.FromArgb(0,0,0,0)), OnColorChanged));
        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register("Type", typeof(NoteType), typeof(NoteButton), PropertyMetadata.Create(NoteType.Other, OnTypeChanged));
        
        private static void OnTitleChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var obj = dependencyObject as NoteButton;
            if (obj == null) return;

            obj.TitleBlock.Text = obj.Title;
        }

        private static void OnDateChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var obj = dependencyObject as NoteButton;
            if (obj == null) return;

            obj.DateBlock.Text = obj.Date.ToString("u");
        }

        private static void OnColorChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var obj = dependencyObject as NoteButton;
            if (obj == null) return;

            obj.ColorRect.Fill = obj.Color;
        }

        private static void OnTypeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var obj = dependencyObject as NoteButton;
            if (obj == null) return;

            switch (obj.Type)
            {
                case NoteType.Other:
                    obj.IconButton.Icon = new SymbolIcon(Symbol.Help);
                    break;
                case NoteType.Note:
                    obj.IconButton.Icon = new SymbolIcon(Symbol.AlignCenter);
                    break;
                case NoteType.TodoList:
                    obj.IconButton.Icon = new SymbolIcon(Symbol.Bullets);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public DateTime Date
        {
            get { return (DateTime) GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public SolidColorBrush Color
        {
            get { return (SolidColorBrush) GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public NoteType Type
        {
            get { return (NoteType) GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public NoteButton()
        {
            this.InitializeComponent();
        }
    }
}
