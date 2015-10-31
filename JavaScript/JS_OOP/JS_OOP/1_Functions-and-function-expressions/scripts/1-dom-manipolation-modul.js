var domManipolation = (function () {
    var elementsToAppend = [],
        MAX_ELEMENTS_COUNT = 100;

    function addDomElement(element, parentNodeSelector) {
        var parent = document.querySelector(parentNodeSelector);

        if (parent) {
            parent.appendChild(element);
        }
    }

    function remove(selector) {
        var element = document.querySelector(selector);

        if (element) {
            element.parentElement.removeChild(element);
        }
    }

    function addEventListener(selector, eventType, eventHandler) {
        var elements = document.querySelectorAll(selector),
            i;

        for (i = 0; i < elements.length; i += 1) {
            document.addEventListener.call(elements[i], eventType, eventHandler);
        }
    }

    function getElements(selector) {
        var elements = document.querySelectorAll(selector);

        return elements;
    }

    function appendToBuffer(selector, element) {
        var elementToappend = {
            selector: selector,
            element: element
        },
            i;

        elementsToAppend.push(elementToappend);

        if (elementsToAppend.length >= MAX_ELEMENTS_COUNT) {

            for (i = 0; i < elementsToAppend.length; i += 1) {
                addDomElement(elementsToAppend[i].element, elementsToAppend[i].selector);
            }

            elementsToAppend.length = 0;
        }
    }

    return {
        appendChild: addDomElement,
        removeChild: remove,
        addHandler: addEventListener,
        getElements: getElements,
        appendToBuffer: appendToBuffer
    };
}());

var div = document.createElement('div');
div.innerText = 'text in div';

// add element
domManipolation.appendChild(div, 'body');

// remove element
setTimeout(function () {
    domManipolation.removeChild('div');
}, 2500);

var atherDiv = div.cloneNode(true);
atherDiv.innerText = 'ather div';
domManipolation.appendChild(atherDiv, 'body');

var secondDiv = div.cloneNode(true);
secondDiv.innerText = 'div open the console to see event click on div what it\'s doing';
domManipolation.appendChild(secondDiv, 'body');

// add event
domManipolation.addHandler('div', 'click', function () {
    console.log(this.innerText);
});

// get elements by css selector
console.log('lelements:');
console.dir(domManipolation.getElements('div'));

// appent 100 p elements
var paragraph = document.createElement('p');
var p;
var i;

for (i = 0; i < 100; i += 1) {
    p = paragraph.cloneNode(true);
    p.innerText = i + 1;
    domManipolation.appendToBuffer('body', p);
}