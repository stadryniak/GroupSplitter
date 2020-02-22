using System;
using System.Collections.Generic;
using System.Text;

namespace GroupSplitter
{
    class GroupSplitter
    {
        public List<List<Member>> GroupsMemList { get; }
        private int _groupCount;
        public int GroupCount
        {
            get => _groupCount;
            set
            {
                _groupCount = value;
                if (GroupsMemList == null) return;
                List<Member> tmpList = new List<Member>();
                foreach (var list in GroupsMemList)
                {
                    tmpList.AddRange(list);
                }
                SplitIntoGroups(tmpList);
            }
        }

        public void SplitIntoGroups(List<Member> members)
        {
            foreach (var member in members)
            {

            }
        }
    }
}
