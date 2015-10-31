using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace _05TestBitArray64
{
    public class BitArray64 : IEnumerable<ulong>
    {
        private ulong[] array;
        public int Length { get; private set; }

        public BitArray64(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("Length must be positive.");
            }

            this.Length = length;
            this.array = new ulong[length];
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            for (int i = 0; i < this.Length; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Call the generic version of the method
            return this.GetEnumerator();
        }

        public ulong this[int index]
        {
            get
            {
                this.IsValidIndex(index);

                return this.array[index];
            }

            set
            {
                IsValidIndex(index);

                this.array[index] = value;
            }
        }

        private bool IsValidIndex(int index)
        {
            if (index >= 0 && index < this.Length)
            {
                return true;
            }

            throw new ArgumentOutOfRangeException("Invalid index: " + index);
        }

        public override bool Equals(object obj)
        {
            return this == (BitArray64)obj;
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            if ((object)first == null && (object)second == null)
            {
                return true;
            }

            if ((object)first == null || (object)second == null)
            {
                return false;
            }

            if (first.Length == second.Length)
            {
                for (int i = 0; i < first.Length; i++)
                {
                    if (first.array[i] != second[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !(first == second);
        }

        public override int GetHashCode()
        {
            return this.array.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("[ ");

            for (int i = 0; i < this.Length - 1; i++)
            {
                result.AppendFormat("{0}, ", this.array[i]);
            }

            result.AppendFormat("{0} ]", this.array[this.Length - 1]);

            return result.ToString();
        }
    }
}
