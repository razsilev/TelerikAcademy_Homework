/* 2.  Write a script that shows the sign (+ or -)
       of the product of three real numbers without calculating it.
       Use a sequence of if statements.*/
var log = jsConsole.writeLine;
var num1 = -1;
var num2 = 3;
var num3 = -3;

log("numbers are: " + num1 + ", " + num2 + ", " + num3);

if ((num1 == 0) || (num2 == 0) || (num3 == 0)) {
    log("The product is 0 and there is no sign!");
}

if ((num1 < 0) ^ (num2 < 0) ^ (num3 < 0)) {
    log("The sign of product is: -");
} else {
    log("The sign of product is: +");
}