/*
 *  2.  Write a script that prints all the numbers from 1 to N, 
 *      that are not divisible by 3 and 7 at the same time.
 */
var length = 77,
    i;

for (i = 1; i <= length; i += 1) {
    if ((i % 21) !== 0) {
        jsConsole.writeLine(i);
    }
}