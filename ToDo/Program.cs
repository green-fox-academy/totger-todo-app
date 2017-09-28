using System;
using System.IO;
using System.Linq;

namespace ToDo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if (args.Contains("-l"))
            {
                ListTasks();
            }
            else
            {
                ListArguments();
            }
                
        }

        private static void ListTasks()
        {
            string[] list = File.ReadAllLines(@"../../assets/list.txt");
            if (list.Length == 0)
            {
                Console.WriteLine("No todos for today :)");
            }
            else
            {
				for (int i = 0; i < list.Length; i++)
				{
					Console.WriteLine("{0}. - {1}", i + 1, list[i]);
				}   
            }
        }

        private static void ListArguments()
        {
            string text = File.ReadAllText(@"../../assets/arguments.txt");
            Console.WriteLine(text);
        }
    }
}
