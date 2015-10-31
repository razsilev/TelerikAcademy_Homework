using System;

namespace DefineExceptionClassAndTestHim
{
    public class InvalidRangeException<T> : ApplicationException
    {
        public T Start { get; private set; }
        public T End { get; private set; }

        public InvalidRangeException() :
            this("", default(T), default(T), null)
        {

        }

        public InvalidRangeException(string message) :
            this(message, default(T), default(T), null)
        {

        }

        public InvalidRangeException(string message, T start, T end) :
            this(message, start, end, null)
        {

        }

        public InvalidRangeException(string message, T start, T end, Exception innerException) :
            base(message, innerException)
        {
            this.Start = start;
            this.End = end;
        }

        public override string ToString()
        {
            return string.Format("{0} range from {1} to {2}", base.Message, this.Start, this.End);
        }
    }
}
