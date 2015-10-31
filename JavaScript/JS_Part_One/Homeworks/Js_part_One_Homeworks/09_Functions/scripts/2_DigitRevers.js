/*
 *   2.   Write a function that reverses the digits
 *        of given decimal number. Example: 256 -> 652
 */
function digitRevers(number) {
    var numberAsString = number.toString(),
        array = [],
        i = 0,
        stringResult = '';

    for (i = 0; i < numberAsString.length; i += 1) {
        array.unshift(numberAsString[i]);
    }

    stringResult = array.join('');

    return stringResult * 1;
}

var number = 256;
var reversed = digitRevers(number);

jsConsole.writeLine('Reverse digits in number.');
jsConsole.writeLine(number + ' -> ' + reversed);
jsConsole.writeLine('type of reversed: ' + typeof reversed);