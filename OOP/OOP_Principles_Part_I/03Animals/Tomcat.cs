using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age) : base(name, age, Sex.Male)
        {

        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", base.name, base.age);
        }
    }
}
