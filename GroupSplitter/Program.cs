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
                return;
            }

            if (!ui.GroupCountRead(out var groupsCount))
            {
                Console.WriteLine("Invalid groups number.");
                return;
            }

            if (!ui.GroupSizeRead(out var groupSize))
            {
                Console.WriteLine("Invalid group size");
            }

            if (!ui.PathRead(out var path))
            {
                Console.WriteLine("Path input rejected.");
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
            Console.WriteLine("Splitter finished successfully");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
