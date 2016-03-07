using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace ProdApp
{
	public enum ElementColor { red, blue, cyan, green, yellow, orange, magenta, purple}

	public class Element
	{
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public ElementColor Color { get; set; }


		public Color GetColor()
		{
			switch (this.Color)
			{
				case ElementColor.red:
					return Colors.Red;
				case ElementColor.blue:
					return Colors.Blue;
				case ElementColor.cyan:
					return Colors.Cyan;
				case ElementColor.green:
					return Colors.Green;
				case ElementColor.yellow:
					return Colors.Yellow;
				case ElementColor.orange:
					return Colors.Orange;
				case ElementColor.magenta:
					return Colors.Magenta;
				case ElementColor.purple:
					return Colors.Purple;
				default:
					return Colors.White;
			}
		}

	}
}
