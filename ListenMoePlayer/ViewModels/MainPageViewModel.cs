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

namespace ListenMoePlayer.ViewModels {
	public class MainPageViewModel : ViewModelBase {

		private MusicStream _mediaPlayer;
		public MusicStream mediaPlayer { get { return _mediaPlayer; } set { Set(ref _mediaPlayer, value); } }

		public MainPageViewModel() {
			mediaPlayer = new MusicStream();

			Initialize();
		}

		private void Initialize() {

		}

		public void Play() {
			mediaPlayer.Play();
		}

		public void Pause() {
			mediaPlayer.Pause();
		}
	}
}
