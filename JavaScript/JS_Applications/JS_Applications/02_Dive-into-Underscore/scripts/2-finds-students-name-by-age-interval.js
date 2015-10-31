/// <reference path="libs/underscore.js" />
(function () {
    var students = [{
        fname: 'Gosho',
        lname: 'Peshov',
        age: 16
    }, {
        fname: 'Emo',
        lname: 'Nikolov',
        age: 19
    }, {
        fname: 'Stefi',
        lname: 'Stamatov',
        age: 23
    }, {
        fname: 'Pesho',
        lname: 'Goshov',
        age: 18
    }, {
        fname: 'Mimi',
        lname: 'Mileva',
        age: 20
    }, {
        fname: 'Stefan',
        lname: 'Stefanov',
        age: 24
    }, {
        fname: 'Angel',
        lname: 'Angelov',
        age: 26
    }],
        studentsNames;

    console.log('-------- Origin: ---------');
    _.each(students, function (student) {
        console.log(student.fname + ' - ' + student.lname + ' -> ' + student.age);
    });

    function findStudentsInAgeInterval(students, from, to) {
        var filteredStudents,
            studentsNames;

        filteredStudents = _.filter(students, function (student) {
            return (from <= student.age) && (student.age <= to);
        });

        studentsNames = _.map(filteredStudents, function (student) {
            return {
                fname: student.fname,
                lname: student.lname
            };
        });

        return studentsNames;
    }

    studentsNames = findStudentsInAgeInterval(students, 18, 24);

    console.log('------- Result: 18 <= age <= 24 ----------');
    _.each(studentsNames, function (student) {
        console.log(student.fname + ' - ' + student.lname);
    });
}());