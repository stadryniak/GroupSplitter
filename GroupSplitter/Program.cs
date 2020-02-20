using System;
using System.Collections.Generic;

namespace GroupSplitter
{
    class Program
    {
        static void Main()
        {
         //   int outGroupsCount = 0;
            CLiUI ui = new CLiUI();
            bool success = ui.PrintHelloMessage();
            if (!success)
            {
                Console.WriteLine("Bye bye");
                return;
            }

            success = ui.GroupCountRead(out int groupsCount);
            if (!success)
            {
                Console.WriteLine("Invalid groups number.");
                return;
            }

            Console.WriteLine(groupsCount);
            DataLoader dataLoader = new DataLoader(new List<string>(){"../dane/dane.txt"});
            dataLoader.LoadMembers();
        }
    }
}
