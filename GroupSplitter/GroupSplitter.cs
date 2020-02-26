using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace GroupSplitter
{
    internal class GroupSplitter
    {
        public List<List<Member>> SplittedGroups { get; private set; }
        public List<Member> Members { get; set; }

        public int GroupSize { get; set; }

        private readonly Random _rand = new Random();
        private int _groupCount;

        public int GroupCount
        {
            get => _groupCount;
            set
            {
                _groupCount = value;
                if (SplittedGroups == null) InitializeGroupsMemList(value);
            }
        }

        public void WriteGroupsToFile(StreamWriter writer)
        {
            var i = 1;
            foreach (var group in SplittedGroups)
            {
                var j = 1;
                writer.WriteLine($"Group {i++}\nGroup size: {group.Count}");
                foreach (var member in group)
                {
                    writer.WriteLine(j++ + ". " + member);
                }
                writer.WriteLine("\n");
            }
        }

        private void InitializeGroupsMemList(int size)
        {
            SplittedGroups = new List<List<Member>>();
            for (var i = 0; i < size; i++)
            {
                SplittedGroups.Add(new List<Member>());
            }
        }

        private void ValidateCapacity()
        {
            if (_groupCount * GroupSize >= Members.Count) return;
            throw new IndexOutOfRangeException("More members than spots.");
        }

        public void SplitIntoGroups()
        {
            ValidateCapacity();
            List<Member> members = Members.OrderBy(x => _rand.Next()).ToList();
            var remainingMembers = new List<Member>(members);
            var currentMembers = new List<Member>(members);
            for (var i = 0; i < _groupCount; i++)
            {
                foreach (var member in currentMembers)
                {
                    if (member.GroupsPreference.Count != _groupCount)
                    {
                        Console.WriteLine($"Invalid count of preffered groups for\n{member}\nOmmiting.");
                        remainingMembers.Remove(member);
                        continue;
                    }
                    if (TryAddToGroup(member, i))
                    {
                        remainingMembers.Remove(member);
                    }
                }
                currentMembers.Clear();
                currentMembers.AddRange(remainingMembers);
                currentMembers = currentMembers.OrderBy(x => _rand.Next()).ToList();
            }
        }

        private bool TryAddToGroup(Member member, int preference)
        {
            try
            {
                if (SplittedGroups[member.GroupsPreference[preference] - 1].Count >= GroupSize) return false;
                SplittedGroups[member.GroupsPreference[preference] - 1].Add(member);
                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Invalid preffered group: {member.GroupsPreference[preference] - 1}\nMember:\n{member}");
                return false;
            }
        }
    }
}