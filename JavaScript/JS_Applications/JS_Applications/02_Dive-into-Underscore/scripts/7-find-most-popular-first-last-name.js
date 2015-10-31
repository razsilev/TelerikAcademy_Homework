/// <reference path="libs/underscore.js" />
(function () {
    var people = [{
        fname: 'Gosho',
        lname: 'Ahgelov'
    }, {
        fname: 'Emo',
        lname: 'Peshev'
    }, {
        fname: 'Gosho',
        lname: 'Peshev'
    }, {
        fname: 'Niki',
        lname: 'Peshev'
    }, {
        fname: 'Stamat',
        lname: 'Mital'
    }, {
        fname: 'Stamat',
        lname: 'Peshev'
    }, {
        fname: 'Gosho',
        lname: 'Geshev'
    }, {
        fname: 'Pesho',
        lname: 'Peshev'
    }, {
        fname: 'Gosho',
        lname: 'Kenov'
    }, {
        fname: 'Doncho',
        lname: 'Minkov'
    }],
        popularNames;

    console.log('-------- Origin: ---------');
    _.each(people, function (human) {
        console.log(human.fname + ' -> ' +
                    human.lname);
    });

    function findMostPopularFirstAndLastName(people) {
        var fname,
            lname,
            fnames,
            lnames;

        function findMostPopularName(names) {
            var groupedNames,
                groupWithMaxLength;

            groupedNames = _.groupBy(names, function (name) {
                return name;
            });

            groupWithMaxLength = _.max(groupedNames, function (groupe) {
                return groupe.length;
            });

            return groupWithMaxLength[0];
        }

        fnames = _.pluck(people, 'fname');
        fname = findMostPopularName(fnames);

        lnames = _.pluck(people, 'lname');
        lname = findMostPopularName(lnames);

        return {
            fname: fname,
            lname: lname
        };
    }

    popularNames = findMostPopularFirstAndLastName(people);

    console.log('\n-------- Result: ---------');
    console.log('Most popular first name is: ' + popularNames.fname);
    console.log('Most popular last name is: ' + popularNames.lname);
}());