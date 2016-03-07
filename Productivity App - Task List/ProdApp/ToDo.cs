using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdApp
{
	public class ToDo : Element
	{
		public List<CustomTask> Tasks { get; set; }

	    public int Priority;

	    public ToDo()
	    {
	        Tasks = new List<CustomTask>();
	    }
	}
}
