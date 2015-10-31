/* 
*       2. Write a boolean expression that checks for given integer
*          if it can be divided (without remainder) by 7 and 5
*          in the same time.
*/
var number = 36;

if (number % (7 * 5) === 0) {
    jsConsole.writeLine(number +
        " - Can be divided (without remainder) by 7 and 5 in the same time.");
} else {
    jsConsole.writeLine(number + " / (5 or 7)  have remaider!");
}