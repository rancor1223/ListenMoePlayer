using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ListenMoePlayer.Models {
	class Authenticate {
		private bool success { get; set; }
		public string token { get; set; }

		public static async Task<string> GetToken(string username, string password) {
			try {
				var http = new HttpClient();

				var values = new Dictionary<string, string>
				{
					{ "username", username },
					{ "password", password }
				};

				var content = new FormUrlEncodedContent(values);
				var response = await http.PostAsync("https://listen.moe/api/authenticate", content);
				var result = await response.Content.ReadAsStringAsync();
				var data = JsonConvert.DeserializeObject<Authenticate>(result);
				return data.token;
			}
			catch (Exception) {
				throw new Exception("No connection");
			}
		}
	}
}
