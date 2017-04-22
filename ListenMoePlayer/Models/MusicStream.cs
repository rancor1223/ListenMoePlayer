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

		public MediaPlayer Initialize() {
			try {
				Uri manifestUri = new Uri("http://listen.moe/fallback");
				player.Source = MediaSource.CreateFromUri(manifestUri);
				return player;
			} catch {
				throw new Exception();
			}
		}


	}
}
