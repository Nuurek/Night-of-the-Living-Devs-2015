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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Helper.Done = float.Parse(textBox.Text);
                Helper.toDo = float.Parse(textBox1.Text);
            }
            catch
            {
                var msg = new MessageDialog("Wrong input!!!");
                msg.ShowAsync();
                return;
            }
            if (Helper.Done > Helper.toDo)
            {
                var msg = new MessageDialog("To do can not be more than done!!");
                msg.ShowAsync();

                return;
            }
                
            this.Frame.Navigate(typeof(PointsPage));
        }
    }
}
