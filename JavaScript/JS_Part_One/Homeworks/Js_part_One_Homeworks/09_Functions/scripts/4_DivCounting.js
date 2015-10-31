/*
 *  4.  Write a function to count the number of divs on the web page.
 */
function divCount(text) {
    var regExp = {};

    regExp = new RegExp('<div(.*?)>', 'g');

    return text.match(regExp).length;
}

var text = '<html><head><body><div id="wrapper"><div></div></div></body></head></html>';

console.log('text: ' + text);
jsConsole.writeLine('number of divs: ' + divCount(text));