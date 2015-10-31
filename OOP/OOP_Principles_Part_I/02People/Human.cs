using System;

namespace _02People
{
    public abstract class Human
    {
        protected string firstName;
        protected string lastName;

        public string GetFirstName { get { return this.firstName; } }
        public string GetLastName { get { return this.lastName; } }
    }
}
