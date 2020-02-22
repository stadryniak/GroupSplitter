using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GroupSplitter
{
    class GroupSplitter
    {
        public List<List<Member>> GroupsMemList { get; private set; }
        public int groupSize { get; set; }
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
            for (int i = 0; i < _groupCount; i++)
            {
                foreach (var member in members)
                {
                    GroupsMemList[member.GroupsPreference[i]].Add(member);
                }
            }
            RemoveGroupsOverflows();
        }

        private void RemoveGroupsOverflows()
        {
            
        }
    }
}
