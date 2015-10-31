/*
 *  5.  Write a function that counts how many times
 *      given number appears in given array.
 *      Write a test function to check if the
 *      function is working correctly.
 */
function numbersAppearsInArray(array, number) {
    var count = 0,
        length = array.length,
        i = 0;

    for (i = 0; i < length; i += 1) {
        if (array[i] === number) {
            count += 1;
        }
    }

    return count;
}

function testNumbersAppearsInArray() {
    var result = '', //'All test pass.';
    // test 1
        array = [3, 3, 5, 5, 3, 8, 1],
        number = 3;
    if (numbersAppearsInArray(array, number) !== 3) {
        result += 'test 1 wrong answer / ';
    }

    // test 2
    array = [3, 3, 5, 5, 3, 8, 1];
    number = 72;
    if (numbersAppearsInArray(array, number) !== 0) {
        result += 'test 2 wrong answer / ';
    }

    // test 3
    array = [3, 3, 5, 5, 3, 8, 1];
    number = 1;
    if (numbersAppearsInArray(array, number) !== 1) {
        result += 'test 3 wrong answer / ';
    }

    // test 4
    array = [5, 5, 5, 5, 5, 5];
    number = 5;
    if (numbersAppearsInArray(array, number) !== 6) {
        result += 'test 4 wrong answer / ';
    }

    // test 5
    array = [];
    number = 1;
    if (numbersAppearsInArray(array, number) !== 0) {
        result += 'test 5 wrong answer / ';
    }

    if (result === '') {
        result = 'All test pass.';
    }

    return result;
}

jsConsole.writeLine('result from testing numbersAppearsInArray: ' +
    testNumbersAppearsInArray());