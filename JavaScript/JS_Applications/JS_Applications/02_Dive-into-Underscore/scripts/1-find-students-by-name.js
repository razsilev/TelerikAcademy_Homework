/// <reference path="libs/underscore.js" />
(function () {
    var students = [{
        fname: 'Gosho',
        lname: 'Peshov',
        age: 19
    }, {
        fname: 'Emo',
        lname: 'Nikolov',
        age: 19
    }, {
        fname: 'Stefi',
        lname: 'Stamatov',
        age: 19
    }, {
        fname: 'Pesho',
        lname: 'Goshov',
        age: 19
    }, {
        fname: 'Mimi',
        lname: 'Mileva',
        age: 19
    }, {
        fname: 'Stefan',
        lname: 'Stefanov',
        age: 19
    }, {
        fname: 'Angel',
        lname: 'Angelov',
        age: 19
    }],
        sortedStudents;

    console.log('-------- Origin: ---------');
    _.each(students, function (student) {
        console.log(student.fname + ' - ' + student.lname);
    });

    function findStudentsWhitLessFirstName(students) {
        var studentsWithGreaterFName,
            sortedStudents;

        studentsWithGreaterFName = _.filter(students, function (student) {
            return student.fname.toLowerCase().localeCompare(student.lname.toLowerCase()) < 0;
        });

        sortedStudents = _.sortBy(studentsWithGreaterFName, function (first) {
            var firstStudentFullName = first.fname + first.lname;

            return firstStudentFullName.toLowerCase();
        }).reverse();

        return sortedStudents;
    }

    sortedStudents = findStudentsWhitLessFirstName(students);

    console.log('------- Result: ----------');
    _.each(sortedStudents, function (student) {
        console.log(student.fname + ' - ' + student.lname);
    });
}());