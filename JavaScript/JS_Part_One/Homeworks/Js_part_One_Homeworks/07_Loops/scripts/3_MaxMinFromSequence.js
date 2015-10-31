/*
 *  3.   Write a script that finds the max and min number
 *       from a sequence of numbers.
 */
var array = [3, 5, 1, 8, 4],
    min = array[0],
    max = array[0],
    numbersString = '[',
    i = 1,
    length;

for (i = 0, length = array.length; i < length; i += 1) {
    if (min > array[i]) {
        min = array[i];
    }

    if (max < array[i]) {
        max = array[i];
    }

    numbersString += array[i] + ', ';
}

numbersString = numbersString.substring(0, numbersString.length - 2) + ']';

jsConsole.writeLine('numbers are: ' + numbersString);
jsConsole.writeLine('min is: ' + min);
jsConsole.writeLine('max is: ' + max);