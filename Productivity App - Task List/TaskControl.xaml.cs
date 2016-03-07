using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class TaskControl : UserControl
    {
        public static readonly DependencyProperty IsDoneProperty = DependencyProperty.Register("IsDone", typeof(bool), typeof(TaskControl), PropertyMetadata.Create(false, OnIsDoneChanged));
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TaskControl), PropertyMetadata.Create("", OnTextChanged));

        private CustomTask _relatedTask;

        public CustomTask RelatedTask
        {
            get { return _relatedTask; }
            set
            {
                _relatedTask = value;
                Text = _relatedTask.Name;
                IsDone = _relatedTask.IsDone;
            }
        }

        private static void OnIsDoneChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var obj = dependencyObject as TaskControl;
            if (obj == null) return;

            obj.IsDoneBox.IsChecked = obj.IsDone;
        }

        private static void OnTextChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var obj = dependencyObject as TaskControl;
            if (obj == null) return;

            obj.ContentBox.Text = obj.Text;
        }

        public bool IsDone
        {
            get { return (bool) GetValue(IsDoneProperty); }
            set { SetValue(IsDoneProperty, value); }
        }

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public event RoutedEventHandler IsDoneChecked;
        public event RoutedEventHandler ContentBoxLostFocus;
        public event RoutedEventHandler DeleteClicked;

        public TaskControl()
        {
            this.InitializeComponent();
            IsDoneBox.Checked += IsDoneBoxOnChecked;
            ContentBox.LostFocus += ContentBoxOnLostFocus;
            DeleteButton.Click += DeleteButtonOnClick;
        }

        private void DeleteButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            DeleteClicked?.Invoke(sender, routedEventArgs);;
        }

        private void ContentBoxOnLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            ContentBoxLostFocus?.Invoke(sender, routedEventArgs);
        }

        private void IsDoneBoxOnChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            IsDone = IsDoneBox.IsChecked.Value;
            IsDoneChecked?.Invoke(sender, routedEventArgs);
        }

        private void ContentBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text = ContentBox.Text;
        }
    }
}
