using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupSplitter
{
    class GroupSplitter
    {
        public List<List<Member>> GroupsMemList { get; private set; }

        public int GroupSize
        {
            get => _groupSize;
            set
            {
                _groupSize = value;
                var tmpList = new List<Member>();
                foreach (var list in GroupsMemList)
                {
                    tmpList.AddRange(list);
                }
                ValidateCapacity(tmpList);
            }
        }

        private readonly Random _rand = new Random();
        private int _groupCount;
        private int _groupSize;

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
                ValidateCapacity(tmpList);
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

        private void ValidateCapacity(List<Member> members)
        {
            if (_groupCount * GroupSize >= members.Count) return;
            throw new IndexOutOfRangeException("More members than spots.");
        }

        public void SplitIntoGroups(List<Member> members)
        {
            ValidateCapacity(members);
            members = members.OrderBy(x => _rand.Next()).ToList();
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
                currentMembers = currentMembers.OrderBy(x => _rand.Next()).ToList();
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