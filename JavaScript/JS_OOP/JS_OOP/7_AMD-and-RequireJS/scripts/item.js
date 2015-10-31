/// <reference path="jquery-2-1-1.js" />
/// <reference path="handlebars-v1.3.0.js" />
define(['handlebars', 'jQuery'], function () {
    var Item = (function () {
        function Item(templateID) {
            this.templateString = $(templateID).html();
            this.template = Handlebars.compile(this.templateString);
        }

        Item.prototype.getElement = function (templateContentObj) {
            var html = this.template(templateContentObj);

            return html;
        }

        return Item;
    }());

    return Item;
});