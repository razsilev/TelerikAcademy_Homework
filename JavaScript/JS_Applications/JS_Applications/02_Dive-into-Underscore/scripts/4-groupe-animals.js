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
        groupedAnimals;

    console.log('-------- Origin: ---------');
    _.each(animals, function (animal) {
        console.log(animal.species + ' (' + animal.type + ') -> ' + animal.numberOfLegs + ' legs');
    });

    function groupAnimals(animals) {
        var speaces,
            sortedSpeaces;

        speaces = _.groupBy(animals, 'species');

        sortedSpeaces = _.sortBy(speaces, function (group) {
            return group[0].numberOfLegs;
        });
        
        return sortedSpeaces;
    }

    groupedAnimals = groupAnimals(animals);

    console.log('\n-------- Result: in groups ---------');
    _.each(groupedAnimals, function (group) {
        console.log('   ---- species: ' + group[0].species + ' ------');

        _.each(group, function (member) {
            console.log('member: ' + member.species +
                ' - type: "' + member.type +
                '" -> ' + member.numberOfLegs + ' legs');
        });
    });

}());