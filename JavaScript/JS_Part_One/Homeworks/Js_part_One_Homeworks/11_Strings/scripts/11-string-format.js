/*
 *  11.   Write a function that formats a string using placeholders:
 *        The function should work with up to 30 placeholders and all types
 */
function stringFormat() {
    var string = arguments[0],
        regExp,
        i = 0;

    for (i = 0; i < arguments.length - 1; i += 1) {
        regExp = new RegExp('\\{' + i + '\\}', 'g');
        string = string.replace(regExp, arguments[i + 1]);
    }

    return string;
}

var number = 7;
var format = 'Say {2} times Hello {1}! Hello {0} and again hello {1}!';
var str = stringFormat(format, 'Peter', 'Gosho', number);

jsConsole.writeLine('str = "' + str + '";');