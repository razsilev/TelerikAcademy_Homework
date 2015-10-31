/* 8.  Write a script that converts a number in the range [0...999]
       to a text corresponding to its English pronunciation.
       Examples:
       0   -> "Zero"
       273 -> "Two hundred seventy three"
       400 -> "Four hundred"
       501 -> "Five hundred and one"
       711 -> "Seven hundred and eleven"*/
var log = jsConsole.writeLine;

function numberToEnglishText(number) {

    function unitsToText(units) {
        var text = "";

        switch (units) {
            case 1:
                text = "one";
                break;
            case 2:
                text = "two";
                break;
            case 3:
                text = "three";
                break;
            case 4:
                text = "four";
                break;
            case 5:
                text = "five";
                break;
            case 6:
                text = "six";
                break;
            case 7:
                text = "seven";
                break;
            case 8:
                text = "eight";
                break;
            case 9:
                text = "nine";
                break;
        }

        return text;
    }

    function numberFrom10To19ToText(units) {
        var text = "";

        switch (units) {
            case 0:
                text = "ten ";
                break;
            case 1:
                text = "eleven ";
                break;
            case 2:
                text = "twelve ";
                break;
            case 3:
                text = "thirteen ";
                break;
            case 4:
                text = "fourteen ";
                break;
            case 5:
                text = "fifteen ";
                break;
            case 6:
                text = "sixteen ";
                break;
            case 7:
                text = "seventeen ";
                break;
            case 8:
                text = "eighteen ";
                break;
            case 9:
                text = "nineteen ";
                break;
        }

        return text;
    }

    function tensToText(tens) {
        var text = "";

        switch (tens) {
            case 2:
                text = "twenty ";
                break;
            case 3:
                text = "thirty ";
                break;
            case 4:
                text = "forty ";
                break;
            case 5:
                text = "fifty ";
                break;
            case 6:
                text = "sixty ";
                break;
            case 7:
                text = "seventy ";
                break;
            case 8:
                text = "eighty ";
                break;
            case 9:
                text = "ninety ";
                break;
        }

        return text;
    }

    function hundredsToText(hundreds) {
        var text = "";

        switch (hundreds) {
            case 1:
                text = "one hundred ";
                break;
            case 2:
                text = "two hundred ";
                break;
            case 3:
                text = "three hundred ";
                break;
            case 4:
                text = "four hundred ";
                break;
            case 5:
                text = "five hundred ";
                break;
            case 6:
                text = "six hundred ";
                break;
            case 7:
                text = "seven hundred ";
                break;
            case 8:
                text = "eight hundred ";
                break;
            case 9:
                text = "nine hundred ";
                break;
        }

        return text;
    }

    if (number > 999 || number < 0 || typeof (number) !== 'number') {
        log("Given number (" + number + ") is out of range [0...999]");
        return;
    }

    if (parseInt(number, 10) !== parseFloat(number)) {
        log("Given number (" + number + ") is not an integer!");
        return;
    }

    var units = number % 10,
        tens = Math.floor((number % 100) / 10),
        hundreds = Math.floor((number % 1000) / 100),
        text = "",
        result;

    if (hundreds > 0) {
        text += hundredsToText(hundreds);

        // check if number range is [1...19]
        if ((number % 100 < 20) && (number % 100) !== 0) {
            text += "and ";
            // check if number range is [10, 20, 30, ..., 90]
        } else if ((tens > 0) && (units === 0)) {
            text += "and ";
        }
    }

    if (tens > 1) {
        text += tensToText(tens);
    }

    if (tens === 1) {
        text += numberFrom10To19ToText(units);
    } else {
        text += unitsToText(units);
    }

    if (number === 0) {
        log(number + " -> Zero");
    } else {
        result = text[0].toUpperCase() + text.substring(1, text.length);

        log(number + " -> " + result);
    }

}

numberToEnglishText(0);
numberToEnglishText(273);
numberToEnglishText(400);
numberToEnglishText(501);
numberToEnglishText(711);
log("");
numberToEnglishText(-160);
numberToEnglishText(560);
numberToEnglishText(485);
numberToEnglishText(13);
numberToEnglishText(1);
numberToEnglishText(999);
numberToEnglishText(101.34);
numberToEnglishText('Gosho');