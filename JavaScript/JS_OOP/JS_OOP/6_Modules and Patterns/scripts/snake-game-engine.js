/// <reference path="snake-game-render.js" />
var snakeEngine = (function myfunction() {
    var Engine = (function () {
        var GAME_FIELD_WIDTH = 60,
            GAME_FIELD_hEIGHT = 37,
            MARK_SNAKE = 's',
            MARK_FOOD = 'f',
            MARK_WALL = 'w',
            GAME_FIELD_SQUARE_WIDTH = 10, // pixels
            SNAKE_INITIAL_LENGTH = 5,
            generateSnake,
            pasteElementsInGameField,
            createFood,
            createFieldElements;

        function Engine(render) {
            var self = this,
                i;
            this.render = render;
            this.gameField = [];

            // init array
            for (i = 0; i < GAME_FIELD_hEIGHT; i += 1) {
                this.gameField.push([]);
            }

            this.snake = generateSnake(SNAKE_INITIAL_LENGTH, GAME_FIELD_SQUARE_WIDTH / 2);
            pasteElementsInGameField(this.snake.body, MARK_SNAKE, this.gameField);
            this.food = createFood(this.gameField);
            pasteElementsInGameField([this.food], MARK_FOOD, this.gameField);
            this.fieldElements = createFieldElements(this.gameField);
            pasteElementsInGameField(this.fieldElements, MARK_WALL, this.gameField);

            this.render.drawField(this.fieldElements);
            this.render.drawFood(this.food);
            this.render.drawSnake(this.snake.body);
            this.render.drawGameResults('Level 1                 Score 0                  [ESC] ... Quit');
            this.isEscapePressed = false;

            // posoki

            document.body.addEventListener('keydown', function (e) {
                var code = e.keyCode;
                //alert(code);

                if (code === 37 && self.snake.direction !== 'R') {
                    self.snake.direction = 'L';
                } else if (code === 38 && self.snake.direction !== 'D') {
                    self.snake.direction = 'U';
                } else if (code === 39 && self.snake.direction !== 'L') {
                    self.snake.direction = 'R';
                } else if (code === 40 && self.snake.direction !== 'U') {
                    self.snake.direction = 'D';
                } else if (code === 27) {
                    self.isEscapePressed = 5;
                }

            });

        }

        generateSnake = function (length, elementRadius) {
            var i,
                startX = 15,
                startY = 15,
                currentX = startX,
                xExchange = 2 * elementRadius,
                direction = 'R',
                snake = {},
                body = [];

            snake.direction = direction;

            body.push({
                x: startX,
                y: startY,
                radius: elementRadius
            });

            for (i = 1; i < length; i += 1) {
                currentX += xExchange;

                body.push({
                    x: currentX,
                    y: startY,
                    radius: elementRadius
                });
            }

            snake.body = body;

            return snake;
        };

        pasteElementsInGameField = function (elements, elementsType, gameField) {
            var i,
                row,
                col;

            for (i = 0; i < elements.length; i += 1) {
                row = Math.floor(elements[i].y / 10);
                col = Math.floor(elements[i].x / 10);

                gameField[row][col] = elementsType;

                if (elementsType === MARK_SNAKE) {
                    elements[i].row = row;
                    elements[i].col = col;
                }

            }
        };

        createFood = function (gameField) {
            var foodRow,
                foodCol,
                food;

            do {
                foodRow = (Math.random() * GAME_FIELD_hEIGHT - 1) | 0;
                foodCol = (Math.random() * GAME_FIELD_WIDTH - 1) | 0;
            } while (gameField[foodRow][foodCol] !== undefined);

            food = {
                x: (foodCol * 10) + 5,
                y: (foodRow * 10) + 5,
                radius: GAME_FIELD_SQUARE_WIDTH / 2
            };

            return food;
        };

        createFieldElements = function (gameField) {
            var elementsOnRow,
                currentElement,
                i,
                elementRow,
                elementCol,
                elements = [],
                row;

            for (row = 0; row < GAME_FIELD_hEIGHT - 1; row += 1) {
                elementsOnRow = (Math.random() * 2) | 0;

                for (i = 0; i < elementsOnRow; i += 1) {
                    currentElement = createFood(gameField);
                    elements.push(currentElement);
                }

            }

            return elements;
        };

        Engine.prototype = {
            start: function () {
                var self = this,
                    pints = 0,
                    level = 1,
                    count = 0,
                    speed = 150,
                    firstSnakeElement = self.snake.body[0];

                function consoleLogg(array) {
                    var row,
                        col,
                        str;

                    console.clear();

                    for (row = 0; row < GAME_FIELD_hEIGHT; row += 1) {
                        str = '';
                        for (col = 0; col < GAME_FIELD_WIDTH; col += 1) {

                            if (self.gameField[row][col]) {
                                str += self.gameField[row][col];
                            } else {
                                str += '*';
                            }
                        }

                        console.log(str);
                    }
                }

                function woop() {
                    var lastSnakeElement = self.snake.body[self.snake.body.length - 1],
                        i;

                    firstSnakeElement = self.snake.body[0];

                    self.render.drawSnake(self.snake.body);
                    self.gameField[lastSnakeElement.row][lastSnakeElement.col] = MARK_SNAKE;

                    self.gameField[firstSnakeElement.row][firstSnakeElement.col] = undefined;

                    for (i = 0; i < self.snake.body.length - 1; i += 1) {
                        self.snake.body[i].x = self.snake.body[i + 1].x;
                        self.snake.body[i].y = self.snake.body[i + 1].y;
                        self.snake.body[i].row = self.snake.body[i + 1].row;
                        self.snake.body[i].col = self.snake.body[i + 1].col;
                    }

                    if (self.snake.direction === 'U') {
                        lastSnakeElement.y -= 10;
                        lastSnakeElement.row -= 1;

                    } else if (self.snake.direction === 'D') {
                        lastSnakeElement.y += 10;
                        lastSnakeElement.row += 1;
                    } else if (self.snake.direction === 'L') {
                        lastSnakeElement.x -= 10;
                        lastSnakeElement.col -= 1;
                    } else if (self.snake.direction === 'R') {
                        lastSnakeElement.x += 10;
                        lastSnakeElement.col += 1;
                    }

                    // check for out of game field
                    if (lastSnakeElement.row < 0 || GAME_FIELD_hEIGHT <= lastSnakeElement.row ||
                            lastSnakeElement.col < 0 || GAME_FIELD_WIDTH <= lastSnakeElement.col) {
                        self.isEscapePressed = true;

                        // chacke snake hit self or wall
                    } else if (self.gameField[lastSnakeElement.row][lastSnakeElement.col] === MARK_SNAKE ||
                            self.gameField[lastSnakeElement.row][lastSnakeElement.col] === MARK_WALL) {
                        self.isEscapePressed = true;

                        // snake eat food
                    } else if (self.gameField[lastSnakeElement.row][lastSnakeElement.col] === MARK_FOOD) {
                        pints += 100;
                        self.render.drawGameResults('Level ' + level + '                 Score ' + pints + '                  [ESC] ... Quit');

                        self.gameField[lastSnakeElement.row][lastSnakeElement.col] = undefined;

                        self.food = createFood(self.gameField);
                        pasteElementsInGameField([self.food], MARK_FOOD, self.gameField);

                        self.render.drawFood(self.food);
                        self.snake.body.push({
                            x: lastSnakeElement.x,
                            y: lastSnakeElement.y,
                            radius: lastSnakeElement.radius,
                            row: lastSnakeElement.row,
                            col: lastSnakeElement.col
                        });

                        self.gameField[lastSnakeElement.row][lastSnakeElement.col] = MARK_SNAKE;

                        count += 1;

                        if (count >= 5) {
                            count = 0;
                            speed -= 10;
                            level += 1;
                        }
                    }

                    if (!self.isEscapePressed) {
                        setTimeout(woop, speed);
                    } else {
                        self.render.drawGameResults('Level ' + level + '         Score ' + pints + '        GAME OVER');
                    }

                }

                setTimeout(woop, speed);
            }
        };

        return Engine;
    }());

    return {
        Engine: Engine
    };
}());