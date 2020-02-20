using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace GroupSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var fileReader = new StreamReader(Path.Combine("..", "dane1", "dane.txt"));
            string line;
            while ((line = fileReader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            fileReader.Close();
            var files = Directory.GetFiles(".").ToList();
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine("");
            files = files.OrderBy(x => RandomNumberGenerator.GetInt32(100)).ToList();
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
