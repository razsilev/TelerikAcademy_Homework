/* 4.  Sort 3 real values in descending order using nested if statements.*/
var log = jsConsole.writeLine;
var num1 = 6;
var num2 = 10;
var num3 = 104;
var oldValue = 0;

log("numbers are: " + num1 + ", " + num2 + ", " + num3);

if (num1 < num2) {
    oldValue = num1;
    num1 = num2;
    num2 = oldValue;

    if (num1 < num3) {
        oldValue = num1;
        num1 = num3;
        num3 = oldValue;

        if (num2 < num3) {
            oldValue = num2;
            num2 = num3;
            num3 = oldValue;
        }
    } else {
        if (num2 < num3) {
            oldValue = num2;
            num2 = num3;
            num3 = oldValue;
        }
    }
} else {
    if (num1 < num3) {
        oldValue = num1;
        num1 = num3;
        num3 = oldValue;

        if (num2 < num3) {
            oldValue = num2;
            num2 = num3;
            num3 = oldValue;
        }
    } else {
        if (num2 < num3) {
            oldValue = num2;
            num2 = num3;
            num3 = oldValue;
        }
    }
}

log("Sorted numbers: " + num1 + ", " + num2 + ", " + num3);