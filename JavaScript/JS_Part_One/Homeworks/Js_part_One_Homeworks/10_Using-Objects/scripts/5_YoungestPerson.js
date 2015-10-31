/*
 *  5.  Write a function that finds the youngest person
 *      in a given array of persons and prints his/hers full name
 *      Each person have properties firstname, lastname and age, as shown:
 *      var persons = [
 *          {firstname : "Gosho", lastname: "Petrov", age: 32}, 
 *          {firstname : "Bay", lastname: "Ivan", age: 81},…];
 */
function person(fName, lName, age) {
    return {
        fName: fName,
        lName: lName,
        age: age
    };
}

function printYoungestPerson(persons) {
    var youngestPersonIndex = 0,
        i = 1,
        length = persons.length,
        minAge = persons[youngestPersonIndex].age;
    for (i = 1; i < length; i += 1) {
        if (persons[i].age < minAge) {
            minAge = persons[i].age;
            youngestPersonIndex = i;
        }
    }

    jsConsole.writeLine('youngest person is: ' + persons[youngestPersonIndex].fName +
        ' ' + persons[youngestPersonIndex].lName);
}

var persons = [
    person('Gosho', 'Geshev', 21),
    person('Pesho', 'Petrov', 30),
    person('Stamat', 'Iliev', 28),
    person('Mimi', 'Mileva', 19),
    person('Nikoleta', 'Emilova', 24)
];

printYoungestPerson(persons);