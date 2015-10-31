/*
 *  3.   Write a script that finds the maximal sequence
 *       of equal elements in an array.
 *		 Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.
 */
var array = [2, 1, 1, 2, 3, 3, 'T', 'T', 'T', 2];
var i;
var length;
var maxLength = 0;
var count = 1;
var currentSymbol = array[0];
var symbol = currentSymbol;

for (i = 1, length = array.length; i < length; i += 1) {
    if (currentSymbol === array[i]) {
        count += 1;
    } else {
        if (maxLength < count) {
            maxLength = count;
            symbol = currentSymbol;
        }

        count = 1;
        currentSymbol = array[i];
    }
}

if (maxLength < count) {
    maxLength = count;
    symbol = currentSymbol;
}

jsConsole.writeLine('maximal sequence of equal elements:');
jsConsole.writeLine('length: ' + maxLength);
jsConsole.writeLine('element: [ ' + symbol + ' ]');