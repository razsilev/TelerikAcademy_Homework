/// <reference path="item.js" />
/// <reference path="require-js-2-1-14.js" />
define(['item'], function (Item) {
    var ItemColection = (function () {
        function ItemColection(templateID, templateContentObjArray) {
            this.templateContentObjArray = templateContentObjArray;
            this.itemCreator = new Item(templateID);
        }

        ItemColection.prototype.getElements = function () {
            var elements = [],
                element,
                i;

            for (i = 0; i < this.templateContentObjArray.length; i += 1) {
                element = this.itemCreator.getElement(this.templateContentObjArray[i]);
                elements.push(element);
            }

            return elements;
        }

        return ItemColection;
    }());

    return ItemColection;
});