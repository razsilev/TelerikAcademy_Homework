/*
 *  3.  Write a function that finds all the occurrences of word in a text
 *      The search can case sensitive or case insensitive
 *      Use function overloading
 */
function wordOccurrences(text, word, isCaseSensitive) {
    var regExp = {};

    // case sensitive RegExp
    if (isCaseSensitive === true) {
        regExp = new RegExp('\\b' + word + '\\b', 'g');
    } else {
        /*
         *  Advanced Searching With Flags
         *  gi - flags
         *  g - Global search.
         *  i - Case-insensitive search.
         */
        regExp = new RegExp('\\b' + word + '\\b', 'gi');
    }

    return text.match(regExp).length;
}

var text = 'ala bala. Ala haha "ala".';
var word = 'Ala';
var caseSensitive = false;

jsConsole.writeLine('text: ' + text);
jsConsole.writeLine('searched word: ' + word);
jsConsole.writeLine('case sensitive search: ' + caseSensitive);
jsConsole.writeLine('number of occurrences: ' +
    wordOccurrences(text, word, caseSensitive));