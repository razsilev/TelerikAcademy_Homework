/*
 *  1.   Write a function that returns the last digit of given
 *       integer as an English word.
 *       Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine"
 */
function lastDigitOfNumberToWord(number) {
    // convert to number
    var num = (number * 1),
        lastDigit = Math.floor(num % 10),
        word;

    if (isNaN(num)) {
        console.log('Error, number mast be integer.');
        return undefined;
    }

    switch (lastDigit) {
        case 0:
            word = 'Zero';
            break;
        case 1:
            word = 'One';
            break;
        case 2:
            word = 'Two';
            break;
        case 3:
            word = 'Three';
            break;
        case 4:
            word = 'Four';
            break;
        case 5:
            word = 'Five';
            break;
        case 6:
            word = 'Six';
            break;
        case 7:
            word = 'Seven';
            break;
        case 8:
            word = 'Eight';
            break;
        case 9:
            word = 'Nine';
            break;
        default:
            break;
    }

    return word;
}

var number = 558;

jsConsole.writeLine(number + ' last digit is: ' + lastDigitOfNumberToWord(number));