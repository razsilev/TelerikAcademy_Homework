/*
 *   3.   Write a function that makes a deep copy of an object
 *        The function should work for both primitive and reference types
 */
function clone(obj) {
    if (obj === null || typeof (obj) !== 'object') {
        return obj;
    }

    var copy = {},
        key;
    for (key in obj) {
        // recursiv copy propertis, because they olso can be objects
        copy[key] = clone(obj[key]);
    }

    return copy;
}

function car(owner, brand, model) {
    return {
        owner: owner,
        brand: brand,
        model: model,
        toString: function () {
            return this.owner + ': ' + this.brand + ' - ' + this.model;
        }
    };
}

function person(firstName, lastName) {
    return {
        firstName: firstName,
        lastName: lastName,
        toString: function () {
            return this.firstName + ' ' + this.lastName;
        }
    };
}

var number = 5;
var numberCopy = clone(number);
var owner = person('Petar', 'Petrov');
var car = car(owner, 'lada', 'samara');
var carCopy = clone(car);

jsConsole.writeLine('number: ' + number);
jsConsole.writeLine('numberCopy: ' + numberCopy);
jsConsole.writeLine('car: ' + car);
jsConsole.writeLine('carCopy: ' + carCopy);
jsConsole.writeLine('');
jsConsole.writeLine('change original objects');
jsConsole.writeLine('');

// change original objects
number = 6;
car.model = 'niva';
car.owner.firstName = 'Georgy';

jsConsole.writeLine('number: ' + number);
jsConsole.writeLine('numberCopy: ' + numberCopy);
jsConsole.writeLine('car: ' + car);
jsConsole.writeLine('carCopy: ' + carCopy);