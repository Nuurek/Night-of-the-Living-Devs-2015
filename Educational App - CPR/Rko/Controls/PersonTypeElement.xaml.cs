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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Rko.Controls
{
    public sealed partial class PersonTypeElement : UserControl
    {
        public enum Type
        {
            Other,
            Adult,
            Child,
            Infant
        }

        public static readonly DependencyProperty PersonTypeProperty = DependencyProperty.Register("PersonType", typeof(Type), typeof(PersonTypeElement), PropertyMetadata.Create(Type.Other, OnPersonTypeChanged));
        public new static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(string), typeof(PersonTypeElement), PropertyMetadata.Create("Unknown", OnContentChanged));

        private static void OnContentChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var obj = dependencyObject as PersonTypeElement;
            if (obj == null) return;

            obj.ContentBox.Text = obj.Content;
        }

        private static void OnPersonTypeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var obj = dependencyObject as PersonTypeElement;
            if (obj == null) return;

            switch (obj.PersonType)
            {
                case Type.Adult:
                    obj.IconImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/adultIcon.png"));
                    obj.Content = "Dorosły";
                    break;
                case Type.Child:
                    obj.IconImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/childIcon.png"));
                    obj.Content = "Dziecko";
                    break;
                case Type.Infant:
                    obj.IconImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/infantIcon.png"));
                    obj.Content = "Niemowle";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Type PersonType
        {
            get { return (Type) GetValue(PersonTypeProperty); }
            set { SetValue(PersonTypeProperty, value); }
        }

        public new string Content
        {
            get { return (string) GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public PersonTypeElement()
        {
            this.InitializeComponent();

            PersonType = Type.Adult;
        }
    }
}
