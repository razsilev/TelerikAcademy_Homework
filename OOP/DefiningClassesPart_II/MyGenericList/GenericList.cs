using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGenericList
{
    public class GenericList<T>
        where T : IComparable<T>
    {
        private T[] array;
        public int Count { get; private set; }
        private const int DefaultLength = 4;

        public int Capacity
        {
            get
            {
                return this.array.Length;
            }
        }

        public GenericList() : this(DefaultLength)
        {
        }

        public GenericList(int startLength)
        {
            if (startLength < 0)
            {
                throw new IndexOutOfRangeException("Index must be positive integer number.");
            }

            this.array = new T[startLength];
            this.Count = 0;
        }

        public void Add(T item)
        {
            if (this.Count >= this.array.Length)
            {
                AutoGrow();
            }

            this.array[Count] = item;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            if (!IsValidIndex(index))
            {
                ThrowIndexOutOfRangeException();
            }

            for (int i = index; i < this.Count - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.array[this.Count - 1] = default(T);
            this.Count--;
        }

        public T this[int index]
        {
            get
            {
                if (IsValidIndex(index))
                {
                    return this.array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index must be within the bounds of the GenericList.");
                }
            }

            set
            {
                if (IsValidIndex(index))
                {
                    this.array[index] = value;
                }
                else
                {
                    ThrowIndexOutOfRangeException();
                }
            }
        }

        public void Insert(int index, T item)
        {
            if (!IsValidIndex(index))
            {
                ThrowIndexOutOfRangeException();
            }

            Count++;

            for (int i = Count - 1; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            this.array[index] = item;
        }

        private static void ThrowIndexOutOfRangeException()
        {
            throw new IndexOutOfRangeException("Index must be within the bounds of the GenericList.");
        }

        public void Clear()
        {
            Array.Clear(this.array, 0, this.Count);

            this.Count = 0;
        }

        public int Find(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool IsValidIndex(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AutoGrow()
        {
            T[] doubleSizeArray = new T[this.array.Length * 2];

            for (int i = 0; i < this.array.Length; i++)
            {
                doubleSizeArray[i] = this.array[i];
            }

            this.array = doubleSizeArray;
        }

        public T Min()
        {
            T min = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (min.CompareTo(this.array[i]) > 0)
                {
                    min = this.array[i];
                }
            }

            return min;
        }

        public T Max()
        {
            T max = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (max.CompareTo(this.array[i]) < 0)
                {
                    max = this.array[i];
                }
            }

            return max;
        }

        public static T Min<T>(T first, T second)
            where T : IComparable<T>
        {
            if (first.CompareTo(second) < 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        public static T Max<T>(T first, T second)
            where T : IComparable<T>
        {
            if (first.CompareTo(second) > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("[{0}", this.array[0]);

            for (int i = 1; i < this.Count; i++)
            {
                result.AppendFormat(", {0}", this.array[i]);
            }

            result.Append("]");

            return result.ToString();
        }
    }
}
