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

                var tmpList = new List<Member>();
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
            List<Member> remainingMembers = new List<Member>(members);
            List<Member> currentMembers = new List<Member>(members);
            for (int i = 0; i < _groupCount; i++)
            {
                foreach (var member in currentMembers)
                {
                    if (TryAddToGroup(member, i))
                    {
                        remainingMembers.Remove(member);
                    }
                }
                currentMembers.Clear();
                currentMembers.AddRange(remainingMembers);
                currentMembers = currentMembers.OrderBy(x => Rand.Next()).ToList();
            }
        }

        private bool TryAddToGroup(Member member, int preference)
        {
            if (GroupsMemList[member.GroupsPreference[preference] - 1].Count >= GroupSize) return false;
            GroupsMemList[member.GroupsPreference[preference] - 1].Add(member);
            return true;
        }
    }
}