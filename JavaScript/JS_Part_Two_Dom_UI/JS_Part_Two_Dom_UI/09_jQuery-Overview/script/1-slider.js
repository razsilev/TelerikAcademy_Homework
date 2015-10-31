var index = -1;
var sliderItems = $(".sliderItem");

function next() {
    index++;
    if (index >= sliderItems.length) {
        index = 0;
    }
    sliderItems.hide();
    var nextItem = $(sliderItems[index]);
    nextItem.show();
}

function prev() {
    index--;
    if (index <= 0) {
        index = sliderItems.length - 1;
    }
    sliderItems.hide();
    var nextItem = $(sliderItems[index]);
    nextItem.show();
}

$("#next").on('click', next);

$("#prev").on('click', prev);

next();
setInterval(next, 2000);