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
using Rko.Loop;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Rko.RkoProcess
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RkoPressures : Page
    {
        public RkoPressures()
        {
            this.InitializeComponent();

            PulseBeater.ThirtyCounts += PulseBeater_ThirtyCounts;
        }

        private void PulseBeater_ThirtyCounts(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CzyPrzytomny));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PulseBeater.Start();
            Navigator.ParentFrame = Frame;
            Navigator.SkipPageType = typeof(CzyPrzytomny);
        }
    }
}
