$.fn.dropdown = function () {
    var optionMenu = $(this);
    optionMenu.css('display', 'none');

    var containerDiv = $('<div/>').addClass('dropdown-list-container');
    var dropdownUL = $('<ul/>').css('display', 'none');
    var option = optionMenu.children('option');
    var currentSelection = $('<div/>').text(optionMenu.children('option').first().text()).addClass('current');

    currentSelection.on('click', function () {
        if (dropdownUL.css('display') == 'block') {
            dropdownUL.css('display', 'none');
        } else {
            dropdownUL.css('display', 'block');
        }
    });
    
    option.each(function () {
        var dateValueIndex = $(this).val();
        var li = $('<li/>').addClass("dropdown-list-option")
                           .attr('data-value', dateValueIndex)
                           .text($(this).text())
                           .on('click', function () {
                               optionMenu.find("option:selected").removeAttr("selected");
                               optionMenu.find('option[value="' + dateValueIndex + '"]').attr("selected", "true");
                               currentSelection.text($(this).text());
                               dropdownUL.css('display', 'none');
                           });

        dropdownUL.append(li);
    });

    containerDiv.append(currentSelection);
    containerDiv.append(dropdownUL);
    containerDiv.insertAfter(optionMenu);
}

$('#dropdown').dropdown();