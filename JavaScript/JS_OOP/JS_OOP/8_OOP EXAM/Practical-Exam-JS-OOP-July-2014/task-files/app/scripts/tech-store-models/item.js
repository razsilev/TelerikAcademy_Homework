/// <reference path="../libs/require.js" />
define(function () {
    var Item = (function () {
        var itemTypes = {
            'accessory': true,
            'smart-phone': true,
            'notebook': true,
            'pc': true,
            'tablet': true
        },
        MIN_NAME_LENGTH = 6,
        MAX_NAME_LENGTH = 40;

        function Item(type, name, price) {
            this.setType(type);
            this.setName(name);
            this.setPrice(price);
        }

        Item.prototype = {
            setType: function (type) {
                if (itemTypes[type]) {
                    this.type = type;
                } else {
                    throw new TypeError('Invalid type for item');
                }
            },
            setName: function (name) {
                if (MIN_NAME_LENGTH <= name.length && name.length <= MAX_NAME_LENGTH) {
                    this.name = name;
                } else {
                    throw new TypeError('Invalid name length for item');
                }
            },
            setPrice: function (price) {
                if (price >= 0) {
                    this.price = price;
                } else {
                    throw new TypeError('Price can not be negative.');
                }
            }
        };

        return Item;
    }());

    return Item;
});