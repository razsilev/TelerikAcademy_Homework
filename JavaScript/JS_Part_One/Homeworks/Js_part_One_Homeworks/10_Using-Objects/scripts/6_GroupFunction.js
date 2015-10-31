/*
 *   6.   Write a function that groups an array of persons by age, 
 *        first or last name. The function must return an associative array,
 *        with keys - the groups, and values -arrays with persons in this groups
 *        Use function overloading (i.e. just one function)
 */
function group(persons, property) {
    var propValues = {},
        result = {},
        i = 0,
        length = persons.length,
        prop;

    // colect all values
    for (i = 0; i < length; i += 1) {
        if (!propValues[persons[i][property]]) {
            propValues[persons[i][property]] = undefined;
        }
    }

    for (prop in propValues) {
        result[prop] = [];

        for (i = 0; i < length; i += 1) {
            if (persons[i][property].toString() === prop) {
                result[prop].push(persons[i]);
            }
        }
    }

    return result;
}

function person(fName, lName, age) {
    return {
        fName: fName,
        lName: lName,
        age: age,
        toString: function () {
            return this.fName + ' ' + this.lName + ' ' + this.age;
        }
    };
}

function printGroup(groupToPrint) {
    var i;

    for (i in groupToPrint) {
        jsConsole.writeLine('groupe: ' + i);
        jsConsole.writeLine(groupToPrint[i].join('<br />'));
        jsConsole.writeLine('');
    }
}

var persons = [
    person('Gosho', 'Geshev', 21),
    person('Pesho', 'Petrov', 19),
    person('Stamat', 'Iliev', 28),
    person('Mimi', 'Mileva', 19),
    person('Gosho', 'Toshev', 28),
    person('Gosho', 'Angelov', 33),
    person('Mimi', 'Petrova', 28),
    person('Nikoleta', 'Emilova', 19)
];

var groupedByFname = group(persons, 'fName');
var groupedByAge = group(persons, 'age');

jsConsole.writeLine('persons grouped by fName:');
printGroup(groupedByFname);

jsConsole.writeLine('***********************************');
jsConsole.writeLine('persons grouped by age:');
printGroup(groupedByAge);