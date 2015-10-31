using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03Animals
{
    public class Cat : Animal
    {
        public override int Age
        {
            get
            {
                return base.age;
            }
            set
            {
                if (value >= 0)
                {
                    base.age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Age can NOT be negative.");
                }
            }
        }

        public override string Name
        {
            get
            {
                return base.name;
            }
            set
            {
                if (value != null)
                {
                    base.name = value;
                }
                else
                {
                    throw new ArgumentNullException("Name can NOT be null.");
                }
            }
        }

        public override Sex Sexuality
        {
            get
            {
                return base.sex;
            }
            protected set
            {
                base.sex = value;
            }
        }

        public Cat(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sexuality = sex;
        }

        public override string Sound()
        {
            return string.Format("cat {0} say: Miayyy", base.name);
        }
    }
}
