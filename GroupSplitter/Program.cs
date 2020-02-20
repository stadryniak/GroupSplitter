using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace GroupSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
         //   int outGroupsCount = 0;
            CLiUI cLiUi = new CLiUI();
            DataLoader dataLoader = new DataLoader(new List<string>(){"../dane/dane.txt"});
            dataLoader.LoadMembers();
        }
    }
}
