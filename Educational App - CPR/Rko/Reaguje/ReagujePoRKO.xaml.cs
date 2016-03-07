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
using Rko.Koniec;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Rko.Reaguje
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ReagujePoRKO : Page
	{
		public string TextForReading => InfoPanel.Children.OfType<TextBlock>().Select(t => t.Text).Aggregate((a, b) => a + " " + b);
		public ReagujePoRKO()
		{
			this.InitializeComponent();
			KontrolaNadSwiatem.Text = TextForReading;
		}
		private void KontrolaNadSwiatem_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			KontrolaNadSwiatem.SkipPageType = typeof(Zakonczenie);
			KontrolaNadSwiatem.ParentFrame = this.Frame;
		}
	}
}
