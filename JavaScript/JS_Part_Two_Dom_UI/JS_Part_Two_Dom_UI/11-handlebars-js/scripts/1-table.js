var source = $('#table-template').html();
var template = Handlebars.compile(source);

var data = {
    lectures: [{
        number: '0',
        title: 'Course Intro',
        firstDate: 'Wed 18:00, 28-may-2014',
        secondDate: 'Thu 18:00, 29-may-2014'
    }, {
        number: '1',
        title: 'Document Object Model',
        firstDate: 'Wed 18:00, 28-may-2014',
        secondDate: 'Thu 18:00, 29-may-2014'
    }, {
        number: '3',
        title: 'HTML5 Canvas',
        firstDate: 'Wed 18:00, 29-may-2014',
        secondDate: 'Thu 18:00, 30-may-2014'
    }]
};

var table = template(data);
$('#table-containet').append(table);