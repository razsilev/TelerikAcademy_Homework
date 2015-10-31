using System;

namespace Bank
{
    public abstract class Customer
    {
        protected string name;

        public string GetName
        {
            get { return name; }
        }

        public Customer(string name)
        {
            this.name = name;
        }
    }
}
