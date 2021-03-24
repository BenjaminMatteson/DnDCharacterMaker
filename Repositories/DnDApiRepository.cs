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
    public static class DnDApiRepository
    {
        private const string endPath = "http://dnd5eapi.co/api";

        public static async Task<List<PlayerClassRoute>> LoadClassesAsync()
        {
            var httpRequestResponse = new HttpRequestResponse();

            var classList = new List<PlayerClassRoute>();
            foreach (var playerClassValue in PlayerClassRoute.Contents)
            {
                var _class = GetPlayerClassAsync(playerClassValue);
                Debug.Print(_class.name);
            }
            return classList;
        }

        private static PlayerClassJson GetPlayerClassAsync(PlayerClassRoute playerClassRoute)
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

        private static HttpWebRequest PrepareGetRequest(PlayerClassRoute playerClassRoute)
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