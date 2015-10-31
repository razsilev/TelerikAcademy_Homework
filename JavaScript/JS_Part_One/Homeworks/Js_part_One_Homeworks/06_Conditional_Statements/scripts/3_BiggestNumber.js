/* 3.  Write a script that finds the biggest of three integers
       using nested if statements.*/
var log = jsConsole.writeLine;
var num1 = 3;
var num2 = 3;
var num3 = 2;

log("numbers are: " + num1 + ", " + num2 + ", " + num3);

if (num1 > num2) {
    if (num1 > num3) {
        log("The biggest is : " + num1);
    } else {
        log("The biggest is : " + num3);
    }
} else {
    if (num2 > num3) {
        log("The biggest is : " + num2);
    } else {
        log("The biggest is : " + num3);
    }
}