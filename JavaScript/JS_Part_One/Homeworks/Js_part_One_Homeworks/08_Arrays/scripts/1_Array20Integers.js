/*
 *   1.   Write a script that allocates array of 20 integers and 
 *        initializes each element by its index multiplied by 5.
 *        Print the obtained array on the console.
 */
var array = new Array(20);
var length;
var i;

for (i = 0, length = array.length; i < length; i += 1) {
    array[i] = i * 5;
}

for (i = 0, length = array.length; i < length; i += 1) {
    jsConsole.writeLine(array[i]);
}