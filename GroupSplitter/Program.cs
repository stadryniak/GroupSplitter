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
            Member member = Member.CreateInstance("a", "b", new List<int>() { 1, 2, 3 });

            Console.WriteLine(member);
        }
    }
}
