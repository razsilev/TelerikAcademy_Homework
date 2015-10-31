/// <reference path="libs/underscore.js" />
(function () {
    var animals = [{
        species: 'cat',
        type: 'street',
        numberOfLegs: 4
    }, {
        species: 'dog',
        type: 'street',
        numberOfLegs: 4
    }, {
        species: 'fish',
        type: 'sharan',
        numberOfLegs: 0
    }, {
        species: 'monkey',
        type: 'shinpanze',
        numberOfLegs: 2
    }, {
        species: 'snake',
        type: 'cobra',
        numberOfLegs: 0
    }, {
        species: 'cat',
        type: 'siams',
        numberOfLegs: 4
    }, {
        species: 'fish',
        type: 'kit',
        numberOfLegs: 0
    }, {
        species: 'dog',
        type: 'lasy',
        numberOfLegs: 4
    }, {
        species: 'monkey',
        type: 'mangusta',
        numberOfLegs: 2
    }, {
        species: 'spider',
        type: 'tarantul',
        numberOfLegs: 8
    }, {
        species: 'snake',
        type: 'smok',
        numberOfLegs: 0
    }],
        numberOfLegs;

    console.log('-------- Origin: ---------');
    _.each(animals, function (animal) {
        console.log(animal.species + ' (' + animal.type + ') -> ' +
                    animal.numberOfLegs + ' legs');
    });

    function calculaneLegs(animals) {
        var numberOfLegs;

        numberOfLegs = _.reduce(animals, function (memo, animal) {
            return memo + animal.numberOfLegs;
        }, 0);

        return numberOfLegs;
    }

    numberOfLegs = calculaneLegs(animals);

    console.log('\n-------- Result: ---------');
    console.log('animals legs are: ' + numberOfLegs);
}());