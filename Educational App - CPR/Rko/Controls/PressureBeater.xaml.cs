using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Rko.Controls
{
    public sealed partial class PressureBeater : UserControl
    {
        public double FrequencyHz = 1.6;

        private Timer _pulseTimer;

        private int _counter = 0;

        public void Pulse()
        {
            if (_counter == 30)
            {
                Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    ThirtyCounts?.Invoke(this, null);
                });
                
                Stop();
                return;
            }

            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                PulseBoard.Begin();
                BeepSound.Play();
            });
            _counter++;
        }

        public event RoutedEventHandler ThirtyCounts;

        public void Start()
        {
            _pulseTimer = new Timer((state) => Pulse(), null, TimeSpan.Zero, new TimeSpan(0, 0, 0, 0, (int)(1/FrequencyHz*1000)));
            _counter = 0;
        }

        public void Stop()
        {
            _pulseTimer = null;
        }

        public PressureBeater()
        {
            this.InitializeComponent();
        }
    }
}
