/*
 *  8.   Write a JavaScript function that replaces in a HTML document
 *       given as string all the tags <a href="…">…</a> 
 *       with corresponding tags [URL=…]…[/URL]. Sample HTML fragment:
 */
function replaceATags(htmlString) {
    var result = htmlString.replace(new RegExp('</a>', 'g'), '[/URL]'),
        regExp = new RegExp('<a.*?>', 'g'),
        aTags = result.match(regExp),
        i = 0,
        newString = '';

    function createReplasedString(aTag) {
        var newStr = '[URL=',
            regExp = new RegExp('"(.+?)"', 'g'),

            // get href content whitout "" in group 1 (.+?)
            match = regExp.exec(aTag);

        newStr += match[1] + ']';

        return newStr;
    }

    // iterate over <a href="..."> tags in aTags array and create new tags [URL=...]
    for (i = 0; i < aTags.length; i += 1) {
        newString = createReplasedString(aTags[i]);
        result = result.replace(aTags[i], newString);
    }

    return result;
}

var htmlString = '<p>Please visit <a href="http://academy.telerik.com">our' +
        ' site</a> to choose a training course. Also visit ' +
        '<a href="www.devbg.org">our forum</a> to discuss the courses.</p>';
var replacedHtml = replaceATags(htmlString);

jsConsole.writeLine('replaced tags a:' + replacedHtml);
jsConsole.writeLine('to view full text open brouser consle');

console.log('replaced tags <a href="..."> and </a>');
console.log(replacedHtml);