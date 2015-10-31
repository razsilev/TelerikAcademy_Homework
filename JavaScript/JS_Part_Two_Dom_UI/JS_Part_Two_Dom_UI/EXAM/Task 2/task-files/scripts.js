$.fn.gallery = function (columns) {
    if (!columns) {
        columns = 4;
    }
    // napravi broq na kolonite!!!!
    var $galeryContainer = this;
    var $previousImage = $galeryContainer.find('#previous-image');
    var $currentImage = $galeryContainer.find('#current-image');
    var $nextImage = $galeryContainer.find('#next-image');
    var $galeryList = $galeryContainer.find('div.gallery-list');
    var $enlargedImagesContainer = $galeryContainer.find('.selected');
    var imagesCount = $galeryContainer.find('.image-container').length;
    var images = $galeryContainer.find('.image-container img');
    var currentImageIndex = 0;

    // set initial styles
    $previousImage.addClass('previous-image');
    $currentImage.addClass('current-image');
    $nextImage.addClass('next-image');
    $galeryContainer.addClass('gallery');
    $enlargedImagesContainer.hide();

    // set number of columns
    var imageContainerWidth = parseInt($($galeryContainer.find('.image-container')[0]).css('width'));
    var galeryContainerWidth = imageContainerWidth * columns + 10 * columns;
    $galeryContainer.css('width', galeryContainerWidth);

    $currentImage.on('click', function () {
        $galeryList.removeClass('blurred');
        $enlargedImagesContainer.hide();
    });

    $galeryContainer.on('click', '.image-container img', function () {
        var $clickedImg = $(this);
        // bloor images
        $galeryList.addClass('blurred');
        $enlargedImagesContainer.show();

        $currentImage.attr('src', $clickedImg.attr('src'));
        currentImageIndex = $clickedImg.attr('data-info') - 1;
        var nextIndex = currentImageIndex + 1;
        if (nextIndex >= imagesCount) {
            nextIndex = 0;
        }

        var prevIndex = currentImageIndex - 1;

        if (prevIndex < 0) {
            prevIndex = imagesCount - 1;
        }

        var srcnext = $(images[nextIndex]).attr('src');
        var srcPrev = $(images[prevIndex]).attr('src');

        $nextImage.attr('src', srcnext);

        $previousImage.attr('src', srcPrev);

    });

    $previousImage.on('click', function next() {
        currentImageIndex -= 1

        if (currentImageIndex < 0) {
            currentImageIndex = imagesCount - 1;
        }

        $currentImage.attr('src', $(images[currentImageIndex]).attr('src'));

        var nextIndex = currentImageIndex + 1;
        if (nextIndex >= imagesCount) {
            nextIndex = 0;
        }

        var prevIndex = currentImageIndex - 1;

        if (prevIndex < 0) {
            prevIndex = imagesCount - 1;
        }

        var srcnext = $(images[nextIndex]).attr('src');
        var srcPrev = $(images[prevIndex]).attr('src');

        $nextImage.attr('src', srcnext);

        $previousImage.attr('src', srcPrev);
    });

    $nextImage.on('click', function next() {
        currentImageIndex += 1

        if (currentImageIndex >= imagesCount) {
            currentImageIndex = 0;
        }

        $currentImage.attr('src', $(images[currentImageIndex]).attr('src'));

        var nextIndex = currentImageIndex + 1;
        if (nextIndex >= imagesCount) {
            nextIndex = 0;
        }

        var prevIndex = currentImageIndex - 1;

        if (prevIndex < 0) {
            prevIndex = imagesCount - 1;
        }

        var srcnext = $(images[nextIndex]).attr('src');
        var srcPrev = $(images[prevIndex]).attr('src');

        $nextImage.attr('src', srcnext);

        $previousImage.attr('src', srcPrev);
    });
};