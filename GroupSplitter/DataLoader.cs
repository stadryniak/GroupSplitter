﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GroupSplitter
{
    internal class DataLoader
    {
        public DataLoader(List<string> paths)
        {
            PathsList = paths;
            Members = new List<Member>();
        }

        private List<string> PathsList { get; set; }
        public List<Member> Members { get; set; }

        public void LoadMembers()
        {
            foreach (var path in PathsList)
            {
                ExtractDataFromFile(path);
            }
        }

        private void ExtractDataFromFile(string path)
        {
            string firstName;
            string lastName;
            List<int> groups;
            using (var fileReader = new StreamReader(path))
            {
                var line = fileReader.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("Error while reading file.");
                    fileReader.Close();
                    return;
                }

                // read lastName and firstName
                var matches = Regex.Matches(line, @"(\w+)", RegexOptions.IgnoreCase);
                if (matches.Count != 2)
                {
                    Console.WriteLine("More or less than first and last names provided.");
                    fileReader.Close();
                    return;
                }

                firstName = matches[0].Captures[0].ToString();
                lastName = matches[1].Captures[0].ToString();

                // read groups
                line = fileReader.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("Error while reading file. No groups.");
                    fileReader.Close();
                    return;
                }

                groups = new List<int>();
                matches = Regex.Matches(line, @"[0-9]+", RegexOptions.IgnoreCase);
                foreach (Group match in matches)
                {
                    bool isInt = int.TryParse(match.Captures[0].ToString(), out var res);
                    if (!isInt)
                    {
                        Console.WriteLine($"Error while parsing groups for {firstName} {lastName}");
                        fileReader.Close();
                        return;
                    }

                    groups.Add(res);
                }
            }

            // initialize new member and add to loaded data
            Members.Add(Member.CreateInstance(firstName, lastName, groups));
        }
    }
}
