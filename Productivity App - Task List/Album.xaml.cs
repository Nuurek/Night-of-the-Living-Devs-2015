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

namespace ProdApp
{
    public sealed partial class Album : UserControl
    {
        List<Image> ImageAlbum = new List<Image>();
        public Album()
        {
            this.InitializeComponent();
            Image myImage = new Image();

            for (int i = 0; i < 6; i++)
            {
                string path = "ms-appx:///Assets/man" + i.ToString() + ".png";
                BitmapImage bitmapImage = new BitmapImage();
                Uri uri = new Uri(path);
                bitmapImage.UriSource = uri;
                myImage.Source = bitmapImage;
                ImageAlbum.Add(myImage);
            }
           
        }


        public void take(int number)
        {
            mainGrid.Children.Add(ImageAlbum[number]);
        }
    }
}
