using System;

namespace _06._Valid_Person
{
    public class Person
    {
        private const string InvalidNameException = "Name cannot be null or empty";
        private const string InvalidAgeEcxeption = "Age should be in range [0...120]";

        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, InvalidNameException);
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, InvalidNameException);
                }
                this.firstName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Age", InvalidAgeEcxeption);
                }
                this.age = value;
            }
        }
    }
}
