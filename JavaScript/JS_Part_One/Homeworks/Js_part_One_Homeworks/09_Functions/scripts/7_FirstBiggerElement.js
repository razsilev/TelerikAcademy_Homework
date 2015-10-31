/*
 *   7.   Write a function that returns the index of the first element
 *        in array that is bigger than its neighbors, or -1, 
 *        if there’s no such element.
 *        - Use the function from the previous exercise.
 */
function isNeighborsSmaller(array, elementIndex) {
    var number = array[elementIndex];

    if ((array[elementIndex - 1] < number) && (array[elementIndex + 1] < number) &&
            (elementIndex > 0) && (elementIndex < (array.length - 1))) {
        return true;
    }

    return false;
}

function getIndexOfFirstBiggerElement(array) {
    var index = -1,
        length = array.length - 1,
        i;

    for (i = 0; i < length; i += 1) {
        if (isNeighborsSmaller(array, i)) {
            return i;
        }
    }

    return index;
}

var array = [1, 3, 4, 8, 17];

jsConsole.writeLine('array elements: [' + array + ']');
jsConsole.writeLine('index of first element with smaller neighbors is: ' +
    getIndexOfFirstBiggerElement(array));