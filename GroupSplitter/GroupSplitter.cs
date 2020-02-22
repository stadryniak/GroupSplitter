using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GroupSplitter
{
    class GroupSplitter
    {
        public List<List<Member>> GroupsMemList { get; private set; }
        public int GroupSize { get; set; }
        private readonly Random Rand = new Random();
        private int _groupCount;

        public int GroupCount
        {
            get => _groupCount;
            set
            {
                _groupCount = value;
                if (GroupsMemList == null)
                {
                    InitializeGroupsMemList(value);
                    return;
                }

                List<Member> tmpList = new List<Member>();
                foreach (var list in GroupsMemList)
                {
                    tmpList.AddRange(list);
                }

                SplitIntoGroups(tmpList);
            }
        }

        private void InitializeGroupsMemList(int size)
        {
            GroupsMemList = new List<List<Member>>();
            for (var i = 0; i < size; i++)
            {
                GroupsMemList.Add(new List<Member>());
            }
        }

        public void SplitIntoGroups(List<Member> members)
        {
            members = members.OrderBy(x => Rand.Next()).ToList();
            foreach (var member in members)
            {
                if (!TryAddToGroup(member))
                {
                    Console.WriteLine($"Error while adding: {member}");
                }
            }
        }

        private bool TryAddToGroup(Member member)
        {
            foreach (var i in member.GroupsPreference.Where(i => GroupsMemList[i].Count <= GroupSize))
            {
                GroupsMemList[i].Add(member);
                return true;
            }
            return false;
        }
    }
}