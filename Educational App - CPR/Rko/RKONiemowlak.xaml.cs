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
using Rko.RkoProcess;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Rko
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RKONiemowlak : Page
    {
        public RKONiemowlak()
        {
            this.InitializeComponent();
        }

        public string TextForReading => InfoPanel.Children.OfType<TextBlock>().Select(t => t.Text).Aggregate((a, b) => a + " " + b);

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigator.Text = TextForReading;
            Navigator.ParentFrame = Frame;
            Navigator.SkipPageType = typeof(CzyOddechy);
            Navigator.BackPageType = typeof(RKOOgolnie);
        }
    }
}
