var ShapesDrawer = (function myfunction() {
    function CanvasDrawer(canvasID) {
        var context,
            canvas = document.getElementById(canvasID);

        context = canvas.getContext('2d');

        context.lineWidth = 5;
        context.strokeStyle = '#f00';
        context.fillStyle = '#00f';

        this.drawRect = function (x, y, width, height) {
            context.rect(x, y, width, height);
            context.fill();
            context.stroke();
            context.stroke();
        };

        this.drawLine = function (fromX, fromY, toX, toY) {
            context.beginPath();
            context.moveTo(fromX, fromY);
            context.lineTo(toX, toY);
            context.stroke();
        };

        this.drawCircle = function (fromX, fromY, radius) {
            context.beginPath();
            context.arc(fromX, fromY, radius, 0, 2 * Math.PI);
            context.fill();
            context.stroke();
        };
    }

    return CanvasDrawer;
}());

var myDrawer = new ShapesDrawer('the-canvas');

myDrawer.drawRect(30, 30, 100, 70);
myDrawer.drawRect(150, 30, 100, 70);
myDrawer.drawRect(150, 120, 100, 70);

myDrawer.drawCircle(400, 110, 100);

var otherDrawer = new ShapesDrawer('other-canvas');
otherDrawer.drawLine(350, 50, 100, 200);
otherDrawer.drawLine(350, 50, 600, 200);

myDrawer.drawLine(400, 250, 100, 250);