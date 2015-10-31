/*
 *  1.   Write a JavaScript function reverses string and
 *       returns it Example: "sample" -> "elpmas".
 */
function stringReverser(string) {
    var reversed = '',
        i = 0,
        end = string.length - 1;

    for (i = end; i >= 0; i -= 1) {
        reversed += string[i];
    }

    return reversed;
}

var string = '12345';

jsConsole.writeLine(string + ' -> ' + stringReverser(string));