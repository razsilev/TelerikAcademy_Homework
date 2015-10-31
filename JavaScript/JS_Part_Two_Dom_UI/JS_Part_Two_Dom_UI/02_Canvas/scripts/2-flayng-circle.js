var canvas = document.getElementById('theCanvas');
var context = canvas.getContext('2d');
var x = 10;
var y = 200;
var speedPower = 1;
var speedX = speedPower;
var speedY = -(speedPower);
var twoPI = Math.PI * 2;
var corection = 7;


context.fillStyle = '#fff';
context.lineWidth = 2;
context.fillRect(0, 0, canvas.width, canvas.height);
context.strokeRect(1, 1, canvas.width -2, canvas.height - 2);
context.fillStyle = '#55f';

function frame() {

    if (x <= corection) {
        speedX = speedPower;
    }

    if (x >= canvas.width - corection) {
        speedX = -(speedPower);
    }

    if (y <= corection) {
        speedY = speedPower;
    }

    if (y >= canvas.height - corection) {
        speedY = -(speedPower);
    }

    context.clearRect(x - 5, y - 5, 10, 10);

    x += speedX;
    y += speedY;

    context.beginPath();
    context.arc(x, y, 5, 0, twoPI);
    context.fill();

    requestAnimationFrame(frame);
}

frame();
