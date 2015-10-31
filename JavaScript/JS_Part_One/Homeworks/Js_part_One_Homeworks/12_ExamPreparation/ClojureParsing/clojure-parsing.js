function solve(args) {
    var commands = [],
        resultVariableName = 'final command',
        variables = {},
        i,
        currentVariable,
        result,
        executeMathOperation = {
            '+': function (args) {
                var sum = 0,
                    i;

                for (i = 0; i < args.length; i += 1) {
                    sum += args[i];
                }

                return sum;
            },
            '-': function (args) {
                var result = args[0],
                    i;

                for (i = 1; i < args.length; i += 1) {
                    result -= args[i];
                }

                return result;
            },
            '*': function (args) {
                var result = args[0],
                    i;

                for (i = 1; i < args.length; i += 1) {
                    result *= args[i];
                }

                return result;
            },
            '/': function (args) {
                var result = args[0],
                    i;

                for (i = 1; i < args.length; i += 1) {
                    // mark devide by Zero as result null
                    if (args[i] === 0) {
                        result = null;
                        break;
                    }

                    result = Math.floor(result / args[i]);
                }

                return result;
            }
        };

    //  str = '+  func 2)'
    function calculateValue(str, variables) {
        var value,
            i,
            args = [],
            operation,
            tokens;

        str = str.replace(')', '');
        str = str.trim();
        tokens = str.split(' ');
        operation = tokens[0];

        for (i = 1; i < tokens.length; i += 1) {
            if (isFinite(tokens[i]) && tokens[i] !== '') {
                args.push(tokens[i] * 1);
            } else {
                var name = tokens[i];
                args.push(variables[tokens[i]].value);
            }
        }

        value = executeMathOperation[operation](args);

        return value;
    }

    function createVariableObject(name, value) {
        return {
            name: name,
            value: value
        };
    }

    function createVariable(command, variables) {
        var variable = {},
            tokens,
            varName,
            varOperation = '',
            varValue;

        tokens = command.split(' ');
        if (tokens.length === 2) {
            varName = tokens[0];

            if (isFinite(tokens[1]) && tokens[1] !== '') {
                varValue = tokens[1] * 1;
            } else {
                varValue = variables[tokens[1]].value;
            }

            variable = createVariableObject(varName, varValue);
        } else if (command[0] === '(') {
            varName = resultVariableName;
            varValue = calculateValue(command.substring(1), variables);

            variable = createVariableObject(varName, varValue);
        } else {
            tokens = command.split('(');
            varName = tokens[0].trim();
            varValue = calculateValue(tokens[1], variables);

            variable = createVariableObject(varName, varValue);
        }

        return variable;
    }

    function removeUnnecessaryWhiteSpace(str) {
        var result = '',
            i;

        str = str.trim();

        for (i = 0; i < str.length; i += 1) {
            if (str[i] === '(') {
                result += str[i];
                i += 1;

                while (str[i] === ' ') {
                    i += 1;
                }

                i -= 1;
            } else if (str[i] === ' ') {
                result += str[i];
                while (str[i] === ' ') {
                    i += 1;
                }

                i -= 1;
            } else {
                result += str[i];
            }
        }

        return result.trim();
    }

    function getCommands(args) {
        var i,
            commands = [],
            currentCommand;

        for (i = 0; i < args.length; i += 1) {
            currentCommand = args[i].trim();
            currentCommand = removeUnnecessaryWhiteSpace(currentCommand);

            if (currentCommand.indexOf('(def ') === 0) {
                currentCommand = currentCommand.substring(5, currentCommand.length - 1).trim();
                commands.push(currentCommand);
            }
        }

        i = args.length - 1;
        currentCommand = args[i].trim();
        currentCommand = removeUnnecessaryWhiteSpace(currentCommand);
        commands.push(currentCommand);

        return commands;
    }

    commands = getCommands(args);

    for (i = 0; i < commands.length; i += 1) {
        currentVariable = createVariable(commands[i], variables);

        if (currentVariable.value === null) {
            result = 'Division by zero! At Line:' + (i + 1);
            break;
        }

        variables[currentVariable.name] = currentVariable;
    }

    if (variables[resultVariableName]) {
        result = variables[resultVariableName].value;
    }

    return result;
}

var args = [
    '   (   def func 10 ) ',
    '(def newFunc (     +  func 2))',
    '(def sumFunc ( +   func func newFunc 0 0 0))',
    '   (   *   sumFunc   2  )   '];

var args2 = [
    '(def func (+ 5 2))',
    '(def func2 (/  func 5 2 1 0))',
    '(def func3 (/ func 2))',
    '(+ func3 func)'];

// Error in test11 number of open '(' are not equal to number of ')'
var test11 = [
    '(def joros 30)',
    '(def newFunc (-  101 10))',
    '(def tryFunc 500)',
    '(def tryFunc2 (+ 500 tryFunc )',  // <-----
    '(def tryFunc1 (+ 500 tryFunc2 )', // <-----
    '(/ newFunc  )'
];

console.dir(solve(args)); // 64
console.dir(solve(args2)); // Division by zero! At Line:2
console.dir(solve(test11)); // 91  