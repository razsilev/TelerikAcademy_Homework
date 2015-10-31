/*
 *  4.   Write a script that finds the lexicographically
 *       smallest and largest property in document, 
 *       window and navigator objects.
 */
var property;
var minPropInDocument = 'zzz';
var maxPropInDocument = 'aaa';
var minPropInWindow = 'zzz';
var maxPropInWindow = 'aaa';
var minPropInNavigator = 'zzz';
var maxPropInNavigator = 'aaa';

for (property in document) {
    if (minPropInDocument.localeCompare(property) > 0) {
        minPropInDocument = property;
    }

    if (maxPropInDocument.localeCompare(property) < 0) {
        maxPropInDocument = property;
    }
}

for (property in window) {
    if (minPropInWindow.localeCompare(property) > 0) {
        minPropInWindow = property;
    }

    if (maxPropInWindow.localeCompare(property) < 0) {
        maxPropInWindow = property;
    }
}

for (property in navigator) {
    if (minPropInNavigator.localeCompare(property) > 0) {
        minPropInNavigator = property;
    }

    if (maxPropInNavigator.localeCompare(property) < 0) {
        maxPropInNavigator = property;
    }
}

jsConsole.writeLine('smallest property in document is: ' + minPropInDocument);
jsConsole.writeLine('smallest property in window is: ' + minPropInWindow);
jsConsole.writeLine('smallest property in navigator is: ' + minPropInNavigator);
jsConsole.writeLine('largest property in document is: ' + maxPropInDocument);
jsConsole.writeLine('largest property in window is: ' + maxPropInWindow);
jsConsole.writeLine('largest property in navigator is: ' + maxPropInNavigator);