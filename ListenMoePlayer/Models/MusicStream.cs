using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace ListenMoePlayer.Models {
	public class MusicStream {
		private MediaPlayer player { get; set; }

		public MusicStream() {
			player = new MediaPlayer();

			Initialize();
		}

		private void Initialize() {
			Uri manifestUri = new Uri("http://listen.moe/fallback");
			player.Source = MediaSource.CreateFromUri(manifestUri);
		}

		public void Play() {
			player.Play();
		}

		public void Pause() {
			player.Pause();
		}
	}
}
