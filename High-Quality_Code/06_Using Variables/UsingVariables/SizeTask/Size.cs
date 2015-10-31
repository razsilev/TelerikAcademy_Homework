namespace SizeTask
{
    using System;

    /// <summary>
    /// Size class
    /// </summary>
    public class Size
    {
        private double width;
        private double height;

        public static void Main()
        {

        }

        public Size(double initialWidth, double initialHeight)
        {
            this.Width = initialWidth;
            this.Height = initialHeight;
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("width can not be less then or equal to 0");
                }

                width = value; 
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("height can not be less then or equal to 0");
                }
                height = value;
            }
        }

        /// <summary>
        /// Rotate given size of a given engle.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="angleOfRotation"></param>
        /// <returns>New size rotated of a given engle.</returns>
        public static Size GetRotatedSize(Size size, double angleOfRotation)
        {
            double angleOfRotationCos = Math.Abs(Math.Cos(angleOfRotation));
            double angleOfRotationSin = Math.Abs(Math.Sin(angleOfRotation));

            double cosWidth = angleOfRotationCos * size.Width;
            double sinHeight = angleOfRotationSin * size.Height;
            double newWidth = cosWidth + sinHeight;

            double sinWidth = angleOfRotationSin * size.Width;
            double cosHeight = angleOfRotationCos * size.Height;
            double newHeight = sinWidth + cosHeight;

            Size rotatedSize = new Size(newWidth, newHeight);

            return rotatedSize;
        }
    }
}