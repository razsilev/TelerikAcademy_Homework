var gdColorElement = document.getElementById('background-color');
var fontColorElement = document.getElementById('font-color');
var textInput = document.getElementById('input-text');
textInput.value = 'Test value';
textInput.style.fontSize = '26px';
textInput.style.paddingLeft = '5px';
textInput.style.fontWeight = 'bold';

gdColorElement.onchange = function () {
    var color = gdColorElement.value;
    textInput.style.backgroundColor = color;
}

fontColorElement.onchange = function () {
    var color = fontColorElement.value;
    textInput.style.color = color;
}