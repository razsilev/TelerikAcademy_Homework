var canvas = document.getElementById('theCanvas');
var context = canvas.getContext('2d');

context.fillStyle = 'rgb(80, 80, 80)';
context.fillRect(0, 0, canvas.width, canvas.height);

function toRadians(degrees) {
    return (degrees * Math.PI) / 180;
}

function drawHat(context) {
    // big elipsis
    context.strokeStyle = '#000';
    context.save();
    context.fillStyle = 'rgb(57, 102, 147)';

    context.scale(1, 0.2);
    context.beginPath();
    context.arc(70, 390, 55, 2 * Math.PI, 0, true);
    context.closePath();
    context.fill();

    context.fillStyle = 'rgb(57, 102, 147)';
    context.lineWidth = 2;
    context.stroke();


    context.restore();

    context.moveTo(95, 20);

    // draw cilinder
    context.fillStyle = 'rgb(57, 102, 147)';


    context.fillRect(45, 20, 50, 50);
    context.strokeRect(45, 20, 50, 50);


    context.save();
    context.beginPath();

    context.scale(1, 0.4);
    context.arc(70, 50, 25, 2 * Math.PI, 0, true);

    // bottom
    context.closePath();
    context.moveTo(45, 170);
    context.arc(70, 168, 25, Math.PI, 2 * Math.PI, true);

    context.fill();

    context.fillStyle = 'rgb(57, 102, 147)';
    context.lineWidth = 2;
    context.stroke();

    context.restore();
}

function drawHead(context, x, y) {
    context.save();
    context.fillStyle = 'rgb(144, 202, 215)';
    context.strokeStyle = 'rgb(36, 88, 100)';

    context.beginPath();
    context.arc(x, y, 45, 0, toRadians(360), false);
    context.lineWidth = 2;
    context.stroke();
    context.fill();

    // eyes
    context.save();
    // firsrt
    context.moveTo(x - 15, y - 15);
    context.scale(1, 0.6);
    context.arc(x - 25, y + 55, 10, 0, toRadians(360));
    // second
    context.moveTo(x + 20, y + 55);
    context.arc(x + 10, y + 55, 10, 0, toRadians(360));
    context.restore();
    context.stroke();

    context.save();
    context.fillStyle = 'rgb(16, 68, 80)';
    context.scale(0.5, 1);

    context.beginPath();
    context.arc(x + 13, y - 13, 5, 0, toRadians(360));
    context.arc(x + 83, y - 13, 5, 0, toRadians(360));
    context.fill();
    context.restore();

    // nouse
    context.beginPath();
    context.moveTo(x - 8, y - 12);
    context.lineTo(x - 18, y + 10);
    context.lineTo(x - 8, y + 10);
    context.stroke();

    // mauth
    context.save();
    context.rotate(toRadians(10));
    context.scale(1, 0.3);
    context.beginPath();
    context.arc(x + 15, y + 310, 17, 0, toRadians(360));
    context.lineWidth = 3;
    context.stroke();
    context.restore();

    context.restore();
}

function drawHeadWithHat(context) {
    drawHead(context, 70, 115);
    drawHat(context);
}

