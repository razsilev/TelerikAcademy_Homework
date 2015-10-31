/*
 *  2.   Write a function that removes all elements with a given value
 *       Attach it to the array type
 *       Read about prototype and how to attach methods.
 */
Array.prototype.removeByValue = function (value) {
    var i = 0,
        count = 0;

    for (i = 0; i < this.length; i += 1) {
        if (this[i] === value) {
            this.splice(i, 1);
            i -= 1;
            count += 1;
        }
    }

    return count;
};

var fruits = ["Apple", "Banana", "Orange", "Apple", "Mango", "Apple"];
var arr = [1, 3, 1, 1, 4, 5, 8, 1];
var value;
var removedElelemnts = 0;

jsConsole.writeLine('array: [' + arr + ']');
value = 1;
jsConsole.writeLine('remove elements with value: ' + value);
removedElelemnts = arr.removeByValue(value);

jsConsole.writeLine('number of removed elements: ' + removedElelemnts);
jsConsole.writeLine('array: [' + arr + ']');

// test with remove from fruits array
jsConsole.writeLine('');
jsConsole.writeLine('fruits array: [' + fruits + ']');
value = 'Apple';
jsConsole.writeLine('remove elements with value: ' + value);
removedElelemnts = fruits.removeByValue(value);

jsConsole.writeLine('number of removed elements: ' + removedElelemnts);
jsConsole.writeLine('fruits array: [' + fruits + ']');