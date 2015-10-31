var setColorBtn = document.getElementById('set-color');

setColorBtn.onclick = function () {
    var color = document.getElementById('color-input').value,
        body = document.body;
    body.bgColor = color;
}