/// <reference path="snake-game-engine.js" />
/// <reference path="snake-game-render.js" />
var snake = (function myfunction() {
    var Game = (function () {
        function Play(canvasID) {
            this.render = new canvasRender.Drawer(canvasID);
            this.engine = new snakeEngine.Engine(this.render);
        }

        Play.prototype.paly = function () {
            this.engine.start();
        };

        return Play;
    }());

    return {
        Game: Game
    };
}());

var snakeGame = new snake.Game('the-canvas');
snakeGame.paly();