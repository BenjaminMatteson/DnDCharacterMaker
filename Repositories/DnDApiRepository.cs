using DnDCharacterMaker.DTOs.Json;
using DnDCharacterMaker.Enumerations;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace DnDCharacterMaker.Repositories
{
    public class DnDApiRepository
    {
        private const string endPath = "http://dnd5eapi.co/api";

        //public PlayerClassJson GetPlayerClass(PlayerClassRoute playerClassRoute, string[] fields)
        //{
        //
        //}

        public PlayerClassJson GetPlayerClass(PlayerClassRoute playerClassRoute)
        {

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

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