/*
 *  7.  Write a script that parses an URL address given in the format:
 *      [protocol]://[server]/[resource]
 *		and extracts from it the [protocol], [server] and [resource] elements.
 *      Return the elements in a JSON object. For example from the URL
 *      http://www.devbg.org/forum/index.php
 */
function extractUrlElements(urlString) {
    var regExp = new RegExp('^(\\w+):\\/\\/(.+?)(\\/.*)', 'g'),
        match = regExp.exec(urlString),
        result = {
            protocol: match[1],
            server: match[2],
            resource: match[3],
            toString: function () {
                return 'protocol: ' + this.protocol + '<br />server: ' + this.server +
                    '<br />resurce: ' + this.resource;
            }
        };

    return result;
}

var urlString = 'http://www.devbg.org/forum/index.php';
var urlAsObject = extractUrlElements(urlString);

jsConsole.writeLine(urlAsObject.toString());