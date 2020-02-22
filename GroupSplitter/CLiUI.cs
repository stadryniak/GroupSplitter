using System;
using System.IO;

namespace GroupSplitter
{
    class CLiUi
    {
        internal bool PrintHelloMessage()
        {

            Console.WriteLine("Put all user files in one folder.");
            Console.WriteLine("Is it done? [y/n]");
            var key = Console.ReadLine();
            return YesNoSelect(key);
        }

        internal bool GroupCountRead(out int groupsCount)
        {
            Console.WriteLine("\nHow many output groups?");
            var res = int.TryParse(Console.ReadLine(), out groupsCount);
            return res && groupsCount > 0;
        }

        internal bool PathRead(out string path)
        {
            path = Path.GetFullPath(".");
            Console.WriteLine($"\nCurrent path is: {path}");
            Console.WriteLine("Type folder name (or relative/absolute path)");
            path = Console.ReadLine();
            if (Path.IsPathFullyQualified(path))
            {
                path = Path.GetRelativePath(".", path);
            }
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Directory \"{Path.GetFullPath(path)}\" doesn't exist.");
                return false;
            }
            Console.WriteLine($"Absolute path of directory is: {Path.GetFullPath(path)}");
            Console.WriteLine("\nFile list:");
            foreach (var file in Directory.GetFiles(path))
            {
                Console.WriteLine(Path.GetFullPath(file));
            }
            Console.WriteLine("\nConfirm folder selection [Y/n]");
            var key = Console.ReadLine();
            return YesNoSelect(key);
        }

        private bool YesNoSelect(string key)
        {
            return key switch
            {
                "y" => true,
                "Y" => true,
                _ => false
            };
        }
    }
}
