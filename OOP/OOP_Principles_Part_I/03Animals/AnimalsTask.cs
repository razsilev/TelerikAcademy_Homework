using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03Animals
{
    class AnimalsTask
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>(6);

            AddAnimals(animals);

            Console.WriteLine("Animals sound:");
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine(animals[i].Sound());
            }

            var averageAgesDog = from a in animals
                              where a is Dog
                              select a;

            var averageAgesCat = from a in animals
                                 where a is Cat
                                 select a;
            
            var averageAgesFrog = from a in animals
                                 where a is Frog
                                 select a;

            Console.WriteLine("\nAnimals average age:");
            Console.WriteLine("Dogs age: {0} years", Animal.AverageAge(averageAgesDog));
            Console.WriteLine("Cats age: {0} years", Animal.AverageAge(averageAgesCat));
            Console.WriteLine("Frogs age: {0} years", Animal.AverageAge(averageAgesFrog));
        }

        private static void AddAnimals(List<Animal> animals)
        {
            animals.Add(new Dog("Gosho", 3, Sex.Male));
            animals.Add(new Dog("Pepi", 8, Sex.Female));
            animals.Add(new Dog("Emo", 6, Sex.Male));
            animals.Add(new Frog("Mimi", 3, Sex.Female));
            animals.Add(new Frog("Vanq", 4, Sex.Female));
            animals.Add(new Cat("Ema", 6, Sex.Female));
            animals.Add(new Kitten("Vanesa", 5));
            animals.Add(new Tomcat("Tom", 4));
            animals.Add(new Tomcat("Little Tom", 1));
        }
    }
}
