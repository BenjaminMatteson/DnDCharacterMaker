using System;

namespace DnDCharacterMaker.Models
{
    public interface DnD5EApiResourceBase
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }

        public interface DnD5EApiResourceBase()
    }
}
