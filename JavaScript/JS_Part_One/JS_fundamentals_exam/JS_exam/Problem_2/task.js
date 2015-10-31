function solve(args) {
    var rows,
        cols,
        i,
        currentRow,
        currentCol,
        tokens,
        numberOfJumps = 0,
        sum = 0,
        visited = {},
        cellNumberValue,
        newRow,
        newCol,
        field = args.slice(1);
        movePosition = {
            '1': {
                row: -2,
                col: 1
            },
            '2': {
                row: -1,
                col: 2
            },
            '3': {
                row: 1,
                col: 2
            },
            '4': {
                row: 2,
                col: 1
            },
            '5': {
                row: 2,
                col: -1
            },
            '6': {
                row: 1,
                col: -2
            },
            '7': {
                row: -1,
                col: -2
            },
            '8': {
                row: -2,
                col: -1
            },
        };

    function calcCellNumberValue(row, col) {
        var value = 1 << row;

        value -= col;

        return value;
    }

    function isInField(row, col, rows, cols) {
        return (0 <= row && row < rows) && (0 <= col && col < cols);
    }

    tokens = args[0].split(' ');
    rows = tokens[0] * 1;
    cols = tokens[1] * 1;

    // set start position
    currentRow = rows - 1;
    currentCol = cols - 1;


    while (true) {
        
        if (visited[currentRow + ' ' + currentCol]) {
            return 'Sadly the horse is doomed in ' + numberOfJumps + ' jumps';
        }

        visited[currentRow + ' ' + currentCol] = true;

        if (!isInField(currentRow, currentCol, rows, cols)) {
            return 'Go go Horsy! Collected ' + sum + ' weeds';
        }

        numberOfJumps += 1;
        sum += calcCellNumberValue(currentRow, currentCol);

        newRow = movePosition[field[currentRow][currentCol]].row;
        newCol = movePosition[field[currentRow][currentCol]].col;

        currentRow += newRow;
        currentCol += newCol;
    }

}

var args = [
  '3 5',
  '54561',
  '43328',
  '52388',
];


console.dir(solve(args));