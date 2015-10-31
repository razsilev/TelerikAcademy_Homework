var movingShapes = (function () {
    var WIDTH = '80px',
        HEIGHT = '40px',
        MIN_BORDER = 2,
        MAX_BORDER = 6,
        div = document.createElement('div'),
        circularMovingDivs = [],
        rectangularMovingDivs = [],
        MOVE_SPEED = 1,
        container = document.body,
        center = {
            x: 550,
            y: 150
        },
        radius = 100;

    div.style.width = WIDTH;
    div.style.height = HEIGHT;
    div.style.position = 'absolute';
    div.style.top = '100px';
    div.style.left = '100px';

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

    function generateRandomOptions() {
        var borderWidth = randomNumberGenerator(MIN_BORDER, MAX_BORDER) + 'px',
            backgroundColor = colorAsStringGenerator(),
            fontColor = colorAsStringGenerator(),
            borderColor = colorAsStringGenerator();

        return {
            borderWidth: borderWidth,
            backgroundColor: backgroundColor,
            fontColor: fontColor,
            borderColor: borderColor
        };
    }

    function calcCirclePoint(center, radius, angle) {
        var radians = angle * Math.PI / 180,
            x = (center.x + radius * Math.sin(radians)) | 0,
            y = (center.y + radius * Math.cos(radians)) | 0;

        return {
            x: x,
            y: y
        };
    }

    function frame() {
        var i,
            left,
            top,
            circlePoint;

        // move in rectangular form divs
        for (i = 0; i < rectangularMovingDivs.length; i += 1) {
            left = parseInt(rectangularMovingDivs[i].div.style.left, 10);
            top = parseInt(rectangularMovingDivs[i].div.style.top, 10);

            if (left > 350) {
                rectangularMovingDivs[i].direction = 'd';
                rectangularMovingDivs[i].div.style.left = (left - MOVE_SPEED) + 'px';
            } else if (top > 250) {
                rectangularMovingDivs[i].direction = 'l';
                rectangularMovingDivs[i].div.style.top = (top - MOVE_SPEED) + 'px';
            } else if (left < 100) {
                rectangularMovingDivs[i].direction = 'u';
                rectangularMovingDivs[i].div.style.left = (left + MOVE_SPEED) + 'px';
            } else if (top < 100) {
                rectangularMovingDivs[i].direction = 'r';
                rectangularMovingDivs[i].div.style.top = (top + MOVE_SPEED) + 'px';
            }

            if (rectangularMovingDivs[i].direction === 'r') {
                rectangularMovingDivs[i].div.style.left = (left + MOVE_SPEED) + 'px';
            } else if (rectangularMovingDivs[i].direction === 'd') {
                rectangularMovingDivs[i].div.style.top = (top + MOVE_SPEED) + 'px';
            } else if (rectangularMovingDivs[i].direction === 'l') {
                rectangularMovingDivs[i].div.style.left = (left - MOVE_SPEED) + 'px';
            } else if (rectangularMovingDivs[i].direction === 'u') {
                rectangularMovingDivs[i].div.style.top = (top - MOVE_SPEED) + 'px';
            }
        }

        // move in circular form divs
        for (i = 0; i < circularMovingDivs.length; i += 1) {
            circlePoint =
                calcCirclePoint(center, radius, circularMovingDivs[i].angle + MOVE_SPEED);
            circularMovingDivs[i].div.style.top = circlePoint.y + 'px';
            circularMovingDivs[i].div.style.left = circlePoint.x + 'px';

            circularMovingDivs[i].angle += MOVE_SPEED;

            if (circularMovingDivs[i].angle > 360) {
                circularMovingDivs[i].angle = 0;
            }
        }

        requestAnimationFrame(frame);
    }

    function createMovingInRectangleDiv() {
        var options = generateRandomOptions(),
            currentDiv = div.cloneNode(true);

        currentDiv.style.border = options.borderWidth + ' solid ' + options.borderColor;
        currentDiv.style.backgroundColor = options.backgroundColor;
        currentDiv.style.color = options.fontColor;

        rectangularMovingDivs.push({
            div: currentDiv,
            direction: 'r'
        });
        container.appendChild(currentDiv);

        if (rectangularMovingDivs.length === 1) {
            frame();
        }
    }

    function createMovingInCircleDiv() {
        var options = generateRandomOptions(),
            currentDiv = div.cloneNode(true);

        currentDiv.style.border = options.borderWidth + ' solid ' + options.borderColor;
        currentDiv.style.backgroundColor = options.backgroundColor;
        currentDiv.style.color = options.fontColor;
        currentDiv.style.left = '500px';

        circularMovingDivs.push({
            div: currentDiv,
            angle: 0
        });
        container.appendChild(currentDiv);

        if (circularMovingDivs.length === 1) {
            frame();
        }
    }

    function add(movingType) {
        if (movingType === 'rect') {
            createMovingInRectangleDiv();
        } else {
            createMovingInCircleDiv();
        }
    }

    return {
        add: add
    };
}());

movingShapes.add('rect');
movingShapes.add('circle');

var addToCircleButton = document.getElementById('circle');
addToCircleButton.addEventListener('click', function () {
    movingShapes.add('circle');
});

var addToRectButton = document.getElementById('rect');
addToRectButton.addEventListener('click', function () {
    movingShapes.add('rect');
});