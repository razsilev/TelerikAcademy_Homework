var paper = Raphael('svg-container', 400, 600);

// telerik image
paper.rect(30, 20, 350, 140);
var logo = paper.path('M 50 60 l 15 -15 l 40 40 l -20 20 l -20 -20 l 40 -40 l 15 15');
var companyName = paper.text(225, 80, 'Telerik');
var text = paper.text(243, 120, 'Develop experiences');
paper.circle(330, 72, 5);
paper.text(330, 72, 'R').attr({
    'font-weight': 'bold',
    'font-size': 8
});

logo.attr({
    stroke: '#0f0',
    'stroke-width': 5
});

companyName.attr({
    'font-size': 65
});

text.attr({
    'font-size': 22,
    fill: '#555'
});

// youtube image
paper.rect(30, 220, 350, 140);
var tubeRect = paper.rect(175, 250, 190, 80, 15);
var youText = paper.text(105, 290, 'You');
var tubeText = paper.text(270, 290, 'Tube');

tubeRect.attr({
    stroke: 'none',
    fill: '#d11'
});

youText.attr({
    'font-size': 75,
    fill: '#555'
});

tubeText.attr({
    'font-size': 75,
    fill: '#fff'
});