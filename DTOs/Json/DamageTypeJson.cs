using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterMaker.DTOs.Json
{
    public class DamageTypeJosn
    {
        public string _id { get; set; }
        public int index { get; set; }
        public string name { get; set; }
        public IList<string> desc { get; set; }
        public string url { get; set; }
    }
}
