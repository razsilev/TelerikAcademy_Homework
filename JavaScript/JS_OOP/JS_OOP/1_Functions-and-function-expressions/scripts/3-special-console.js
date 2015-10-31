var specialConsole = (function () {
    function write(args, log) {
        var i,
            searchedSubString,
            resultText = args[0].toString();

        if (args.length > 1) {

            for (i = 1; i < args.length; i += 1) {
                searchedSubString = '\\{' + (i - 1) + '\\}';
                resultText = resultText.replace(new RegExp(searchedSubString, 'g'),
                    args[i].toString());
            }
        }

        log(resultText);
    }

    function writeLine(text) {
        write(arguments, console.log.bind(console));
    }

    function writeError(text) {
        write(arguments, console.error.bind(console));
    }

    function writeWarning(text) {
        write(arguments, console.warn.bind(console));
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };
}());

specialConsole.writeLine('only Message: hello');
specialConsole.writeLine('{1} formated Message: {0}', 'hello', 15);

specialConsole.writeError('only writeError Message: hello');
specialConsole.writeError('{1} formated writeError Message: {0}', 'hello', 15);

specialConsole.writeWarning('only writeWarning Message: hello');
specialConsole.writeWarning('{1} formated writeWarning Message: {0}', 'hello', 15);