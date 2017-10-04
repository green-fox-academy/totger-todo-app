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
            string textPath = @"../../assets/list.txt";
            if (args.Contains("-l"))
            {
                ListTasks();
            }
            else if (args.Contains("-a"))
            {
                try
                {
					using (StreamWriter writer = File.AppendText(textPath))
					{
						writer.WriteLine("[ ] " + args[1]);
					}    
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Unable to add: no task provided");    
                }

            }
            else if (args.Contains("-r"))
            {
                try
                {
                    var file = new List<string>(File.ReadAllLines(textPath));
                    file.RemoveAt(Convert.ToInt32(args[1]) - 1);
                    File.WriteAllLines(textPath, file);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Unable to remove: no task provided");
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
            else if (args.Contains("-c"))
            {
                try
                {
                    var file = new List<string>(File.ReadAllLines(textPath));
                    string temp = file[Convert.ToInt32(args[1]) - 1].Substring(4);
                    file.RemoveAt(Convert.ToInt32(args[1]) - 1);
                    file.Insert(Convert.ToInt32(args[1]) - 1, "[X] " + temp);
                    File.WriteAllLines(textPath, file);    
                }
				catch (IndexOutOfRangeException)
				{
					Console.WriteLine("Unable to check: no task provided");
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Unable to check: index is out of bound");
				}
				catch (FormatException)
				{
					Console.WriteLine("Unable to check: index is not a number");
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
