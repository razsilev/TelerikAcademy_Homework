var canvasRender = (function myfunction() {
    var Drawer = (function () {
        function CanvasDrawer(canvasID) {
            this.canvas = document.getElementById(canvasID);
            //this.snakeElementToDelete;
            this.COLOR_FIELD = '#0e0';
            this.COLOR_SNAKE = '#00f';
            this.COLOR_FOOD = '#f00';
            this.COLOR_FIALD_ELEMENTS = '#a0f';
            this.isSnakeDrawingForFirstTime = true;
            this.context = this.canvas.getContext('2d');
            this.context.lineWidth = 5;
            this.context.strokeStyle = '#f00';
            this.context.fillStyle = '#00f';
        }

        var drawCircle = function (x, y, radius, context) {
            context.beginPath();
            context.arc(x, y, radius, 0, 2 * Math.PI);
            context.fill();
        };

        CanvasDrawer.prototype = {
            drawSnake: function (snakeElements) {
                var i,
                    lastElement;

                if (this.isSnakeDrawingForFirstTime) {
                    // draw snake for first time
                    this.isSnakeDrawingForFirstTime = false;
                    this.snakeElementToDelete = {
                        x: snakeElements[0].x,
                        y: snakeElements[0].y,
                        radius: snakeElements[0].radius + 1
                    };
                    this.context.fillStyle = this.COLOR_SNAKE;

                    for (i = 0; i < snakeElements.length; i += 1) {
                        drawCircle(snakeElements[i].x, snakeElements[i].y, snakeElements[i].radius, this.context);
                    }
                } else {
                    // delete last snake element
                    this.context.fillStyle = this.COLOR_FIELD;
                    drawCircle(this.snakeElementToDelete.x, this.snakeElementToDelete.y, this.snakeElementToDelete.radius, this.context);
                    this.snakeElementToDelete = {
                        x: snakeElements[0].x,
                        y: snakeElements[0].y,
                        radius: snakeElements[0].radius + 1
                    };

                    // draw first element of snake
                    this.context.fillStyle = this.COLOR_SNAKE;
                    lastElement = snakeElements[snakeElements.length - 1];
                    drawCircle(lastElement.x, lastElement.y, lastElement.radius, this.context);
                }
            },
            drawFood: function (food) {
                this.context.fillStyle = this.COLOR_FOOD;
                drawCircle(food.x, food.y, food.radius, this.context);
            },
            deleteFood: function (food) {
                this.context.fillStyle = this.COLOR_SNAKE;
                drawCircle(food.x, food.y, food.radius, this.context);
            },
            drawField: function (elementsOnField) {
                var i;

                this.context.fillStyle = this.COLOR_FIELD;
                this.context.fillRect(0, 0, this.context.canvas.width, this.context.canvas.height - 30);

                this.context.strokeStyle = this.COLOR_FIALD_ELEMENTS;
                this.context.font = '6pt Calibri';

                for (i = 0; i < elementsOnField.length; i += 1) {
                    this.context.strokeText('Y', elementsOnField[i].x, elementsOnField[i].y + 5);
                }

            },
            drawGameResults: function (text) {
                var textX = 10,
                    resultFormX = 0,
                    resultFormY = 370,
                    resultFormHeight = 30;


                this.context.fillStyle = '#000';
                this.context.fillRect(resultFormX, resultFormY, this.context.canvas.width, resultFormHeight);

                this.context.fillStyle = '#fff';
                this.context.font = '16pt Arial';

                this.context.fillText(text, textX, this.context.canvas.height - 10);
            }
        };

        return CanvasDrawer;
    }());

    return {
        Drawer: Drawer
    };
}());