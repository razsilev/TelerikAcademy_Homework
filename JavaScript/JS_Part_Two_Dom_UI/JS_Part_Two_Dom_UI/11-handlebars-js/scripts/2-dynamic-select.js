function createSelect(stemplateSelector, items) {
    var source = $(stemplateSelector).html(),
        template = Handlebars.compile(source),
        select = template({ items: items });

    return select;
}

var items = [{
    value: 1,
    text: 'One'
}, {
    value: 2,
    text: 'Two'
}, {
    value: 3,
    text: 'Three'
}, {
    value: 4,
    text: 'Four'
}, {
    value: 5,
    text: 'Five'
}, {
    value: 6,
    text: 'Six'
}, {
    value: 7,
    text: 'Seven'
}];

var select = createSelect('#select-template', items);
var container = $('#table-containet');

container.append(select);