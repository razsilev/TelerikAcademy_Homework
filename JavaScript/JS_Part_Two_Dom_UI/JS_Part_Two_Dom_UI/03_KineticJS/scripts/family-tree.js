var familyMembers = [{
    mother: 'Petra Stamatova',
    father: 'Todor Stamatov',
    children: ['Maria Petrova']
}, {
    mother: 'Maria Petrova',
    father: 'Georgi Petrov',
    children: ['Teodora Petrova',
        'Peter Petrov']
}, {
    mother: 'Teodora Petrova',
    father: 'xxx',
    children: ['Georgy Todorov']
}];

var stage = new Kinetic.Stage({
    container: 'kinetic-container',
    width: 500,
    height: 700
});

function drawFamilyTree(stage, familyMembers) {
    var layer = new Kinetic.Layer(),
        yDraw = 10,
        yChange = 100,
        graphicsCharacteristics = {},
        usedY = {},
        drawManX = 150,
        i,
        xCoord;

    function createKineticjsText(textString, x, y) {
        var complexText = new Kinetic.Text({
            x: x,
            y: y,
            text: textString,
            fontSize: 12,
            fontFamily: 'Calibri',
            fill: '#333',
            //width: 380,
            padding: 10,
            align: 'center'
        });

        return complexText;
    }

    function createKineticFigure(isMale, kineticText) {
        var figure;

        if (isMale) {
            figure = new Kinetic.Rect({
                x: kineticText.getX(),
                y: kineticText.getY(),
                stroke: '#555',
                strokeWidth: 2,
                fill: '#ddd',
                width: kineticText.getWidth(),
                height: kineticText.height(),
                cornerRadius: 10
            });

            graphicsCharacteristics[kineticText.getText()] = {
                x: figure.getX(),
                middleX: figure.getX() + figure.getWidth() / 2,
                y: figure.getY(),
                width: figure.getWidth(),
                height: figure.getHeight()
            };
        } else {
            figure = new Kinetic.Ellipse({
                x: kineticText.getX() + kineticText.getWidth() / 2,
                y: kineticText.getY() + kineticText.height() / 2,
                radius: {
                    x: kineticText.getWidth() / 2,
                    y: kineticText.height() / 2
                },
                stroke: '#f0a',
                fill: '#cf0',
                strokeWidth: 2
            });

            graphicsCharacteristics[kineticText.getText()] = {
                x: figure.getX(),
                middleX: figure.getX(),
                y: figure.getY(),
                width: figure.getWidth(),
                height: figure.getHeight() / 2
            };
        }

        usedY[figure.getY()] = true;

        return figure;
    }

    function addFamilyMember(isMale, name, xdraw, yDraw) {
        var text = createKineticjsText(name, xdraw, yDraw),
            figure = createKineticFigure(isMale, text);

        layer.add(figure);
        layer.add(text);
    }

    function addChildren(children, xdrawStart, yDraw) {
        var currentX = xdrawStart,
            j;

        for (j = 0; j < children.length; j += 1) {
            addFamilyMember(true, children[j], currentX, yDraw);

            currentX += 150;
        }
    }

    function addArrow(startX, startY, endX, endY) {
        var line = new Kinetic.Shape({
            sceneFunc: function (context) {
                context.beginPath();
                context.moveTo(startX, startY);
                context.lineTo(endX, endY);

                // arrow direction
                context.lineTo(endX - 10, endY - 10);
                context.lineTo(endX + 10, endY - 10);
                context.lineTo(endX, endY);

                // KineticJS specific context method
                context.fillStrokeShape(this);
            },
            fill: '#00D2FF',
            stroke: 'blue',
            strokeWidth: 2
        });

        layer.add(line);
    }

    function makeArrols(familyMember, graphicsCharacteristics) {
        var startX,
            startY,
            endX,
            endY,
            name,
            i;

        // father arrow
        name = familyMember.father;
        startX = graphicsCharacteristics[name].middleX;
        startY = graphicsCharacteristics[name].y + graphicsCharacteristics[name].height;
        endX = graphicsCharacteristics[familyMember.children[0]].middleX;
        endY = graphicsCharacteristics[familyMember.children[0]].y;
        addArrow(startX, startY, endX, endY);

        // mother arrows
        for (i = 0; i < familyMember.children.length; i += 1) {
            name = familyMember.mother;
            startX = graphicsCharacteristics[name].middleX;
            startY = graphicsCharacteristics[name].y + graphicsCharacteristics[name].height;
            endX = graphicsCharacteristics[familyMember.children[i]].middleX;
            endY = graphicsCharacteristics[familyMember.children[i]].y;
            addArrow(startX, startY, endX, endY);
        }
    }

    function deleteRect(graphic) {
        layer.add(new Kinetic.Rect({
            x: graphic.x - 2,
            y: graphic.y - 2,
            fill: '#fff',
            width: graphic.width + 4,
            height: graphic.height + 4
        }));
    }

    for (i = 0; i < familyMembers.length; i += 1) {
        // if in graphic do not have men with father's name
        if (!graphicsCharacteristics[familyMembers[i].father]) {
            // if on current row have children add before them
            if (usedY[yDraw]) {
                drawManX = 90;
            } else {
                drawManX = 150;
            }

            addFamilyMember(true, familyMembers[i].father, drawManX, yDraw);
        }

        // by default all children are men, if mother's name alredy exist change it to women desine
        if (graphicsCharacteristics[familyMembers[i].mother]) {
            deleteRect(graphicsCharacteristics[familyMembers[i].mother]);
            xCoord = graphicsCharacteristics[familyMembers[i].mother].x;
            addFamilyMember(false, familyMembers[i].mother, xCoord, yDraw);
        } else {
            addFamilyMember(false, familyMembers[i].mother, drawManX + 140, yDraw);
        }

        // change y cordinate for next generation, to be under his parents
        yDraw += yChange;

        addChildren(familyMembers[i].children, drawManX + 70, yDraw);

        makeArrols(familyMembers[i], graphicsCharacteristics);
    }

    stage.add(layer);
}

drawFamilyTree(stage, familyMembers);

