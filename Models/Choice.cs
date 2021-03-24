using System;
using System.Collections.Generic;

namespace DnDCharacterMaker.Models
{
	public class Choice
	{
		public int choose { get; set; }
		public string type { get; set; }
		public List<APIReference> from {get; set;}
	
		public Choice()
		{
	
		}
	}
}
