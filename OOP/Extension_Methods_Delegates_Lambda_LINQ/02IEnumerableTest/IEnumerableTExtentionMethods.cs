using System;
using System.Collections.Generic;
using System.Linq;

namespace _02IEnumerableTest
{
    public static class IEnumerableTExtentionMethods
    {
        public static T Sum<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source mast not be null");
            }

            try
            {
                T sum = default(T);

                foreach (T item in source)
                {
                    sum = (dynamic)sum + item;
                }

                return sum;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Undefined sum operation on this type.");
            }
        }

        public static T Product<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source mast not be null");
            }

            try
            {
                T product = (dynamic)1;

                foreach (T item in source)
                {
                    product = (dynamic)product * item;
                }

                return product;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Undefined product operation on this type.");
            }
        }

        public static T Min<T>(this IEnumerable<T> source)
            where T : IComparable
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source mast not be null.");
            }

            T min = source.FirstOrDefault();

            foreach (T item in source.Skip(1))
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }

            return min;

        }

        public static T Max<T>(this IEnumerable<T> source)
            where T : IComparable
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source mast not be null.");
            }

            T max = source.FirstOrDefault();

            foreach (T item in source.Skip(1))
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public static T Average<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source mast not be null.");
            }

            try
            {
                T sum = source.Sum();

                int count = source.Count();

                T average = (dynamic)sum / (dynamic)count;

                return average;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Undefined average operation on this type.");
            }
        }
    }
}
