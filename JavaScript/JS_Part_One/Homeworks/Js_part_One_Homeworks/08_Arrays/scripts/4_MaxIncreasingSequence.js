/*
 *   4.   Write a script that finds the maximal increasing 
 *        sequence in an array. 
 *        Example:{3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
 */
var array = [3, 2, 3, 4, 2, 2, 4];
var i;
var length = array.length;
var startIndex = 0;
var maxLength = 0;
var count = 1;
var result = '{';

for (i = 1; i < length; i += 1) {
    if (array[i] > array[i - 1]) {
        count += 1;
    } else {
        if (maxLength < count) {
            maxLength = count;
            startIndex = i - count;
        }

        count = 1;
    }
}

// check is sequence with last element have max length
if (maxLength < count) {
    maxLength = count;
    startIndex = i - count;
}

// create result string
for (i = startIndex; i < startIndex + maxLength; i += 1) {
    result += array[i] + ', ';
}

result = result.substr(0, result.length - 2) + '}';

jsConsole.writeLine('array: {' + array + '}');
jsConsole.writeLine('maximal increasing sequence is: ' + result);