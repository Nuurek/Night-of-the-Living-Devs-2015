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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Rko.PersonTypeChoose
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PersonTypePage : Page
    {
        public Person person;
        public PersonTypePage()
        {
            this.InitializeComponent();
            //KontrolkaSeby.Text = something.Text;
            KontrolkaSeby.Text = "";
        }


        private void Child_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            person = Person.Child;
            Navigation();
        }

        private void Adult_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            person = Person.Adult;
            Navigation();
        }

        private void Infant_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            person = Person.Infant;
            Navigation();
        }
        private void Navigation()
        {
            MainPage.Helper = new PersonHelper(person);
            Frame.Navigate(typeof(SafetyPage));
        }

    }
}
