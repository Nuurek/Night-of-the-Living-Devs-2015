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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProdApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PointsPage : Page
    {
        public PointsPage()
        {
            this.InitializeComponent();
            SetTextBlocks();
            EstimateProgress();
        }

        private void SetTextBlocks()
        {
            //int CountDoneTasks = Helper.GetDoneTasks();
            int CountDoneTasks = 11;
            ToDo.Text = Helper.Done.ToString();
            //int CountAllTasks = Helper.GetAllTasks();
            int CountAllTasks = 12;
            Done.Text = Helper.toDo.ToString();

           
        }
        private void EstimateProgress()
        {

           float progress = Helper.Done / Helper.toDo;
            points.Text = ((int)((69+ (0.3/69)) * progress)).ToString();
            if (progress>0 && progress<0.4)
            {
                albumik.take(0);
            }
            else if (progress<0.4)
            {
                albumik.take(1);
            }
            else if (progress<0.65)
            {
                albumik.take(2);
            }
            else if(progress<0.77)
            {
                albumik.take(3);
            }
            else if(progress<0.85)
            {
                albumik.take(4);
            }
            else
            {
                albumik.take(5);
            }


            Green.Height = progress * Red.Height;
        }
    }
}
