/* 7.  Write a script that finds the greatest of given 5 variables.*/
var log = jsConsole.writeLine;
var numbers = [1, 2, 3, 4, 5];
var biggerValue = numbers[0];
var i;

for (i = 1; i < numbers.length; i += 1) {
    if (numbers[i] > biggerValue) {
        biggerValue = numbers[i];
    }
}

log("greatest value is: " + biggerValue);