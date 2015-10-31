/*
 *  3.      Write a JavaScript function that finds how many times
 *          a substring is contained in a given text 
 *          (perform case insensitive search).
 *          Example: The target substring is "in". The text is as follows:
 */
function substringCountInText(text, substring) {
    var regExp = new RegExp(substring, 'gi');

    return text.match(regExp).length;
}

var text = 'We are living in an yellow submarine. We don\'t have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.';
var substring = 'in';

jsConsole.writeLine('text:');
jsConsole.writeLine(text);
jsConsole.writeLine('');
jsConsole.writeLine('substring: ' + substring);
jsConsole.writeLine('');
jsConsole.writeLine('count of substring in text:');
jsConsole.writeLine('The result is: ' + substringCountInText(text, substring));