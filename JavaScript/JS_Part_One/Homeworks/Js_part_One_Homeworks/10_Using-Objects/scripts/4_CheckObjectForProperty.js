/*
 *   4.  Write a function that checks if a given object contains a given property.
 */
function hasProperty(obj, property) {
    var properties = [],
        i = 0;

    if (typeof (obj) !== 'object') {
        return false;
    }

    properties = Object.getOwnPropertyNames(obj);
    for (i = 0; i < properties.length; i += 1) {
        if (properties[i] === property) {
            return true;
        }
    }

    return false;
}

var obj = Math;

jsConsole.writeLine('has Math property abs: ' + hasProperty(obj, 'abs'));
jsConsole.writeLine('has Math property length: ' + hasProperty(obj, 'length'));