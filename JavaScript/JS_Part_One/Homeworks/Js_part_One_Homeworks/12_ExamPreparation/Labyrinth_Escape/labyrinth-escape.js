function solve(args) {
    var splitedString = args[0].split(' '),
        rows = splitedString[0] * 1, // number of rows in labyrinth
        cols = splitedString[1] * 1, // number of cols in labytinth
        currentRow,
        currentCol,
        sum = 0,
        pathLength = 0,
        visitedCells = {},
        numberOnPosition,
        labyrinth = args.splice(2),
        currentCommand,
        commands = {
            u: {
                row: -1,
                col: 0
            },
            r: {
                row: 0,
                col: 1
            },
            d: {
                row: 1,
                col: 0
            },
            l: {
                row: 0,
                col: -1
            }
        };

    // read start position
    splitedString = args[1].split(' ');
    currentRow = splitedString[0] * 1;
    currentCol = splitedString[1] * 1;

    // return number of current position. Example pos 0, 0 return 1
    function calcNumberOnPosition(row, col, cols) {
        return row * cols + col + 1;
    }

    function isInLabyrinth(row, col, rows, cols) {
        return (0 <= row && row < rows) && (0 <= col && col < cols);
    }

    while (true) {
        numberOnPosition = calcNumberOnPosition(currentRow, currentCol, cols);
        
        if (visitedCells[numberOnPosition]) {
            return 'lost ' + pathLength;
        }

        visitedCells[numberOnPosition] = true;

        sum += numberOnPosition;
        pathLength += 1;

        currentCommand = labyrinth[currentRow][currentCol];
        currentRow = currentRow + commands[currentCommand].row;
        currentCol = currentCol + commands[currentCommand].col;

        if (!isInLabyrinth(currentRow, currentCol, rows, cols)) {
            return 'out ' + sum;
        }
    }
}

var args = [
 "3 4",
 "1 3",
 "lrrd",
 "dlll",
 "rddd"];
var args2 = [
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "durlddud",
 "urrrldud",
 "ulllllll"];
var args3 = [
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "lurlddud",
 "urrrldud",
 "ulllllll"];

console.dir(solve(args)); // out 45
console.dir(solve(args2)); // lost 21
console.dir(solve(args3)); // out 442