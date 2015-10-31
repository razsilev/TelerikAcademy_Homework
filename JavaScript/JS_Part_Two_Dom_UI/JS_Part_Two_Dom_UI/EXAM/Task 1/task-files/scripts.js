function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector);

    var bigImageContainer = createImageContainer();

    var bigP = createParagraphContainer(items[0].title);

    bigImageContainer.appendChild(bigP);
    var bigImg = createImg(items[0].url);
    bigImg.style.width = '400px';
    bigImageContainer.appendChild(bigImg);

    container.appendChild(bigImageContainer);

    var slideImagesContainer = createSliderContent(items);

    container.appendChild(slideImagesContainer);

    var input = container.getElementsByClassName('input')[0];
    var choiseElements = container.getElementsByClassName('imageContainer');

    input.addEventListener('keyup', function () {
        var text = input.value;

        for (var i = 0; i < items.length; i++) {
            var p = choiseElements[i].firstChild;
            console.log(p);
        }

    });

    function createSliderContent(items) {
        var div = createImageContainer();
        div.appendChild(createParagraphContainer('Filter'));
        div.style.cssFloat = 'right';

        var input = document.createElement('input');
        input.type = 'text';
        input.className = 'input';
        div.appendChild(input);

        for (var i = 0; i < items.length; i++) {
            var imageContainer = createImageContainer();
            imageContainer.style.width = '200px';
            imageContainer.className = 'imageContainer';

            imageContainer.appendChild(createParagraphContainer(items[i].title));
            var img = createImg(items[i].url);
            img.style.width = '180px';

            img.addEventListener('click', function (ev) {
                bigImg.src = ev.toElement.attributes.src.nodeValue;
                var tttt = ev.toElement.parentElement.getElementsByTagName('p')[0];
                bigP.innerText = tttt.innerText;
            });

            imageContainer.appendChild(img);

            div.appendChild(imageContainer);
        }

        return div;
    }

    function createImageContainer() {
        var div = document.createElement('div');

        return div;
    }

    function createParagraphContainer(text) {
        var p = document.createElement('p');
        p.innerText = text;
        //p.style.textAlign = 'center';

        return p;
    }

    function createImg(src) {
        var img = document.createElement('img');
        img.src = src;

        return img;
    }

}