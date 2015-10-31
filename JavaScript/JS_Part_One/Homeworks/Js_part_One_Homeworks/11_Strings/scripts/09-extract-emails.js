/*
 *  9.   Write a function for extracting all email addresses
 *       from given text. All substrings that match the format
 *       <identifier>@<host>…<domain> should be recognized as emails.
 *       Return the emails as array of strings.
 */
function extractEmails(text) {
    var regExp = new RegExp('\\b\\w+@\\w+[.]\\w{2,4}\\b', 'g'),
        mails = text.match(regExp);

    return mails;
}

var text = 'same mails ala_bala75@abc.com anather one test@host.dom.' +
        'invalid invalid invalid three@gosho.pesho mail';
var mails = extractEmails(text);

jsConsole.writeLine('text: ' + text + '<br />');
jsConsole.writeLine('mails from text:');
for (var i = 0; i < mails.length; i += 1) {
    jsConsole.writeLine(mails[i]);
}