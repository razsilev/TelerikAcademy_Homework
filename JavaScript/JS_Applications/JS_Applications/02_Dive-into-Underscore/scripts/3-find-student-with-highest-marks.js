/// <reference path="libs/underscore.js" />
(function () {
    var students = [{
        fname: 'Gosho',
        lname: 'Peshov',
        age: 16,
        marks: []
    }, {
        fname: 'Emo',
        lname: 'Nikolov',
        age: 19,
        marks: []
    }, {
        fname: 'Stefi',
        lname: 'Stamatov',
        age: 23,
        marks: []
    }, {
        fname: 'Pesho',
        lname: 'Goshov',
        age: 18,
        marks: []
    }, {
        fname: 'Mimi',
        lname: 'Mileva',
        age: 20,
        marks: []
    }, {
        fname: 'Stefan',
        lname: 'Stefanov',
        age: 24,
        marks: []
    }, {
        fname: 'Angel',
        lname: 'Angelov',
        age: 26,
        marks: []
    }],
        studentWithHighestMarks;

    function fillMarks(students) {
        var studentsWithMarks;

        studentsWithMarks = _.map(students, function (student) {
            var numberOfMarks = 3,
                i;

            for (i = 0; i < numberOfMarks; i += 1) {
                student.marks.push(Math.floor((Math.random() * 5) + 2));
            }

            return student;
        });

        return studentsWithMarks;
    }

    students = fillMarks(students);

    console.log('-------- Origin: ---------');
    _.each(students, function (student) {
        console.log(student.fname + ' - ' + student.lname + ' -> ' + student.marks);
    });

    function findStudentWithHighestMarks(students) {
        var studentWithHighestMarks;

        studentWithHighestMarks = _.max(students, function (student) {
            var sum = 0,
                numberOfMarcs = student.marks.length;

            sum = _.reduce(student.marks, function (memo, num) {
                return memo + num;
            }, 0);

            return sum;
        });

        return studentWithHighestMarks;
    }

    studentWithHighestMarks = findStudentWithHighestMarks(students);

    console.log('------- Result: student with max marks ----------');
    console.log(studentWithHighestMarks.fname + ' - ' +
                studentWithHighestMarks.lname + ' -> ' +
                studentWithHighestMarks.marks);
}());