function drawBicycle(context, x, y) {

    function drawTire(context, x, y) {
        context.save();
        context.strokeStyle = '#08c';
        context.fillStyle = 'rgb(144, 202, 215)';
        context.lineWidth = 3;

        context.beginPath();
        context.arc(x, y, 60, 0, toRadians(360), false);

        context.fill();
        context.stroke();
        context.restore();
    }

    function drawSmallCitcle(context, x, y) {
        context.save();
        context.strokeStyle = '#08c';
        context.lineWidth = 3;

        context.beginPath();
        context.arc(x, y, 18, 0, toRadians(360), false);

        context.stroke();
        context.restore();
    }

    function drawFrames(context, x, y) {
        context.save();
        context.strokeStyle = '#08c';
        context.lineWidth = 3;

        context.beginPath();
        context.moveTo(x, y);
        context.lineTo(x + 110, y);
        context.lineTo(x + 50, y - 115);
        context.moveTo(x + 25, y - 115);
        context.lineTo(x + 75, y - 115);
        context.moveTo(x + 65, y - 85);
        context.lineTo(x, y);
        context.moveTo(x + 65, y - 85);
        context.lineTo(x + 210, y - 85);
        context.lineTo(x + 110, y);
        context.moveTo(x + 225, y);
        context.lineTo(x + 205, y - 130);
        context.moveTo(x + 155, y - 115);
        context.lineTo(x + 205, y - 130);
        context.moveTo(x + 235, y - 160);
        context.lineTo(x + 205, y - 130);
        context.moveTo(x + 80, y - 30);
        context.lineTo(x + 96, y - 13);
        context.moveTo(x + 120, y + 12);
        context.lineTo(x + 138, y + 30);

        context.stroke();
        context.restore();
    }

    drawTire(context, x + 60, y + 100);
    drawTire(context, x + 285, y + 100);
    drawFrames(context, x + 60, y + 100);
    drawSmallCitcle(context, x + 169, y + 99);

}

function drawHouse(context, x, y) {

    function roof(context, x, y) {
        context.save();
        
        context.beginPath();
        context.moveTo(x + 145, y);
        context.lineTo(x + 290, y + 160);
        context.lineTo(x, y + 160);
        context.closePath();

        context.fill();
        context.stroke();

        context.beginPath();
        context.moveTo(x + 200, y + 30)
        context.lineTo(x + 200, y + 120);
        context.moveTo(x + 235, y + 30)
        context.lineTo(x + 235, y + 120);

        context.fillRect(x + 200, y + 30, 35, 90);

        context.fill();
        context.stroke();
        
        context.save();
        context.scale(1, 0.3);
        context.beginPath();
        context.arc(x + 218, y + 123, 18, 0, toRadians(360));

        context.fill();
        context.stroke();
        context.restore();

        context.restore();
    }

    function windolw(context, x, y) {
        context.fillRect(x, y, 50, 30);
        context.fillRect(x, y + 33, 50, 30);
        context.fillRect(x + 53, y, 50, 30);
        context.fillRect(x + 53, y + 33, 50, 30);
    }

    function door(context, x, y) {
        context.save();
        context.save();
        context.scale(1, 0.5);
        context.beginPath();
        context.arc(x + 40, y + 325, 40, toRadians(-10), toRadians(190), true);
        context.stroke();
        context.restore();

        context.beginPath();
        context.moveTo(x, y + 15);
        context.lineTo(x, y + 100);
        context.moveTo(x + 79, y + 15);
        context.lineTo(x + 79, y + 100);
        context.moveTo(x + 40, y + 0);
        context.lineTo(x + 40, y + 100);

        context.stroke();

        context.beginPath();
        context.arc(x + 27, y + 70, 4, 0, toRadians(360));
        context.stroke();

        context.beginPath();
        context.arc(x + 52, y + 70, 4, 0, toRadians(360));
        context.stroke();

        context.restore();
    }

    function ahterParth(context, x, y) {

        context.save();
        
        context.fillRect(x, y + 162, 290, 215);
        context.strokeRect(x, y + 160, 290, 215);

        context.fillStyle = '#000';
        windolw(context, x + 20, y + 185);
        windolw(context, x + 160, y + 185);
        windolw(context, x + 160, y + 275);

        door(context, x + 30, y + 275);

        context.restore();
    }

    context.strokeStyle = '#000';
    context.fillStyle = 'rgb(151, 91, 91)';
    context.lineWidth = 3;

    roof(context, x, y);
    ahterParth(context, x, y);
}

drawHeadWithHat(context);
drawBicycle(context, 20, 250);
drawHouse(context, 450, 10);