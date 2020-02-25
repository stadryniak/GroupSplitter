using System;
using System.Collections.Generic;
using System.IO;

namespace GroupSplitter
{
    internal class Program
    {
        private static void Main()
        {
            var ui = new CLiUi();
            if (!ui.PrintHelloMessage())
            {
                Console.WriteLine("Bye bye");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            if (!ui.GroupCountRead(out var groupsCount))
            {
                Console.WriteLine("Invalid groups number.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            if (!ui.GroupSizeRead(out var groupSize))
            {
                Console.WriteLine("Invalid group size");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }

            if (!ui.PathRead(out var path))
            {
                Console.WriteLine("Path input rejected.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            List<string> fileList = new List<string>(Directory.GetFiles(path));
            DataLoader dataLoader = new DataLoader(fileList);
            dataLoader.LoadMembers();

            var splitter = new GroupSplitter
            {
                GroupCount = groupsCount, GroupSize = groupSize, Members = dataLoader.Members
            };
            splitter.SplitIntoGroups();

            //create output file and write to it
            using var writer = new StreamWriter(Path.Combine(path,"..", "OUTPUT.txt"));
            splitter.WriteGroupsToFile(writer);
            Console.WriteLine("\nSplitter finished successfully");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
