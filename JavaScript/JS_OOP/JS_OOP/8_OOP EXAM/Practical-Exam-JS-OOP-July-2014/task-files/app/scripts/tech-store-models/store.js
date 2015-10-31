/// <reference path="item.js" />
/// <reference path="../libs/require.js" />
define(['tech-store-models/item'], function (Item) {
    var Store = (function () {
        var MIN_NAME_LENGTH = 6,
            MAX_NAME_LENGTH = 30,
            MOBILES_SEARCHED_TYPES = ['smart-phone', 'tablet'],
            SMART_PHONE_SERCHED_TYPS = ['smart-phone'],
            COMPUTERS_SERCHED_TYPS = ['pc', 'notebook'];

        function Store(name) {
            this.setName(name);
            this._items = [];
        }

        function sortByName(a, b) {
            if (a.name.toLowerCase() > b.name.toLowerCase()) {
                return 1;
            }
            if (a.name.toLowerCase() < b.name.toLowerCase()) {
                return -1;
            }

            // a must be equal to b
            return 0;
        }

        function getItemsByTyps(arr, typs) {
            var i,
                j,
                result = [];

            for (i = 0; i < arr.length; i += 1) {
                for (j = 0; j < typs.length; j += 1) {

                    if (arr[i].type === typs[j]) {
                        result.push(arr[i]);
                        break;
                    }
                }
            }

            return result;
        }

        Store.prototype = {
            setName: function (name) {
                if (MIN_NAME_LENGTH <= name.length && name.length <= MAX_NAME_LENGTH) {
                    this.name = name;
                } else {
                    throw new TypeError('Invalid store name length');
                }
            },
            addItem: function (item) {
                if (item instanceof (Item)) {
                    this._items.push(item);
                } else {
                    throw new TypeError('item mast be ot type Item');
                }

                return this;
            },
            getAll: function () {
                // sorted by name
                var storeItems = this._items.slice(0),
                    sortedItems = storeItems.sort(sortByName);

                return sortedItems;
            },
            getSmartPhones: function () {
                var smartPhones,
                    sortedSmartPhones;

                smartPhones = getItemsByTyps(this._items, SMART_PHONE_SERCHED_TYPS);

                sortedSmartPhones = smartPhones.sort(sortByName);

                return sortedSmartPhones;
            },
            getMobiles: function () {
                var mobiles,
                    sortedMobiles;

                mobiles = getItemsByTyps(this._items, MOBILES_SEARCHED_TYPES);

                sortedMobiles = mobiles.sort(sortByName);

                return sortedMobiles;
            },
            getComputers: function () {
                var computers,
                    sortedComputers;

                computers = getItemsByTyps(this._items, COMPUTERS_SERCHED_TYPS);

                sortedComputers = computers.sort(sortByName);

                return sortedComputers;
            },
            filterItemsByType: function (type) {
                var items,
                    sortedItems;

                items = getItemsByTyps(this._items, [type]);

                sortedItems = items.sort(sortByName);

                return sortedItems;
            },
            filterItemsByPrice: function (option) {
                var minPrice = 0,
                    maxPrice = Number.MAX_VALUE,
                    array = [],
                    i,
                    sortedArray;

                if (option) {
                    minPrice = option.min || minPrice;
                    maxPrice = option.max || maxPrice;
                }

                for (i = 0; i < this._items.length; i += 1) {
                    if (minPrice <= this._items[i].price && this._items[i].price <= maxPrice) {
                        array.push(this._items[i]);
                    }
                }

                sortedArray = array.sort(function (a, b) {
                    return a.price - b.price;
                });

                return sortedArray;
            },
            countItemsByType: function () {
                var typeItemsCount = {},
                    i;

                for (i = 0; i < this._items.length; i += 1) {

                    if (typeItemsCount[this._items[i].type]) {
                        typeItemsCount[this._items[i].type] += 1;
                    } else {
                        typeItemsCount[this._items[i].type] = 1;
                    }
                }

                return typeItemsCount;
            },
            filterItemsByName: function (partOfName) {
                var array = [],
                    i,
                    currentItemName,
                    searchedString = partOfName.toLowerCase(),
                    sortedArray;

                for (i = 0; i < this._items.length; i += 1) {
                    currentItemName = this._items[i].name.toLowerCase();

                    if (currentItemName.indexOf(searchedString) >= 0) {
                        array.push(this._items[i]);
                    }
                }

                sortedArray = array.sort(sortByName);

                return sortedArray;
            }
        };

        return Store;
    }());

    return Store;
});