function rotatedDivs(number, time, x, y, radius) {

    function randomNumberGenerator(from, to) {
        to += 1;
        var number = (Math.random() * (to - from) + from) | 0;

        return number;
    }

    function createDivs(numberOfDivs) {
        var divs = document.createDocumentFragment();

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
            div.className = 'rotation';


            divs.appendChild(div);
        }

        return divs;
    }

    function calcCirclePoint(center, radius, angle) {
        var radians = angle * Math.PI / 180;
        var x = (center.x + radius * Math.sin(radians)) | 0;
        var y = (center.y + radius * Math.cos(radians)) | 0;

        return {
            x: x,
            y: y
        };
    }

    var divs = createDivs(number);
    var divsArray = divs.childNodes;
    var circleCenterPoint = {
        x: x,
        y: y
    };

    for (var i = 0; i < number; i += 1) {
        divsArray[i].angle = randomNumberGenerator(0, 360);
        divsArray[i].angleIncrease = randomNumberGenerator(2, 6);

        var point = calcCirclePoint(circleCenterPoint, radius, divsArray[i].angle);

        divsArray[i].style.left = point.x + 'px';
        divsArray[i].style.top = point.y + 'px';
    }

    document.body.appendChild(divs);

    divsArray = document.getElementsByClassName('rotation');

    setInterval(function () {

        for (var i = 0; i < number; i += 1) {

            divsArray[i].angle += divsArray[i].angleIncrease;

            if (divsArray[i].angle > 360) {
                divsArray[i].angle = 0;
            }

            var point = calcCirclePoint(circleCenterPoint, radius, divsArray[i].angle);

            divsArray[i].style.left = point.x + 'px';
            divsArray[i].style.top = point.y + 'px';
        }

    }, time);

}

var numberOfDivs = 5,
    sleapTime = 100,
    x = 400,
    y = 300,
    radius = 200;

rotatedDivs(numberOfDivs, sleapTime, x, y, radius);
