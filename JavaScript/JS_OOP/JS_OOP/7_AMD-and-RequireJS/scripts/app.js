/// <reference path="item.js" />
/// <reference path="combobox.js" />
/// <reference path="jquery-2-1-1.js" />
/// <reference path="require-js-2-1-14.js" />
(function () {
    require.config({
        paths: {
            "handlebars": "handlebars-v1.3.0",
            "jQuery": "jquery-2-1-1",
            "item": "item",
            "colection": "colection",
            "comboBox": "combobox"
        }
    });

    require(['comboBox', 'jQuery'], function (ComboBox) {
        var persons = [{
            id: 3,
            name: 'Maria',
            age: '15',
            avatarUrl: 'images/maria.png'
        }, {
            id: 1,
            name: 'pesho',
            age: '19',
            avatarUrl: 'images/pesho.png'
        }, {
            id: 2,
            name: 'gosho',
            age: '29',
            avatarUrl: 'images/gosho.png'
        }, {
            id: 3,
            name: 'Penka',
            age: '15',
            avatarUrl: 'images/penka.png'
        }, {
            id: 1,
            name: 'Stamat',
            age: '19',
            avatarUrl: 'images/stamat.png'
        }];

        var combobox = new ComboBox('#item-template', persons);

        var content = combobox.create();

        $('#container').append(content);

    });
}());