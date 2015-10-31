using System;

namespace PersonTest
{
    public class Person
    {
        public string Name { get; set; }
        public int? Age { get; set; }

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            if (this.Age == null)
            {
                return this.Name + " age: null";
            }
            else
            {
                return string.Format("{0} age: {1}", this.Name, this.Age);
            }
            
        }
    }
}
