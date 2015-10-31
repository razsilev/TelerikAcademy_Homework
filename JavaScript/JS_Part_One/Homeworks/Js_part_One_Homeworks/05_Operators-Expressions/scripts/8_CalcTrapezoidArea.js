/* 8. Write an expression that calculates trapezoid's area
      by given sides a and b and height h. */
var a = 4;
var b = 6;
var h = 3;

function calcTrapezoidArea(a, b, h) {
    var area = ((a + b) * h) / 2;

    return area;
}

jsConsole.writeLine("trapetzoid area is: " + calcTrapezoidArea(a, b, h));