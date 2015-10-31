namespace _2_Human
{
    public class HumanTest
    {
        public enum Sex
        {
            Male,
            Fmale
        }

        public static void Main()
        {
            int age = 13;

            MakeHuman(age);
        }

        public static void MakeHuman(int age)
        {
            Human person = new Human();

            person.Age = age;
            if (age % 2 == 0)
            {
                person.Name = "Батката";
                person.Sex = Sex.Male;
            }
            else
            {
                person.Name = "Мацето";
                person.Sex = Sex.Fmale;
            }
        }

        public class Human
        {
            public Sex Sex { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}
