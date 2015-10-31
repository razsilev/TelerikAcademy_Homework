/*
 *  5.   Write a function that replaces non breaking
 *       white-spaces in a text with &nbsp;
 */
function replaceWhiteSpaces(text) {
    var replacedText = '',
        i = 0,
        forAppend = '',
        forRplace = ' ',
        replaceWith = '&nbsp;',
        length = text.length;

    for (i = 0; i < length; i += 1) {
        forAppend = text[i];
        if (forAppend === forRplace) {
            forAppend = replaceWith;

            while (text[i] === forRplace) {
                i += 1;
            }

            i -= 1;
        }

        replacedText += forAppend;
    }

    return replacedText;
}

var text = 'some text       test';

jsConsole.writeLine('original text: ' + text);
jsConsole.writeLine('replased text: ' + replaceWhiteSpaces(text));
jsConsole.writeLine('<br />To see diferences look consol on the brouser.');

console.log('original text: ' + text);
console.log('replased text: ' + replaceWhiteSpaces(text));