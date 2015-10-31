using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GsmUse
{
    public class Displays
    {
        private float size { get; set; }
        private int numberOfColors { get; set; }

        public float Size
        {
            get
            {
                return size;
            }

            set
            {
                if (value > 0)
                {
                    size = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Size CAN be bigger then zero!");
                }
            }
        }

        public int NumberOfColors
        {
            get
            {
                return numberOfColors;
            }

            set
            {
                if (value > 0)
                {
                    numberOfColors = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Number of colors CAN be bigger then zero!");
                }
            }
        }

        public Displays(float size)
        {
            this.Size = size;
        }

        public Displays(float size, int numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public Displays Copy()
        {
            return new Displays(this.size, this.numberOfColors);
        }

        public override string ToString()
        {
            return string.Format("size: {0}\"  number of colors: {1}",
                this.Size, this.NumberOfColors);
        }
    }
}
