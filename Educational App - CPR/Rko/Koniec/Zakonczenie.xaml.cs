using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Rko.Koniec
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Zakonczenie : Page
	{
		public string TextForReading => InfoPanel.Children.OfType<TextBlock>().Select(t => t.Text).Aggregate((a, b) => a + " " + b);
		public Zakonczenie()
		{
			this.InitializeComponent();
			KontrolaNadSwiatem.Text = TextForReading;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			CoreApplication.Exit();
		}
		private void KontrolaNadSwiatem_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			KontrolaNadSwiatem.SkipPageType = typeof(Zakonczenie);
			KontrolaNadSwiatem.ParentFrame = this.Frame;
		}
	}
}
