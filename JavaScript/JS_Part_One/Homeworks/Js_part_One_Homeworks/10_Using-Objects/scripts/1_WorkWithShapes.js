/*
 *   1.   Write functions for working with shapes in
 *        standard Planar coordinate system
 *        - Points are represented by coordinates P(X, Y)
 *        - Lines are represented by two points, marking their
 *        - beginning and ending 
 *          - L(P1(X1,Y1), P2(X2,Y2))
 *        - Calculate the distance between two points
 *        - Check if three segment lines can form a triangle
 */

function distanceBetweenTwoPoints(first, second) {
    // distance = sqrt(a*a + b*b)
    var a = Math.abs(first.X - second.X),
        b = Math.abs(first.Y - second.Y),
        distanceSquare = (a * a + b * b),
        distance = Math.sqrt(distanceSquare);

    return distance;
}

function point(x, y) {
    return {
        X: x,
        Y: y,
        toString: function () {
            return this.X + ', ' + this.Y;
        }
    };
}

function line(start, end) {
    return {
        start: start,
        end: end,
        toString: function () {
            return 'start(' + this.start + "), end(" + this.end + ')';
        }
    };
}

function formTriangle(firstLine, secondLine, thirdLine) {
    var canForm = true,
        a = distanceBetweenTwoPoints(firstLine.start, firstLine.end),
        b = distanceBetweenTwoPoints(secondLine.start, secondLine.end),
        c = distanceBetweenTwoPoints(thirdLine.start, thirdLine.end);

    if ((a >= (b + c)) ||
            (b >= (a + c)) ||
            (c >= (a + b))) {
        canForm = false;
    }

    return canForm;
}

(function test() {
    var someLine = line(point(1, 4), point(5, 1)),
        firstLine = line(point(3, 8), point(3, 4)),
        secondLine = line(point(2, 3), point(2, 5));

    jsConsole.writeLine("Some point: " + point(3, 4));
    jsConsole.writeLine("Some line: " + line(point(1, 2), point(2, 3)));
    jsConsole.writeLine("Length of same line: " +
        distanceBetweenTwoPoints(someLine.start, someLine.end));
    jsConsole.writeLine("Lines can form triangle: " +
        formTriangle(someLine, firstLine, secondLine));
}());