/*
 *   3.  Try typeof on all variables you created.
 */
var array = [];
var coffees = ["French Roast", "Colombian", "Kona"];
var isTrue = true;
var isFalse = false;
var number = -5;
var hexNumber = 0x1123;
var floatNumber = 3.1415;
var foo = { a: "alpha", 2: "two" };
var object = {};
var string = 'same string.';
var quote = "He read \"The Cremation of Sam McGee\" by R.W. Service.";

jsConsole.writeLine('typeof array: ' + typeof array);
jsConsole.writeLine('typeof coffees: ' + typeof coffees);
jsConsole.writeLine('typeof isTrue: ' + typeof isTrue);
jsConsole.writeLine('typeof isFalse: ' + typeof isFalse);
jsConsole.writeLine('typeof number: ' + typeof number);
jsConsole.writeLine('typeof hexNumber: ' + typeof hexNumber);
jsConsole.writeLine('typeof floatNumber: ' + typeof floatNumber);
jsConsole.writeLine('typeof foo: ' + typeof foo);
jsConsole.writeLine('typeof object: ' + typeof object);
jsConsole.writeLine('typeof string: ' + typeof string);
jsConsole.writeLine('typeof quote: ' + typeof quote);