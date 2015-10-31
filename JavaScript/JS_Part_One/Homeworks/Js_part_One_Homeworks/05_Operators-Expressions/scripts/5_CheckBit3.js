/* 
*     5. Write a boolean expression for finding if the bit 3
*        (counting from 0) of a given integer is 1 or 0. 
*/
var number = 15;
var bitThree = ((1 << 3) & number) !== 0 ? 1 : 0;

jsConsole.writeLine(number + " to binary: " + number.toString(2));
jsConsole.writeLine("Bit 3 (counting from 0) in number " + number + " is: " + bitThree);
