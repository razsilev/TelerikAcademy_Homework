using System;

class CheckPointForInCircleAndOutRectangle
{
    static void Main()
    {
        const int CIRCLE_CENTER = 1;
        const int RADIUS = 3;
        const int RECTANGLE_LEFT_SIDE = -1;
        const int RECTANGLE_RIGHT_SIDE = 5;
        const int RECTANGLE_TOP_SIDE = 3;
        const int RECTANGLE_BOTTOM_SIDE = 1;

        float pointX = 2f;
        float pointY = 2f;

        bool isInCircle = false;
        bool isOutRectangle = true;

        // correction for translate circle K((1,1),3) in K((0,0),3)
        float correctionX = pointX - 1;
        float correctionY = pointY - 1;

        if ((correctionX * correctionX + correctionY * correctionY) <= (RADIUS * RADIUS))
        {
            isInCircle = true;
        }

        if (pointX >= RECTANGLE_LEFT_SIDE &&
            pointY >= RECTANGLE_BOTTOM_SIDE &&
            pointX <= RECTANGLE_RIGHT_SIDE &&
            pointY <= RECTANGLE_TOP_SIDE)
        {
            isOutRectangle = false;
        }

        Console.WriteLine("Point is in the circle and out of the rectangle: " +
            (isInCircle && isOutRectangle));
    }
}