var querySelectorBtn = document.getElementById('querySelectorBtn'),
    isTrue = false,
    ElementsByTagNameBtn = document.getElementById('ElementsByTagNameBtn');

querySelectorBtn.onclick = function () {
    var divs = document.querySelectorAll('div > div');

    isTrue = !isTrue;

    for (var i = 0; i < divs.length; i++) {
        if (isTrue) {
            divs[i].setAttribute('style', 'color: #00f');
        } else {
            divs[i].setAttribute('style', 'color: #f00');
        }
    }
}

ElementsByTagNameBtn.onclick = function () {
    var divs = document.getElementsByTagName('div');

    isTrue = !isTrue;

    for (var i = 0; i < divs.length; i++) {
        if (divs[i].parentElement instanceof HTMLDivElement) {
            if (isTrue) {
                divs[i].setAttribute('style', 'color: #00f');
            } else {
                divs[i].setAttribute('style', 'color: #f00');
            }
        }
    }
}