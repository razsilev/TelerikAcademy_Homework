function solve(args) {
    var tokens = args[0].split(' '),
        rows = tokens[0] * 1,
        cols = tokens[1] * 1,
        currentRow,
        currentCol,
        visited = {},
        sumOfNumbers = 0,
        numbersOfJumps = 0,
        jumpsRows = [],
        jumpsCols = [],
        i,
        numberOnPosition;

    // calculate number in field on given position
    function calcNumberOnPosition(row, col, cols) {
        return row * cols + col + 1;
    }

    function isInField(row, col, rows, cols) {
        return (0 <= row && row < rows) && (0 <= col && col < cols);
    }

    // set start position
    tokens = args[1].split(' ');
    currentRow = tokens[0] * 1;
    currentCol = tokens[1] * 1;

    // fill two arrays whit jump position represented as number
    args = args.slice(2);
    var i;
    for (i = 0; i < args.length; i += 1) {
        tokens = args[i].split(' ');
        jumpsRows.push(tokens[0] * 1);
        jumpsCols.push(tokens[1] * 1);
    }

    // use 'i' to iterate over jumps arrays to get next position 
    // when i >= jumps arrays length i = 0 and jumps contine from there.
    i = 0;
    while (true) {
        numberOnPosition = calcNumberOnPosition(currentRow, currentCol, cols);

        // if position is visited jumps end.
        if (visited[numberOnPosition]) {
            return 'caught ' + numbersOfJumps;
        }

        visited[numberOnPosition] = true;

        numbersOfJumps += 1;
        sumOfNumbers += numberOnPosition;

        // calculate next rabbit position.
        currentRow += jumpsRows[i];
        currentCol += jumpsCols[i];

        i += 1;

        if (i >= jumpsRows.length) {
            i = 0;
        }

        // if position is outside of the field jumps end.
        if (!isInField(currentRow, currentCol, rows, cols)) {
            return 'escaped ' + sumOfNumbers;
        }
    }
}

var args = [
'6 7 3',
'0 0',
'2 2',
'-2 2',
'3 -1'
];

console.dir(solve(args));