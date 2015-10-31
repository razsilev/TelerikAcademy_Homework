/* 5.  Write script that asks for a digit and depending on the input
       shows the name of that digit (in English) 
       using a switch statement.*/
var log = jsConsole.writeLine;
var digit = 5;

log("digit is: " + digit);
jsConsole.write("to english is: ");

switch (digit) {
    case 0:
        log("Zero");
        break;
    case 1:
        log("One");
        break;
    case 2:
        log("Two");
        break;
    case 3:
        log("Three");
        break;
    case 4:
        log("Four");
        break;
    case 5:
        log("Five");
        break;
    case 6:
        log("Six");
        break;
    case 7:
        log("Seven");
        break;
    case 8:
        log("Eight");
        break;
    case 9:
        log("Nine");
        break;
    default:
        log("The input is not a digit!");
        break;
}