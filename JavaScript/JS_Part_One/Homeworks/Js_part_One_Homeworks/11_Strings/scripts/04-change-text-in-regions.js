/*
 *  4.   You are given a text. Write a function that changes the text in all regions:
 *       <upcase>text</upcase> to uppercase.
 *       <lowcase>text</lowcase> to lowercase
 *       <mixcase>text</mixcase> to mix casing(random)
 */
function executeCode(code) {
    var codeResult = '';

    function createCommandFinder() {
        return {
            startIndex: 0,
            firstCommandStartIndex: 0,
            isFirstExecution: true,
            findNextCommand: function findNextCommand(code) {
                var command = '',
                    i = 0,
                    j = 0,
                    upcase = '<upcase>',
                    lowcase = '<lowcase>',
                    mixcase = '<mixcase>',
                    endUpcase = '</upcase>',
                    endLowcase = '</lowcase>',
                    endMixcase = '</mixcase>';

                for (i = this.startIndex; i < code.length; i += 1) {
                    if (code[i] === '<') {

                        for (j = i; j < code.length; j += 1) {
                            command += code[j];

                            if (code[j] === '>') {
                                break;
                            }
                        }

                        if (command === upcase || command === lowcase || command === mixcase ||
                                command === endUpcase || command === endLowcase || command === endMixcase) {
                            if (this.isFirstExecution) {
                                this.firstCommandStartIndex = j - command.length + 1;
                                this.isFirstExecution = false;
                            }

                            break;
                        }

                        command = '';
                    }
                }

                this.startIndex = j + 1;
                return command;
            }
        };
    }

    function executingCommand(command, text) {
        var result = '';

        if (command === '<upcase>') {
            result = text.toUpperCase();
        } else if (command === '<lowcase>') {
            result = text.toLowerCase();
        } else if (command === '<mixcase>') {
            result = text.replace(new RegExp('\\w', 'g'), function (symbol) {
                var number = Math.random() * 10;

                // random number from 0 to 10  50% chance to upcase
                if (number > 5) {
                    symbol = symbol.toUpperCase();
                } else {
                    symbol = symbol.toLowerCase();
                }

                return symbol;
            });
        }

        return result;
    }

    function executefirstCommand(code) {
        var commandToExecute = '',
            commandToExecuteEnd = '',
            currentCommand = '',
            openCommandsCount = 0,
            oldString = '',
            strWithoutCommands = '',
            commandFinder = createCommandFinder();

        commandToExecute = commandFinder.findNextCommand(code);
        commandToExecuteEnd = '</' + commandToExecute.substring(1, commandToExecute.length);

        if (commandToExecute !== '') {
            openCommandsCount = 1;

            // find on current command, his close command
            while (openCommandsCount > 0) {
                currentCommand = commandFinder.findNextCommand(code);

                if (currentCommand === commandToExecute) {
                    openCommandsCount += 1;
                } else if (currentCommand === commandToExecuteEnd) {
                    openCommandsCount -= 1;
                } else if (currentCommand === '') {
                    // commandToExecute has not close command => error incorect command use
                    return code;
                }
            }

            oldString = code.substring(commandFinder.firstCommandStartIndex, commandFinder.startIndex);
            strWithoutCommands = oldString.replace(new RegExp('<((/?upcase)|(/?lowcase)|(/?mixcase))>', 'gi'), '');
            strWithoutCommands = executingCommand(commandToExecute, strWithoutCommands);

            code = code.replace(oldString, strWithoutCommands);
        }

        return code;
    }

    while (true) {
        codeResult = executefirstCommand(code);

        // Find first command and here close command, then execute it. Search next command and do the same.
        // Nested commands are removet without executing.
        // When execute command remove it from code and his length degreece.
        // When no more commands to execute codeResult.length === code.length
        if (codeResult.length === code.length) {
            return codeResult;
        }

        code = codeResult;
    }
}

var text = 'We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. ' +
    'We <mixcase>don\'t</mixcase> have ' +
    '<mixcase>' +
    '<lowcase>AAAAAanything <upcase>UUUUppppp</upcase> AAAAAanything</lowcase> AAAAAanything ' +
    '</mixcase>else.';

jsConsole.writeLine(executeCode(text));