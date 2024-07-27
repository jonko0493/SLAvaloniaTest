using Avalonia.Controls;
using NAudio.Wave;

namespace SLAvaloniaTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SoundPlayerControl soundPlayer = new();
            soundPlayer.Initialize(new WaveFileReader(@"C:\Users\User\Music\temp.wav"));

            Button button = new() { Content = "Play!" };
            button.Click += (sender, args) =>
            {
                if (button.Content.Equals("Play!"))
                {
                    button.Content = "Pause";
                    soundPlayer.Play();
                }
                else
                {
                    button.Content = "Play!";
                    soundPlayer.Pause();
                }
            };

            Content = new StackPanel
            {
                Children =
                {
                    button,
                }
            };
        }
    }
}