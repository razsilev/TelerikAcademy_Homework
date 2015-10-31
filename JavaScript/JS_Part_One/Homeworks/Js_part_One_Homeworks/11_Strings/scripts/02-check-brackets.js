/*
 *  2.   Write a JavaScript function to check if in a given
 *       expression the brackets are put correctly.
 *       Example of correct expression: ((a+b)/5-d).
 *       Example of incorrect expression: )(a+b)).
 */
function checkBrackets(expression) {
    var numberOfOpenBrackets = 0,
        i = 0,
        length = expression.length,
        areBracketsOk = true;

    for (i = 0; i < length; i += 1) {

        if (numberOfOpenBrackets <= 0 && expression[i] === ')') {
            areBracketsOk = false;
            break;
        }

        if (expression[i] === '(') {
            numberOfOpenBrackets += 1;
        } else if (expression[i] === ')') {
            numberOfOpenBrackets -= 1;
        }
    }

    if (numberOfOpenBrackets > 0) {
        areBracketsOk = false;
    }

    return areBracketsOk;
}

var expressin = '((a+b)/5-d)'; // true

// test case:
//expressin = ')((a+b)/5-d)'; // false
//expressin = '((a+b)/5-d))'; // false
//expressin = '((a+b)(/5-d)'; // false

jsConsole.writeLine('expression: ' + expressin);
jsConsole.writeLine('are brackets correct: ' + checkBrackets(expressin));