/*
 *   2.   Write a script that compares two char arrays 
 *        lexicographically (letter by letter).
 */
var first = 'abc';
var second = 'aaC';
var length = (first.length > second.length) ? first.length : second.length;
var isEqualArrays = true;
var i;

jsConsole.writeLine('Key insensitive comparers two char arrays.');

for (i = 0; i < length; i += 1) {
    if (first[i].toLowerCase() < second[i].toLowerCase()) {
        jsConsole.writeLine('first array is before second');
        isEqualArrays = false;
        break;
    } else if (first[i].toLowerCase() > second[i].toLowerCase()) {
        jsConsole.writeLine('second array is before first');
        isEqualArrays = false;
        break;
    }
}

if (isEqualArrays) {
    jsConsole.writeLine('arrays are equal');
}