/*
 *   6.   Write a program that finds the most frequent number in an array.
 *        Example:
 *        {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)
 */
var array = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];
var elementsFriquent = {};
var i;
var length = array.length;
var currentElement;
var maxCount = 0;
var mostFriquentNumber;
var property;

// fill dictionary elementsFriquent
for (i = 0; i < length; i += 1) {
    currentElement = array[i];
    if (elementsFriquent[currentElement]) {
        elementsFriquent[currentElement] += 1;
    } else {
        elementsFriquent[currentElement] = 1;
    }
}

// search most frequent number
for (property in elementsFriquent) {
    if (elementsFriquent[property] > maxCount) {
        maxCount = elementsFriquent[property];
        mostFriquentNumber = property;
    }
}

jsConsole.writeLine('array [' + array + ']');
jsConsole.writeLine('most frequent number is: ' + mostFriquentNumber +
                    ' (' + elementsFriquent[mostFriquentNumber] + ' times)');