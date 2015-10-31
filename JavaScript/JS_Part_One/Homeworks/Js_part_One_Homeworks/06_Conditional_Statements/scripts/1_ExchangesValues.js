/* 1.  Write an if statement that examines two integer variables 
       and exchanges their values if the first one is greater 
       than the second one.*/
var log = jsConsole.writeLine;
var first = 33;
var second = 5;

log("before:  first = " + first + "; second = " + second);

if (first > second) {
    var oldValue = first;
    first = second;
    second = oldValue;
}

log("after:  first = " + first + "; second = " + second);