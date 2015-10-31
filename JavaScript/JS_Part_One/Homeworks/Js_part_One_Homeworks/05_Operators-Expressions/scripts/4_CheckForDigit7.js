/*
 *   4. Write an expression that checks for given integer
 *      if its third digit (right-to-left) is 7. E. g. 1732 -> true. 
 */
var number = 1709;

// calculations
var numberDevideHundred = Math.floor(number / 100);
var digit = numberDevideHundred % 10;
var isSeven = digit === 7 ? true : false;

jsConsole.writeLine(number + " is third digit 7: " + isSeven);