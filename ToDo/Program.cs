using System;
using System.Collections.Generic;
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
            else if (args.Contains("-a"))
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("Unable to add: no task provided");
                }
                else
                {
                    using (StreamWriter writer = File.AppendText(@"../../assets/list.txt"))
                    {
                        writer.WriteLine(args[1]);
                    }
                }
            }
            else if (args.Contains("-r"))
            {
                try
                {
                    var file = new List<string>(File.ReadAllLines(@"../../assets/list.txt"));
                    file.RemoveAt(Convert.ToInt32(args[1]) - 1);
                    File.WriteAllLines(@"../../assets/list.txt", file);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Unable to add: no task provided");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Unable to remove: index is out of bound");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to remove: index is not a number");
                }
            }
            else if (args.Length > 0 && !args.Contains("-l") || !args.Contains("-r") ||
                    !args.Contains("-c") ||!args.Contains("-a"))
            {
                Console.WriteLine("Unsupported argument");
                ListArguments();
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
