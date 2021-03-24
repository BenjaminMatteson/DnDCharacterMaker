using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterMaker.DTOs.Json
{
    public class ProficiencyJson
    {
        public string _id { get; set; }
        public int index { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public IList<PlayerClassJson> classes { get; set; }
        public IList<object> races { get; set; }
        public string url { get; set; }
    }
}
