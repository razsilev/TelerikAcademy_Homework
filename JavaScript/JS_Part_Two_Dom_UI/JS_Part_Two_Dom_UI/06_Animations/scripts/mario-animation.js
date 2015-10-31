var marioMove1 = new Image();
var marioMove2 = new Image();
var isLoadedMario1 = false;
var isLoadedMario2 = false;
var pic1 = {};
var pic2 = {};
var isChange = false;
var stage = new Kinetic.Stage({
    container: 'animation-container',
    width: 600,
    height: 300
});
var layer = new Kinetic.Layer();
var paper = Raphael(10, 10, 500, 300);
var san = paper.circle(500, 50, 20).attr({
    fill: 'yellow',
    stroke: 'none'
});

var rock = paper.rect(500, 233, 20, 10).attr({
    fill: 'red',
    stroke: 'none'
});

paper.rect(3, 233, 497, 50).attr({
    fill: 'green',
    stroke: 'none'
});

paper.rect(1, 3, 498, 280).attr({
    fill: 'none',
    stroke: 'gray',
    'stroke-width': 3
});

function createBackground() {

    san.attr({
        cx: san.attrs.cx - 0.4
    });

    if (san.attrs.cx < -10) {
        san.attr({
            cx: 510
        });
    }

    rock.toFront();
    rock.attr({
        x: rock.attrs.x - 1
    });

    if (rock.attrs.x < -10) {
        rock.attr({
            x: 500
        });
    }

    requestAnimationFrame(createBackground);
}

marioMove1.onload = function () {
    // when img is loaded do somthing
    isLoadedMario1 = true;

    pic1 = new Kinetic.Image({
        image: marioMove1,
        x: 150,
        y: 200
    });

    layer.add(pic1);

    createBackground();
};

marioMove2.onload = function () {
    // when img is loaded do somthing
    isLoadedMario2 = true;

    pic2 = new Kinetic.Image({
        image: marioMove2,
        x: 150,
        y: 200
    });

    layer.add(pic2);
};

marioMove1.src = 'images/mario_move1.png';
marioMove2.src = 'images/mario_move2.png';

stage.add(layer);

function frame() {

    if (isLoadedMario1 && isLoadedMario2) {
        if (isChange) {
            pic1.hide();
            pic2.show();
        } else {
            pic1.show();
            pic2.hide();
        }

        layer.draw();
    }

    isChange = !isChange;

    setTimeout(frame, 400);
}

frame();