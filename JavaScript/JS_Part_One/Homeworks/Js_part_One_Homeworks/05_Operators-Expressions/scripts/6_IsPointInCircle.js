/* 6. Write an expression that checks if given print (x,  y) 
 *    is within a circle K(O, 5). 
 */
var point = {
    "x": 0,
    "y": 1
};

jsConsole.writeLine("point x = " + point.x + "; y = " + point.y + ";");
jsConsole.writeLine("point is in circle whit radius 5: " +
    ((point.x * point.x) + (point.y * point.y) <= 25));