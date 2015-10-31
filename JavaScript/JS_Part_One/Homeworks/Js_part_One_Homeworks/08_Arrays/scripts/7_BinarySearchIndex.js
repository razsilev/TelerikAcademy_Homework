/*
 *  7.   Write a program that finds the middle of given element
 *       in a sorted array of integers by using
 *       the binary search algorithm (find it in Wikipedia).
 */
var array = [1, 3, 5, 6, 7, 8, 9, 10, 13];
var start = 0;
var end = array.length;
var middle = Math.floor(end / 2);
var searchNumber = 7;

// binary search algorithm
while ((end - start) > 1) {
    if (searchNumber === array[middle]) {
        break;
    }

    // cut half array elements
    if (array[middle] < searchNumber) {
        start = middle;
    } else {
        end = middle;
    }

    // calculate middle index
    middle = Math.floor((end - start) / 2) + start;
}

jsConsole.writeLine('array: [' + array + ']');

if (searchNumber === array[middle]) {
    jsConsole.writeLine('searched number is: ' + searchNumber);
    jsConsole.writeLine('his index is: ' + middle);
} else {
    jsConsole.writeLine(searchNumber + ' - is not a parth of the array');
}