using System;

namespace GroupSplitter
{
    class CLiUi
    {
        internal bool PrintHelloMessage()
        {
            Console.WriteLine("USAGE");
            Console.WriteLine("Put all user files in one folder.");
            Console.WriteLine("Is it done? [y/n]");
            var key = Console.ReadLine();
            switch (key)
            {
                case "y":
                case "Y":
                    return true;
                default:
                    return false;
            }
        }

        internal bool GroupCountRead(out int groupsCount)
        {
            Console.WriteLine("How many output groups?");
            var res = int.TryParse( Console.ReadLine(), out groupsCount);
            return res && groupsCount > 0;
        }
    }
}
