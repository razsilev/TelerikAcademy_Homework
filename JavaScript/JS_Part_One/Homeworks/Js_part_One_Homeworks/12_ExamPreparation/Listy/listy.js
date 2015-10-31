function solve(args) {
    var lines = [],
        str,
        variables = {},
        i,
        programResultVariableName = 'result variable',
        executeFunction = {
            sum: function (numbers) {
                var i,
                    sum = 0;

                for (i = 0; i < numbers.length; i += 1) {
                    sum += numbers[i];
                }

                return sum;
            },
            min: function (numbers) {
                return Math.min.apply(null, numbers);
            },
            avg: function (numbers) {
                var sum = this.sum(numbers),
                    avg = sum / numbers.length;

                return Math.floor(avg);
            },
            max: function (numbers) {
                return Math.max.apply(null, numbers);
            }
        };

    function removeUnnecessaryWhiteSpace(str) {
        var result = '',
            i;

        str = str.trim();

        for (i = 0; i < str.length; i += 1) {
            if (str[i] === ' ') {
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

    function fillLines(args) {
        var lines = [],
            currentLine;

        for (i = 0; i < args.length - 1; i += 1) {
            currentLine = removeUnnecessaryWhiteSpace(args[i]);

            if (currentLine.indexOf('def ', 0) >= 0) {
                currentLine = currentLine.substring(4, currentLine.length);
                lines.push(currentLine);
            }
        }

        // add last line
        lines.push(removeUnnecessaryWhiteSpace(args[args.length - 1]));

        return lines;
    }

    function createVariables(lines) {
        var variables = {},
            i,
            name,
            func,
            value,
            splitedString,
            otherSplitedString;

        function createVariableOvject(name, func, value) {
            return {
                name: name || '',
                func: func || '',
                value: value
            };
        }

        function stringValueToArray(variables, stringValue) {
            var values = [],
                i,
                currentString,
                variableValue,
                splitedString;

            splitedString = stringValue.split(',');

            for (i = 0; i < splitedString.length; i += 1) {
                currentString = splitedString[i].trim();

                if (isFinite(currentString) && currentString !== '') {
                    values.push(Number(currentString));
                } else {
                    variableValue = variables[currentString].value;
                    //Array.prototype.push.apply(values, variableValue);
                    values = values.concat(variableValue);
                }
            }

            return values;
        }

        //  stringValue = 1, 4, func3, 8, 3 ]
        function calculateVariableValue(variables, func, stringValue) {
            var values = [],
                i,
                currentString,
                variableValue,
                splitedString;

            //  remove ']'
            stringValue = stringValue.substring(0, stringValue.length - 1).trim();
            values = stringValueToArray(variables, stringValue);

            if (func !== '') {
                values = executeFunction[func](values);
            }

            return values;
        }

        for (i = 0; i < lines.length; i += 1) {
            splitedString = lines[i].split('[');

            if (splitedString[0].trim().indexOf(' ', 0) > 0) {
                otherSplitedString = splitedString[0].split(' ');

                name = otherSplitedString[0];
                func = otherSplitedString[1];
                value = calculateVariableValue(variables, func, splitedString[1].trim());

                variables[name] = createVariableOvject(name, func, value);
            } else if (executeFunction[splitedString[0].trim()] || splitedString[0].trim() === '') {
                // if splitedString contains only command name 
                // like "sum" or "max" or '', this is last row and result. 
                name = programResultVariableName;
                func = splitedString[0].trim();
                value = calculateVariableValue(variables, func, splitedString[1].trim());

                variables[name] = createVariableOvject(name, func, value);
            } else {
                name = splitedString[0].trim();
                func = '';
                value = calculateVariableValue(variables, func, splitedString[1].trim());

                variables[name] = createVariableOvject(name, func, value);
            }
        }

        return variables;
    }

    lines = fillLines(args);

    variables = createVariables(lines);

    if (variables[programResultVariableName].value instanceof Array) {
        return variables[programResultVariableName].value[0];
    }

    return variables[programResultVariableName].value;
}

var args = [
    'def func sum[5, 3, 7, 2, 6, 3]',
    'def func2 [5, 3, 7, 2, 6, 3]',
    'def func3 min[func2]',
    'def func4 max[5, 3, 7, 2, 6, 3]',
    'def func5 avg[5, 3, 7, 2, 6, 3]',
    'def func6 sum[func2, func3, func4 ]',
    'sum[func6, func4]'];

var args2 = [
    'def func sum [ 1 , 2 , 3 , -6 ]',
    'def newList [    func    ,   10, 1]',
    'def newFunc sum[func, 100, newList]',
    '[newFunc]'];

var args10 = [
    'def maxy max[100]',
    'def summary [0]',
    'combo [maxy, maxy,maxy,maxy, 5,6]',
    'summary sum[combo, maxy, -18000]',
    'def pe6o avg[summary,maxy]',
    'sum[7, pe6o]'];


//console.dir(solve(args)); // 42
//console.dir(solve(args2)); // 111
console.dir(solve(args10)); // 111