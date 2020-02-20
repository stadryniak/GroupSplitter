using System;
using System.Collections.Generic;

namespace GroupSplitter
{
    class Program
    {
        static void Main()
        {
            //   int outGroupsCount = 0;
            var ui = new CLiUi();
            bool success = ui.PrintHelloMessage();
            if (!success)
            {
                Console.WriteLine("Bye bye");
                return;
            }

            success = ui.GroupCountRead(out var groupsCount);
            if (!success)
            {
                Console.WriteLine("Invalid groups number.");
                return;
            }

            Console.WriteLine(ui.PathRead(out var path));

            DataLoader dataLoader = new DataLoader(new List<string>() { "../dane/dane.txt" });
            dataLoader.LoadMembers();
        }
    }
}
