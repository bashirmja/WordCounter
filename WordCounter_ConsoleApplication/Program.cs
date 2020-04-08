using System;
using System.IO;
using System.Collections.Generic;
using WordCounter_ClassLibrary;

namespace WordCounter_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Example of file path= C:\test\Instructions.txt");
            Console.WriteLine("-------------------------------------------------");
            Console.Write("Enter a file path: ");

            string path = Console.ReadLine();

            Console.WriteLine();

            if (File.Exists(path))
            {
                WordCounter w = new WordCounter();
                Dictionary<string, int> resultDictionary = w.CountInputFile(path);

                foreach (var d in resultDictionary)
                {
                    Console.WriteLine( d.Value.ToString().PadLeft(3) + ": " + d.Key);
                }
            }
            else
            {
                Console.WriteLine("File is not exist");

            }

            Console.ReadKey();
        }
    }
}
