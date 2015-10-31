/*
 *  9.   Write a program that extracts from a given text
 *       all palindromes, e.g. "ABBA", "lamal", "exe".
 */
function extractPalindroms(text) {
    var regExp = new RegExp('\\b\\w{2,}?\\b', 'g'),
        palindroms = [],
        i = 0,
        words = text.match(regExp);

    function isPalindrom(word) {
        var start = 0,
            end = word.length - 1;

        while ((end - start) > 0) {

            if (word[start] !== word[end]) {
                return false;
            }

            start += 1;
            end -= 1;
        }

        return true;
    }

    for (i = 0; i < words.length; i += 1) {
        if (isPalindrom(words[i])) {
            palindroms.push(words[i]);
        }
    }

    return palindroms;
}

var text = 'same ABBA anather one ala.' +
        'invalid invalid exe lamal';
var palindroms = extractPalindroms(text);
var i = 0;

jsConsole.writeLine('text: ' + text + '<br />');
jsConsole.writeLine('palindroms from text:');
for (i = 0; i < palindroms.length; i += 1) {
    jsConsole.writeLine(palindroms[i]);
}