using System;
using System.Collections.Generic;

namespace DnDCharacterMaker.Models
{
	public class AbilityScore
	{
		public string index { get; set; }
		public string name { get; set; }
		public string full_name { get; set; }
		public List<string> APIReference { get; set; }
		public string url { get; set; }

		public AbilityScore()
		{

		}
	}
}
