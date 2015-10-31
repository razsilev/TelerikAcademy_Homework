/*
 *   6.   Write a function that checks if the element
 *        at given position in given array of integers
 *        is bigger than its two neighbors (when such exist).
 */
function isNeighborsSmaller(array, elementIndex) {
    var number = array[elementIndex];

    if ((array[elementIndex - 1] < number) && (array[elementIndex + 1] < number) &&
            (elementIndex > 0) && (elementIndex < (array.length - 1))) {
        return true;
    }

    return false;
}

var array = [1, 6, 4, 18, 17];
var index = 3;

jsConsole.writeLine('is element at index ' + index + ' bigger then its two neighbors: ' +
    isNeighborsSmaller(array, index));