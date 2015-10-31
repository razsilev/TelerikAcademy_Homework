// bonus task
function c(n){a=[],n*=1;return n?a[n]=(4*n-2)*c(n-1)/(n+1):.5}

console.dir(c(7));

// task 3

function solve(args) {
    var keyValueModel = {},
        htmlLines = [],
        word = '',
        inTag = false,
        templateName = '',
        templateContent = '';
        isInTemplate = false;
        templates = {},
        result = '';
        

    // fill keyValueModel
    function fillObjectModel(args) {
        var keyValueModel = {},
            i,
            key,
            value,
            tokens,
            otherTokens,
            numberOfKeyValueLines = args[0] * 1;

        for (i = 1; i <= numberOfKeyValueLines; i += 1) {
            tokens = args[i].split('-');
            key = tokens[0].trim();

            if (tokens[1].indexOf(';', 0) >= 0) {
                // array
                otherTokens = tokens[1].split(';');
                value = otherTokens;

            } else {
                value = tokens[1].trim();
            }

            keyValueModel[key] = value;
        }

        return keyValueModel;
    }

    keyValueModel = fillObjectModel(args);
    htmlLines = args.slice(((args[0] * 1) + 1));
    
    for (var row = 0; row < htmlLines.length; row++) {
        var currentRow = htmlLines[row];

        for (var col = 0; col < currentRow.length; col++) {
            var symbol = currentRow[col];

            if (isInTemplate) {
                templateContent += symbol;

                if (symbol === '<') {
                    var a;
                }

                if (symbol === '<' && currentRow[col + 3] === '-') {
                    isInTemplate = false;

                    templates[templateName] = templateContent;
                }
            }


            if (symbol === '<') {
                inTag = true;
                continue;
            }

            
            if (inTag) {
                word += symbol;

                if (word.trim() === 'nk-template') {

                    while (symbol !== '"') {
                        symbol = currentRow[col];                      
                        col += 1;
                    }

                    symbol = currentRow[col];
                    word = '';

                    while (symbol !== '"') {
                        word += symbol;
                        symbol = currentRow[col];
                        col += 1;
                    }

                    templateName = word.substring(1, word.length);

                    isInTemplate = true;
                    row += 1;
                    col = 0
                }
            }

            
        }
    }



    var a;
    console.log(result);
}

var args = [
    '6',
    'title-Telerik Academy',
    'showSubtitle-true',
    'subTitle-Free training',
    'showMarks-false',
    'marks-3;4;5;6',
    'students-Ivan;Gosho;Pesho',
    '42',
    '<nk-template name="menu">',
    '    <ul id="menu">',
    '        <li>Home</li>',
    '        <li>About us</li>',
    '    </ul>',
    '</nk-template>',
    '<nk-template name="footer">',
    '    <footer>',
    '        Copyright Telerik Academy 2014',
    '    </footer>',
    '</nk-template>',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '    <title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '    <nk-template render="menu" />',
    '',
    '    <h1><nk-model>title</nk-model></h1>',
    '    <nk-if condition="showSubtitle">',
    '        <h2><nk-model>subTitle</nk-model></h2>',
    '        <div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
    '    </nk-if>',
    '',
    '    <ul>',
    '        <nk-repeat for="student in students">',
    '            <li>',
    '                <nk-model>student</nk-model>',
    '            </li>',
    '            <li>Multiline <nk-model>title</nk-model></li>',
    '        </nk-repeat>',
    '    </ul>',
    '    <nk-if condition="showMarks">',
    '        <div>',
    '            <nk-model>marks</nk-model> ',
    '        </div>',
    '    </nk-if>',
    '',
    '    <nk-template render="footer" />',
    '</body>',
    '</html>', ];

//console.dir(solve(args));