using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03Animals
{
    public abstract class Animal : ISound
    {
        protected int age;

        public abstract int Age { get; set; }

        protected string name;

        public abstract string Name { get; set; }

        protected Sex sex;

        public abstract Sex Sexuality {get; protected set;}

        public abstract string Sound();

        public static int AverageAge(IEnumerable<Animal> animals)
        {
            if (animals == null)
            {
                throw new ArgumentNullException("To calculate average age must have animals.");
            }

            int ageSum = 0;
            int count = 0;

            foreach (var animal in animals)
	        {
                ageSum += animal.Age;
                count++;
	        }

            return ageSum / count;
        }
    }
}
