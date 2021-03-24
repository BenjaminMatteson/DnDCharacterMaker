using DnDCharacterMaker.DTOs.Json;
using DnDCharacterMaker.Enumerations;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace DnDCharacterMaker.Repositories
{
    public class DnDApiRepository
    {
        private const string endPath = "http://dnd5eapi.co/api";

        public async Task<List<PlayerClassRoute>> LoadClassesAsync()
        {
            var httpRequestResponse = new HttpRequestResponse();
            var repo = new DnDApiRepository();

            var classList = new List<PlayerClassRoute>();
            foreach (var playerClassValue in PlayerClassRoute.Contents)
            {
                var _class = repo.GetPlayerClassAsync(playerClassValue);
                Debug.Print(_class.name);
            }
            return classList;
        }

        private PlayerClassJson GetPlayerClassAsync(PlayerClassRoute playerClassRoute)
        {
            var characterClass = new PlayerClassJson();

            using (var response = (HttpWebResponse)PrepareGetRequest(playerClassRoute).GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        characterClass = JsonConvert.DeserializeObject<PlayerClassJson>(sr.ReadToEnd());
                    }
                }
            }
            return characterClass;
        }

        private HttpWebRequest PrepareGetRequest(PlayerClassRoute playerClassRoute)
        {
            var url = endPath + "/classes/" + playerClassRoute.Value;
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.UserAgent = url;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None;

            return request;
        }
    }
}