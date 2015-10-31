/*
 *    1.  Assign all the possible JavaScript literals to different variables.
 */

// Array literals
var array = [];
var coffees = ["French Roast", "Colombian", "Kona"];

// Boolean literals
var isTrue = true;
var isFalse = false;

// Integers literals
var number = -5;
var hexNumber = 0x1123;

// Floating-point literals
/*
 *  A floating-point literal can have the following parts:

    A decimal integer which can be signed (preceded by "+" or "-"),
    A decimal point ("."),
    A fraction (another decimal number),
    An exponent.

    The exponent part is an "e" or "E" followed by an integer, 
    which can be signed (preceded by "+" or "-").
    A floating-point literal must have at least one digit and 
    either a decimal point or "e" (or "E").
    
    Some examples of floating-point literals are 3.1415, -3.1E12, .1e12, and 2E-12.
 */
var floatNumber = 3.1415;
var floatNumberExponentWord = -3.1E12;
var floatNumberExponentShort = 0.1e12;
var floatNumberExponentAther = 2E-12;

// Object literals
var object = {};
//var car = {
//    myCar: "Saturn",
//    getCar: CarTypes("Honda"),
//    special: Sales
//};

// Please note:
var foo = { a: "alpha", 2: "two" };
console.log(foo.a);    // alpha
//console.log(foo[2]);   // two
//console.log(foo.2);  // Error: missing ) after argument list
//console.log(foo[a]); // Error: a is not defined
//console.log(foo["a"]); // alpha
console.log(foo['2']); // two

// String literals
var string = 'same string.';
var quote = "He read \"The Cremation of Sam McGee\" by R.W. Service.";