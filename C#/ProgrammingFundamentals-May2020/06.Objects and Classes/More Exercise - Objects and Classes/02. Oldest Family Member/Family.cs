using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Oldest_Family_Member
{
    class Family
    {
        public List<Person> familyMembers;

        public Family()
        {
            familyMembers = new List<Person>();
        }

        public Person GetOldestMember(Family family)
        {
            var sorted = familyMembers.OrderByDescending(x => x.Age).ToList();

            return sorted[0];
        }

        public void AddMember(Person currentPerson)
        {
            familyMembers.Add(currentPerson);
        }
    }
}
