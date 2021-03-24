using System;

namespace DnDCharacterMaker.Models
{ 
	public class ClassAPIResource : DnD5EApiResourceBase
	{
		public string index { get; set; }
		public string name { get; set; }
		public string url { get; set; }
	
		public ClassAPIResource()
		{
	
		}
	}
}