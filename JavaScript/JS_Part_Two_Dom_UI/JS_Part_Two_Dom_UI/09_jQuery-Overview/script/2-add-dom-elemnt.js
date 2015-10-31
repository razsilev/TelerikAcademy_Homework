// 2.  Using jQuery implement functionality to insert a
//     DOM element before or after another element

var div = document.getElementById('the-div');
var elementBefore = $('<div />').html('apend before');
var elementAfter = $('<div />').html('apend after');

function appendBefore(element, elementToAppend) {
    $(elementToAppend).insertBefore(element);
}

function appendAfter(element, elementToAppend) {
    $(elementToAppend).insertAfter(element);
}

setTimeout(function () {
    appendBefore(div, elementBefore);
    appendAfter(div, elementAfter);
}, 1500);