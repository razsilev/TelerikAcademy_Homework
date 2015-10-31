/*
 *  6.   Write a function that extracts the content of a html page
 *       given as text. The function should return anything that is in a tag,
 *       without the tags:
 */
function extractText(html) {
    var regExp = new RegExp('<.*?>', 'gi'),
        text = html.replace(regExp, '');

    return text;
}

var text = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';

// result:  Sample sitetextmore textand more...in body
jsConsole.writeLine('text without tags is:<br />' + extractText(text));