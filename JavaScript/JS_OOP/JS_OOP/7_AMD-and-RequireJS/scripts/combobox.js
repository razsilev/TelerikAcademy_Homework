/// <reference path="colection.js" />
/// <reference path="jquery-2-1-1.js" />
/// <reference path="item.js" />
/// <reference path="require-js-2-1-14.js" />
define(['colection', 'jQuery'], function (Colection) {
    var Combobox = (function () {
        function Combobox(templateID, templateContentObjArray) {
            this.colection = new Colection(templateID, templateContentObjArray);
        }

        Combobox.prototype.create = function () {
            //TODO implement combo box functionality.
            var elements = this.colection.getElements(),
                $mainDiv = $('<div />'),
                i,
                $currentElement,
                $selektedOptions,
                $optionContainer = $('<div />').addClass('option'),
                $selectedElementContainer = $('<div />').addClass('selected-container');
            
            $optionContainer.css('position', 'absolute');
            $selectedElementContainer.append(elements[0]);
            $mainDiv.append($selectedElementContainer);

            for (i = 0; i < elements.length; i += 1) {
                $currentElement = $(elements[i]);
                $optionContainer.append($currentElement);
            }

            $optionContainer.hide();
            $mainDiv.append($optionContainer);

            $selektedOptions = $optionContainer.children();

            $selectedElementContainer.on('click', function () {
                $optionContainer.show();
            });

            $selektedOptions.on('click', function () {
                var element = this.cloneNode(true);
                $selectedElementContainer.children('div').remove();
                $selectedElementContainer.append(element);
                $optionContainer.hide();
            });

            return $mainDiv;
        }

        return Combobox;
    }());

    return Combobox;
});