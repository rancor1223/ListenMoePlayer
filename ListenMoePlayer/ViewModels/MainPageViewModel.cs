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
using System.Collections.ObjectModel;

namespace ListenMoePlayer.ViewModels {
	public class MainPageViewModel : ViewModelBase {

		private MusicStream _musicStream;

		private MediaPlayer _mediaPlayer;
		public MediaPlayer mediaPlayer { get { return _mediaPlayer; } set { Set(ref _mediaPlayer, value); } }

		private ObservableCollection<string> _log;
		public ObservableCollection<string> log { get { return _log; } set { Set(ref _log, value); } }

		private bool _playing;
		public bool playing { get { return _playing; } set { Set(ref _playing, value); } }

		public MainPageViewModel() {
			_musicStream = new MusicStream();
			log = new ObservableCollection<string>();
			playing = false;

			Initialize();
		}

		private void Initialize() {
			mediaPlayer = _musicStream.Initialize();
			mediaPlayer.PlaybackSession.PlaybackStateChanged += MediaPlayer_PlaybackSession_PlaybackStateChanged;
		}

		public void Play() {
			mediaPlayer.Play();
		}

		public void Pause() {
			mediaPlayer.Pause();
		}

		private void RegisterForMediaPlayerEvents(MediaPlayer mediaPlayer) {
			// Player Events
			mediaPlayer.SourceChanged += MediaPlayer_SourceChanged;
			mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
			mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
			mediaPlayer.MediaFailed += MediaPlayer_MediaFailed;
			mediaPlayer.VolumeChanged += MediaPlayer_VolumeChanged;
			mediaPlayer.IsMutedChanged += MediaPlayer_IsMutedChanged;

			// PlaybackSession Events
			mediaPlayer.PlaybackSession.BufferingEnded += MediaPlayer_PlaybackSession_BufferingEnded;
			mediaPlayer.PlaybackSession.BufferingProgressChanged += MediaPlayer_PlaybackSession_BufferingProgressChanged;
			mediaPlayer.PlaybackSession.BufferingStarted += MediaPlayer_PlaybackSession_BufferingStarted;
			mediaPlayer.PlaybackSession.DownloadProgressChanged += MediaPlayer_PlaybackSession_DownloadProgressChanged;
			mediaPlayer.PlaybackSession.NaturalDurationChanged += MediaPlayer_PlaybackSession_NaturalDurationChanged;
			mediaPlayer.PlaybackSession.NaturalVideoSizeChanged += MediaPlayer_PlaybackSession_NaturalVideoSizeChanged;
			mediaPlayer.PlaybackSession.PlaybackRateChanged += MediaPlayer_PlaybackSession_PlaybackRateChanged;
			mediaPlayer.PlaybackSession.PlaybackStateChanged += MediaPlayer_PlaybackSession_PlaybackStateChanged;
			mediaPlayer.PlaybackSession.SeekCompleted += MediaPlayer_PlaybackSession_SeekCompleted;
		}

		private void MediaPlayer_SourceChanged(MediaPlayer sender, object args) {
			log.Add("mediaPlayer.SourceChanged");
		}
		private void MediaPlayer_MediaOpened(MediaPlayer sender, object args) {
			log.Add($"MediaPlayer_MediaOpened, Duration: {sender.PlaybackSession.NaturalDuration}");
		}
		private void MediaPlayer_MediaEnded(MediaPlayer sender, object args) {
			log.Add("MediaPlayer_MediaEnded");
		}
		private void MediaPlayer_MediaFailed(MediaPlayer sender, MediaPlayerFailedEventArgs args) {
			log.Add($"MediaPlayer_MediaFailed Error: {args.Error}, ErrorMessage: {args.ErrorMessage}, ExtendedErrorCode.Message: {args.ExtendedErrorCode.Message}");
		}
		private void MediaPlayer_VolumeChanged(MediaPlayer sender, object args) {
			log.Add($"MediaPlayer_VolumeChanged, Volume: {sender.Volume}");
		}
		private void MediaPlayer_IsMutedChanged(MediaPlayer sender, object args) {
			log.Add($"MediaPlayer_IsMutedChanged, IsMuted={sender.IsMuted}");
		}
		// PlaybackSession Events
		private void MediaPlayer_PlaybackSession_BufferingEnded(MediaPlaybackSession sender, object args) {
			log.Add("PlaybackSession_BufferingEnded");
		}
		private void MediaPlayer_PlaybackSession_BufferingProgressChanged(MediaPlaybackSession sender, object args) {
			log.Add($"PlaybackSession_BufferingProgressChanged, BufferingProgress: {sender.BufferingProgress}");
		}
		private void MediaPlayer_PlaybackSession_BufferingStarted(MediaPlaybackSession sender, object args) {
			log.Add("PlaybackSession_BufferingStarted");
		}
		private void MediaPlayer_PlaybackSession_DownloadProgressChanged(MediaPlaybackSession sender, object args) {
			log.Add($"PlaybackSession_DownloadProgressChanged, DownloadProgress: {sender.DownloadProgress}");
		}
		private void MediaPlayer_PlaybackSession_NaturalDurationChanged(MediaPlaybackSession sender, object args) {
			log.Add($"PlaybackSession_NaturalDurationChanged, NaturalDuration: {sender.NaturalDuration}");
		}
		private void MediaPlayer_PlaybackSession_NaturalVideoSizeChanged(MediaPlaybackSession sender, object args) {
			log.Add($"PlaybackSession_NaturalVideoSizeChanged,  NaturalVideoWidth: {sender.NaturalVideoWidth}, NaturalVideoHeight: {sender.NaturalVideoHeight}");
		}
		private void MediaPlayer_PlaybackSession_PlaybackRateChanged(MediaPlaybackSession sender, object args) {
			log.Add($"PlaybackSession_PlaybackRateChanged, PlaybackRate: {sender.PlaybackRate}");
		}
		private void MediaPlayer_PlaybackSession_PlaybackStateChanged(MediaPlaybackSession sender, object args) {
			log.Add($"PlaybackSession_PlaybackStateChanged, PlaybackState: {sender.PlaybackState}");
		}
		private void MediaPlayer_PlaybackSession_SeekCompleted(MediaPlaybackSession sender, object args) {
			log.Add($"PlaybackSession_SeekCompleted, Position: {sender.Position}");
		}
		/*
		private void MediaPlayer_PlaybackSession_PlaybackStateChanged(MediaPlaybackSession sender, object args) {
			switch (sender.PlaybackState){
				case MediaPlaybackState.Paused:
					playing = false;
					break;
				case MediaPlaybackState.Playing:
					playing = true;
					break;

				case MediaPlaybackState.Buffering:
					playing = false;
					break;
				case MediaPlaybackState.Opening:
					playing = false;
					break;
				case MediaPlaybackState.None:
					playing = false;
					break;
			}
		}
		*/
	}
}
