using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Rko.Controls
{
    public sealed partial class PageController : UserControl
    {
        public bool IsPaused = false;
        private readonly SpeechSynthesizer _synth = new SpeechSynthesizer();

        public PageController()
        {
            this.InitializeComponent();

        }

        public event RoutedEventHandler OnPause;
        public event RoutedEventHandler OnPlay;
        public event RoutedEventHandler OnBack;
        public event RoutedEventHandler OnSkip;

        private Type _backPageType = null;
        private Type _skipPageType = null;

        public Frame ParentFrame;

        public Type BackPageType
        {
            get { return _backPageType; }
            set
            {
                _backPageType = value;
                BackButton.Visibility = _backPageType == null ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public Type SkipPageType
        {
            get { return _skipPageType; }
            set
            {
                _skipPageType = value;
                SkipButton.Visibility = _skipPageType == null ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private string _text;
        
        public string Text
        {
            get { return _text; }
            set
            {
                SetText(value);
            }
        }

        public async void SetText(string text)
        {
            _text = text;
            SpeechSynthesisStream ttsStream = await _synth.SynthesizeTextToStreamAsync(_text);
            audioPlayer.SetSource(ttsStream, "");
            audioPlayer.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsPaused)
            {
                PauseButton.Icon = new SymbolIcon(Symbol.Play);
                PauseButton.Label = "Odtwórz";
                OnPause?.Invoke(this, e);

                audioPlayer.Pause();
            }
            else
            {
                PauseButton.Icon = new SymbolIcon(Symbol.Pause);
                PauseButton.Label = "Pauza";
                OnPlay?.Invoke(this, e);

                audioPlayer.Play();
            }

            IsPaused = !IsPaused;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            OnBack?.Invoke(this, e);
            audioPlayer.Stop();
            ParentFrame?.Navigate(BackPageType);
        }

        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            OnSkip?.Invoke(this, e);
            audioPlayer.Stop();
            ParentFrame?.Navigate(SkipPageType);
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            audioPlayer.Stop();
        }
    }
}
