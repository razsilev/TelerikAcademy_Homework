function createDivs(numberOfDivs) {
    var divs = document.createDocumentFragment();

    function randomNumberGenerator(from, to) {
        to += 1;
        var number = (Math.random() * (to - from) + from) | 0;

        return number;
    }

    function colorAsStringGenerator() {
        var color = 'rgb(';

        color += randomNumberGenerator(0, 255);
        color += ', ' + randomNumberGenerator(0, 255);
        color += ', ' + randomNumberGenerator(0, 255) + ')';

        return color;
    }

    for (var i = 0; i < numberOfDivs; i += 1) {
        var top = randomNumberGenerator(10, 500) + 'px';
        var left = randomNumberGenerator(10, 800) + 'px';
        var width = randomNumberGenerator(20, 100) + 'px';
        var height = randomNumberGenerator(20, 100) + 'px';
        var borderRadius = randomNumberGenerator(0, 60) + 'px';
        var borderWidth = randomNumberGenerator(1, 20) + 'px';
        var backgroundColor = colorAsStringGenerator();
        var borderColor = colorAsStringGenerator();
        var fontColor = colorAsStringGenerator();
        var text = 'div';
        var div = document.createElement('div');

        div.style.padding = randomNumberGenerator(5, 10) + 'px';
        div.style.position = 'absolute';
        div.style.top = top;
        div.style.left = left;
        div.style.width = width;
        div.style.height = height;
        div.style.borderRadius = borderRadius;
        div.style.border = borderWidth + ' solid ' + borderColor;
        div.style.backgroundColor = backgroundColor;
        div.style.color = fontColor;
        div.innerHTML = text;


        divs.appendChild(div);
    }

    return divs;
}

document.body.appendChild(createDivs(5));

setInterval(function () {

    while (document.body.firstChild) {
        document.body.removeChild(document.body.firstChild);
    }

    var divs = createDivs(5);
    document.body.appendChild(divs);
}, 2500);
