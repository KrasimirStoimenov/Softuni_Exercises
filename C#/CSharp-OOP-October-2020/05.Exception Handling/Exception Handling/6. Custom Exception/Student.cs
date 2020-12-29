using _6._Custom_Exception.Exceptions;
using System.Linq;

namespace _6._Custom_Exception
{
    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name
        {
            get
            {
                return this.Name;
            }
            set
            {
                if (value.Any(ch => !char.IsLetter(ch)))
                {
                    throw new InvalidPersonNameException("Name should not contain any special symbol or numeric value!!!");
                }
                this.name = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
    }
}
