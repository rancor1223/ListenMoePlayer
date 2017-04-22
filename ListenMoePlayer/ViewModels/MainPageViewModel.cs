using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using ListenMoePlayer.Models;
using Windows.Media.Playback;
using Windows.Media.Core;
using System.Threading;

namespace ListenMoePlayer.ViewModels {
	public class MainPageViewModel : ViewModelBase {

		private MusicStream _musicStream;
		private AutoResetEvent _are;

		private MediaPlayer _mediaPlayer;
		public MediaPlayer mediaPlayer { get { return _mediaPlayer; } set { Set(ref _mediaPlayer, value); } }

		private bool _playing;
		public bool playing { get { return _playing; } set { Set(ref _playing, value); } }

		public MainPageViewModel() {
			_musicStream = new MusicStream();
			playing = false;
			_are = new AutoResetEvent(false);

			Initialize();
		}

		private void Initialize() {
			mediaPlayer = _musicStream.Initialize();
			mediaPlayer.PlaybackSession.PlaybackStateChanged += MediaPlayer_PlaybackSession_PlaybackStateChanged;
			mediaPlayer.PlaybackSession.BufferingEnded += MediaPlayer_PlaybackSession_BufferingEnded; 
		}

		public void Play() {
			mediaPlayer.Play();
			mediaPlayer.Pause();
			_are.WaitOne(5000);
			mediaPlayer.Play();
		}

		public void Pause() {
			mediaPlayer.Pause();
		}

		public void Favourite() {
			
		}

		private void MediaPlayer_PlaybackSession_PlaybackStateChanged(MediaPlaybackSession sender, object args) {
			switch (sender.PlaybackState){

				case MediaPlaybackState.Paused:
					playing = false;
					break;
				case MediaPlaybackState.Playing:
					playing = true;
					break;
			}
		}

		private void MediaPlayer_PlaybackSession_BufferingEnded(MediaPlaybackSession sender, object args) {
			_are.Set();
		}
	}
}
