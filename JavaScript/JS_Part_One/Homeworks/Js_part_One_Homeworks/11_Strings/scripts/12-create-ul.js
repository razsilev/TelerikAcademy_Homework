function createPerson(name, age, sex) {
    return {
        name: name,
        age: age,
        sex: sex
    };
}

function generateList(people, template) {
    var resultList = '',
        regExp = new RegExp('-{(\\w+)}-', 'gi'),
        i;

    function replace() {
        var propertyName = arguments[1],
            peoplePropValue = people[i][propertyName];

        return peoplePropValue;
    }

    resultList += '<ul>';
    for (i = 0; i < people.length; i += 1) {
        resultList += '<li>';
        resultList += template.replace(regExp, replace);

        resultList += '</li>';
    }

    resultList += '</ul>';

    return resultList;
}

var people = [
    createPerson('Pesho', 84, 'male'),
    createPerson('Stamat', 75, 'male'),
    createPerson('Mimi', 85, 'female')
];

var template = document.getElementById('list-item').innerHTML;
var peopleList = generateList(people, template);

document.getElementById('people-list').innerHTML = peopleList;
console.log(peopleList);