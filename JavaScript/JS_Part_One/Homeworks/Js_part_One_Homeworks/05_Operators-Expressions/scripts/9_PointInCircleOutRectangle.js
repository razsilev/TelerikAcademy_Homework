/*   9. Write an expression that checks for given point (x, y)
*       if it is within the circle K( (1,1), 3) and out of the rectangle
*       R(top=1, left=-1, width=6, height=2). 
*/

var x = 3;
var y = 2;

function isPointInCircleOutRectangle(pointX, pointY) {
    // return circle centur to (0,0) and increasepoint coordinates
    var isInCircleOutRectangle = false,
        newX = pointX - 1,
        newY = pointY - 1,
        radius = 3,
        hypotenuse = Math.sqrt((newX * newX) + (newY * newY));

    if ((hypotenuse <= radius) &&
            (pointX < -1 || pointX > 5 || pointY > 1 || pointY < -1)) {
        isInCircleOutRectangle = true;
    }

    return isInCircleOutRectangle;
}

jsConsole.writeLine("Is in circle and out rectangle: " + isPointInCircleOutRectangle(x, y));