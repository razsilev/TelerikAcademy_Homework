/*
 *  5.  Sorting an array means to arrange its elements in increasing order.
 *      Write a script to sort an array. Use the "selection sort" algorithm:
 *      Find the smallest element, move it at the first position,
 *      find the smallest from the rest, move it at the second position, etc.
 *      Hint: Use a second array.
 */
var array = [4, 3, 7, 5, 13, 8, 1];

function selectionSort(arrayOfNumbers) {
    var oldValue,
        i,
        j,
        minIndex,
        min,
        length = arrayOfNumbers.length;

    for (i = 0; i < length - 1; i += 1) {
        min = arrayOfNumbers[i];
        minIndex = i;

        for (j = i; j < length; j += 1) {
            if (min > arrayOfNumbers[j]) {
                min = arrayOfNumbers[j];
                minIndex = j;
            }
        }

        if (minIndex > i) {
            oldValue = arrayOfNumbers[i];
            arrayOfNumbers[i] = arrayOfNumbers[minIndex];
            arrayOfNumbers[minIndex] = oldValue;
        }
    }

    return arrayOfNumbers;
}

jsConsole.writeLine('array: [' + array + ']');
jsConsole.writeLine('sorted array: [' + selectionSort(array) + ']');