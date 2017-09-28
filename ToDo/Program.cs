using System;
using System.IO;

namespace ToDo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            WriteArguments();
        }

        private static void WriteArguments()
        {
            string text = System.IO.File.ReadAllText(@"../../assets/arguments.txt");
            Console.WriteLine(text);
        }
    }
}
