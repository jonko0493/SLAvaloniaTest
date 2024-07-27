using Avalonia.Controls;
using NAudio.Wave;

namespace SLAvaloniaTest
{
    public class SoundPlayerControl : StackPanel
    {
#if WINDOWS
        private WaveOut _player;
#else
        private ALWavePlayer _player;
#endif
        public IWaveProvider WaveProvider { get; set; }
        public PlaybackState PlaybackState => _player.PlaybackState;

        public void Initialize(IWaveProvider waveProvider)
        {
            WaveProvider = waveProvider;

#if WINDOWS
            _player = new() { DeviceNumber = -1 };
#else
            _player = new(new(), 8192);
#endif
            _player.Init(WaveProvider);
        }

        public void Pause()
        {
            _player.Pause();
        }

        public void Play()
        {
            _player.Play();
        }

        public void Stop()
        {
#if WINDOWS
            _player.Stop();
#else
            // AL has a static player, so if we stop it we'll throw errors
            _player.Pause();
#endif
        }
    }
}
