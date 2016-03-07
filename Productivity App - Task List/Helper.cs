using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdApp
{

	public static class Helper
	{
		public static List<ToDo> ToDoList { get; set; }

		public static int GetAllTasks()
		{
			int taskCounter = 0;

			foreach (ToDo lists in ToDoList)
			{
				foreach(CustomTask task in lists.Tasks)
				{
					taskCounter++;
				}
			}

			return taskCounter;

		}

		public static int GetDoneTasks()
		{
			int taskCounter = 0;

			foreach (ToDo lists in ToDoList)
			{
				foreach (CustomTask task in lists.Tasks)
				{
					if(task.IsDone)
						taskCounter++;
				}
			}

			return taskCounter;
		}

		public static void ExamplesInit()
		{
			ToDo school = new ToDo() { Name = "School", Date = DateTime.Now, Color = ElementColor.blue};

		}

        public static float toDo { get; set; }
        public static float Done { get; set; }
	}
}
