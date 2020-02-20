using System.Collections.Generic;

namespace GroupSplitter
{
    class Member
    {
        public static Member CreateInstance(string firstName, string lastName, List<int> groupsPreference)
        {
            return new Member(firstName, lastName, groupsPreference);
        }

        private Member(string firstName, string lastName, List<int> groupsPreference)
        {
            FirstName = firstName;
            LastName = lastName;
            GroupsPreference = groupsPreference;
        }

        private string FirstName { get; set; }
        private string LastName { get; set; }
        private List<int> GroupsPreference { get; set; }
    }
}
