/* 6.  Write a script that enters the coefficients a, b and c
       of a quadratic equation  a*x2 + b*x + c = 0
       and calculates and prints its real roots.
       Note that quadratic equations may have 0, 1 or 2 real roots.*/
var log = jsConsole.writeLine;
var a = 2;
var b = 2;
var c = -4;
var root1 = 0;
var root2 = 0;

log(a + "*X*X + " + b + "*X + " + c);

var determinanta = (b * b) - (4 * a * c);

if (a === 0) {
    log("Equation have 1 root: " + (-c / b));
} else {
    if (determinanta < 0) {
        log("Equation have 0 roots");
    } else {
        if (determinanta === 0) {
            root1 = -b / (2 * a);

            log("Equation have 1 root: " + root1);
        } else {
            var sqrtDeterminanta = Math.sqrt(determinanta);

            root1 = (-b + sqrtDeterminanta) / (2 * a);
            root2 = (-b - sqrtDeterminanta) / (2 * a);

            log("Equation have 2 roots: " + root1 + ", " + root2);
        }
    }
}