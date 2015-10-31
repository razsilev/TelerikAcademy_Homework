//  3.  By given an array of students, generate a table that represents these students
//      Each student has first name,last name and grade
//      Use jQuery

var students = [
            {
                firstName: 'Pesho',
                lastName: 'Petrov',
                grade: 4
            },
            {
                firstName: 'Stamat',
                lastName: 'Goshev',
                grade: 5
            },
            {
                firstName: 'Mimi',
                lastName: 'Mileva',
                grade: 6
            }];
var container = $('#table-container');

function createTable(containerElement, students) {
    var container = $(containerElement);
    var table = $('<table />').css('border-collapse', 'collapse');

    function createTableRow() {
        return $('<tr />');
    }

    function createTableData(content) {
        var td = $('<td />').html(content).css('border', '1px solid #000');

        return td;
    }

    function createTableHeader(content) {
        var td = $('<th />').html(content).css('border', '1px solid #000');

        return td;
    }

    createTableRow().append(createTableHeader('First name'))
        .append(createTableHeader('Last name'))
        .append(createTableHeader('Grade'))
        .appendTo(table);

    for (var i = 0; i < students.length; i++) {
        createTableRow().append(createTableData(students[i].firstName))
        .append(createTableData(students[i].lastName))
        .append(createTableData(students[i].grade))
        .appendTo(table);
    }

    container.append(table);
}

createTable(container, students);