var container = document.getElementById('container');
var tags = ["cms", "javascript", "js", "ASP.NET MVC",
            ".net", ".net", "css", "wordpress", "xaml",
            "js", "http", "web", "asp.net", "asp.net MVC",
            "ASP.NET MVC", "wp", "javascript", "js", "cms",
            "html", "javascript", "http", "http", "CMS"];

function generateTagCloud(tags, minFontSize, maxFontSize) {
    var tagsOccurrences = {},
        tagsFontSizes = {},
        span = {},
        tag = '',
        fragment = document.createDocumentFragment();

    function createSpan(text, fontSize) {
        var span = document.createElement('span');

        span.innerHTML = text + ' ';
        span.style.fontSize = fontSize + 'px';

        return span;
    }

    function calcTagOccurrences(tags) {
        var tagsOccurrences = {},
            i = 0,
            count = 0;

        for (i = 0; i < tags.length; i += 1) {

            if (tagsOccurrences[tags[i]]) {
                tagsOccurrences[tags[i]] += 1;
            } else {
                tagsOccurrences[tags[i]] = 1;
                count += 1;
            }
        }

        return tagsOccurrences;
    }

    function calcTagsFontSizes(tagsOccurrences, minSize, maxSize) {
        var sizeStep = 0,
            tagsFontSizes = {},
            currentFontSize = minSize,
            currentOccurrences = 0,
            tag = '',
            i = 0,
            tagsArray = [];

        for (tag in tagsOccurrences) {
            tagsArray.push({
                name: tag,
                occurrences: tagsOccurrences[tag]
            });
        }

        sizeStep = (maxSize - minSize) / tagsArray.length;

        tagsArray.sort(function (a, b) {
            return a.occurrences - b.occurrences;
        });

        currentOccurrences = tagsArray[0].occurrences;
        for (i = 0; i < tagsArray.length; i += 1) {
            tagsFontSizes[tagsArray[i].name] = currentFontSize;

            if (tagsArray[i].occurrences > currentOccurrences) {
                currentFontSize += sizeStep;
            }
        }

        return tagsFontSizes;
    }

    tagsOccurrences = calcTagOccurrences(tags);
    tagsFontSizes = calcTagsFontSizes(tagsOccurrences, minFontSize, maxFontSize);

    // create spans and add them to fragment container
    for (tag in tagsOccurrences) {
        span = createSpan(tag, tagsFontSizes[tag]);
        fragment.appendChild(span);
    }

    return fragment;
}

var tagCloud = generateTagCloud(tags, 17, 42);

container.style.width = '150px';
container.style.border = '1px solid #000';
container.style.padding = '5px';
container.appendChild(tagCloud);