using System.Collections.Generic;

namespace GroupSplitter
{
    /// <summary>
    /// Holds data about one member
    /// </summary>
    internal class Member
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

        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal List<int> GroupsPreference { get; set; }

        public override string ToString()
        {
            string groups = "";
            foreach (var i in GroupsPreference)
            {
                groups += i.ToString() + " ";
            }
            groups.TrimEnd();
            return FirstName + " " + LastName + "\t" + groups;
        }
    }
}
