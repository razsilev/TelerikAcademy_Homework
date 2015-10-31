namespace FillRandomData
{
    using System;

    public class RandomDataGenetator
    {
        private const string Letters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

        private Random random;
        private static RandomDataGenetator randGenerator;

        private RandomDataGenetator()
        {
            this.random = new Random();
        }

        public static RandomDataGenetator Instance
        {
            get
            {
                if (randGenerator == null)
                {
                    randGenerator = new RandomDataGenetator();
                }

                return randGenerator;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(result);
        }

        public string GetRandomStringWithRandomLength(int min, int max)
        {
            return this.GetRandomString(this.GetRandomNumber(min, max));
        }


    }
}
