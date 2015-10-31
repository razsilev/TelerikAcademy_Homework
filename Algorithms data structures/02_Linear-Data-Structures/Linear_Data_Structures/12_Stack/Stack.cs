using System;
namespace _12_Stack
{
    public class Stack <T>
    {
        private T[] elements;
        private int currentIndex;

        public Stack(int capasity = 4)
        {
            this.elements = new T[capasity];
            this.currentIndex = 0;
        }

        public int Count
        {
            get
            {
                return currentIndex;
            }
        }

        public Stack<T> Push(T element)
        {
            if (this.currentIndex >= this.elements.Length)
            {
                Resize();
            }

            this.elements[this.currentIndex] = element;
            this.currentIndex++;

            return this;
        }

        public T Pop()
        {
            if (this.currentIndex < 0)
            {
                throw new ArgumentException("Stack is Empty!");
            }

            this.currentIndex--;
            return this.elements[this.currentIndex];
        }

        private void Resize()
        {
            var newArray = new T[elements.Length * 2];

            for (int i = 0; i < this.currentIndex; i++)
            {
                newArray[i] = this.elements[i];
            }

            this.elements = newArray;
        }
    }
}
