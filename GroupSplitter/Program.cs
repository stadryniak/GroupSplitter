using System;
using System.Collections.Generic;
using System.IO;

namespace GroupSplitter
{
    class Program
    {
        static void Main()
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

            if (!ui.PathRead(out var path))
            {
                Console.WriteLine("Path input rejected.");
                return;
            }

            if (!ui.GroupSizeRead(out var groupSize))
            {
                Console.WriteLine("Invalid group size");
            }


            List<string> fileList = new List<string>(Directory.GetFiles(path));
            DataLoader dataLoader = new DataLoader(fileList);
            dataLoader.LoadMembers();

            var splitter = new GroupSplitter {GroupCount = groupsCount, GroupSize = groupSize};
            splitter.SplitIntoGroups(dataLoader.Members);
        }
    }
}
