using System;

namespace Methods
{
    public class Methods
    {
        public enum PrintFormatOption
        {
            FloatTwoSymbolsAfterComma,
            Percentage,
            PadRightEightSymbols
        };

        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static string DigitToText(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("Invalid digit! Digit mast be positive and one symbol.");
            }
        }

        public static int FindMaxValue(params int[] elements)
        {
            int maxValue = elements[0];

            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Elements can not be null or empty.");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxValue)
                {
                    maxValue = elements[i];
                }
            }

            return maxValue;
        }

        public static void PrintNumber(double number,
            PrintFormatOption format = PrintFormatOption.FloatTwoSymbolsAfterComma)
        {
            if (format == PrintFormatOption.FloatTwoSymbolsAfterComma)
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == PrintFormatOption.Percentage)
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == PrintFormatOption.PadRightEightSymbols)
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Invalid format");
            }
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            Console.WriteLine(DigitToText(5));
            Console.WriteLine(FindMaxValue(5, -1, 3, 2, 14, 2, 3));

            PrintNumber(1.3, PrintFormatOption.FloatTwoSymbolsAfterComma);
            PrintNumber(0.75, PrintFormatOption.Percentage);
            PrintNumber(2.30, PrintFormatOption.PadRightEightSymbols);

            Point firstPoint = new Point(3, -1);
            Point secondPoint = new Point(3, 2.5);
            bool horizontal = firstPoint.IsHorizontalTo(secondPoint);
            bool vertical = firstPoint.IsVerticalTo(secondPoint);

            Console.WriteLine(firstPoint.DistanceTo(secondPoint));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17), "From Sofia.");

            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3),
                "From Vidin, gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.DateOfBirth < stella.DateOfBirth);
        }
    }
}
