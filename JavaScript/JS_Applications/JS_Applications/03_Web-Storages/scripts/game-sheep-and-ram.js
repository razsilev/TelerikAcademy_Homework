(function () {
    'use strict';
    var inputElement,
        searchedNumber,
        remElement,
        sheepElement,
        gameOver,
        scoreListContainer,
        SCORE_INCREASE = 10,
        SAVE_KEY = 'highScore',
        currentScore,
        paragraph = document.createElement('p'),
        lastValidInput,
        clearScoresBtn = document.getElementById('clear-scores');

    inputElement = document.getElementById('the-input');
    remElement = document.getElementById('rem');
    sheepElement = document.getElementById('sheep');
    scoreListContainer = document.getElementById('high-score-container');

    gameOver = 4;
    currentScore = 0;

    function generateRandomNumber() {
        var numberOfDigits,
            i,
            currentDigit,
            result;

        result = '';
        numberOfDigits = 4;
        result += Math.floor(Math.random() * 9 + 1);

        for (i = 1; i < numberOfDigits; i += 1) {
            currentDigit = Math.floor(Math.random() * 10).toString();

            if (result.indexOf(currentDigit) < 0) {
                result += currentDigit;
            } else {
                i -= 1;
            }
        }

        return result;
    }

    function startNewGame() {
        currentScore = 0;
        searchedNumber = generateRandomNumber();
        inputElement.value = '';
        remElement.innerHTML = '0';
        sheepElement.innerHTML = '0';

        console.log('actual random generated number is: ' + searchedNumber);
    }

    startNewGame();

    function calculateRems(number, searchedNumber) {
        var i,
            rems;

        rems = 0;

        for (i = 0; i < searchedNumber.length; i += 1) {
            if (number[i] === searchedNumber[i]) {
                rems += 1;
            }
        }

        return rems;
    }

    function calculateSheeps(number, searchedNumber) {
        var i,
            indexOfDigit,
            sheep;

        sheep = 0;

        for (i = 0; i < searchedNumber.length; i += 1) {
            indexOfDigit = searchedNumber.indexOf(number[i]);

            if ((indexOfDigit >= 0) && (indexOfDigit !== i)) {
                sheep += 1;
            }
        }

        return sheep;
    }

    function setResults(rem, sheep) {
        remElement.innerHTML = rem;
        sheepElement.innerHTML = sheep;
    }

    function toResultsArray(resultsString) {
        var results = [],
            i,
            name,
            score,
            splitedResults,
            splitedStrings;

        splitedResults = resultsString.split(';');

        for (i = 0; i < splitedResults.length; i += 1) {
            splitedStrings = splitedResults[i].split('/');

            results.push({
                name: splitedStrings[0],
                score: parseInt(splitedStrings[1], 10)
            });
        }

        return results;
    }

    function toString(resultsArray) {
        var i,
            currentResult,
            result;

        result = '';
        currentResult = '';

        for (i = 0; i < resultsArray.length; i += 1) {
            if (i > 0) {
                currentResult = ';';
            }

            currentResult += resultsArray[i].name + '/' + resultsArray[i].score;

            result += currentResult;
        }

        return result;
    }

    function printHighScoreList(results) {
        var currentResult,
            fragment = document.createDocumentFragment(),
            i;

        // remove scoreListContainer childs
        while (scoreListContainer.firstChild) {
            scoreListContainer.removeChild(scoreListContainer.firstChild);
        }

        for (i = 0; i < results.length; i += 1) {
            currentResult = paragraph.cloneNode(true);

            currentResult.textContent = (i + 1) + ' -> ' +
                                        results[i].name +
                                        ' - ' + results[i].score;

            fragment.appendChild(currentResult);
        }

        scoreListContainer.appendChild(fragment);
    }

    function winGame(score) {
        var nickname = prompt("What is your nickname?", "Type you nickname here."),
            resultString,
            results;

        if (localStorage.hasOwnProperty(SAVE_KEY)) {
            resultString = localStorage.getItem(SAVE_KEY);

            results = toResultsArray(resultString);
            results.push({
                name: nickname,
                score: score
            });

            results = results.sort(function (a, b) {
                return a.score - b.score;
            });

            if (results.length > 5) {
                results.length = 5;
            }
        } else {
            results = [{
                name: nickname,
                score: score
            }];
        }

        resultString = toString(results);
        localStorage.setItem(SAVE_KEY, resultString);
        printHighScoreList(results);

        startNewGame();
    }

    function isValidInput(input) {
        var isInputContainsOnlyDifferentDigits,
            i,
            isValid,
            digits = {};

        isValid = true;

        if (input.length === searchedNumber.length && input !== lastValidInput) {

            for (i = 0; i < input.length; i += 1) {
                if (digits[input[i]]) {
                    inputElement.style.backgroundColor = '#f88';
                    isValid = false;
                    break;
                } else {
                    digits[input[i]] = true;
                }
            }
        } else {
            inputElement.style.backgroundColor = '#fff';
            isValid = false;
        }

        return isValid;
    }

    clearScoresBtn.addEventListener('click', function () {
        localStorage.removeItem(SAVE_KEY);
        printHighScoreList([]);
    });

    if (localStorage.hasOwnProperty(SAVE_KEY)) {
        printHighScoreList(toResultsArray(localStorage.getItem(SAVE_KEY)));
    }

    // game loop
    inputElement.addEventListener('keyup', function () {
        var rem,
            sheep;

        if (/\D/g.test(this.value)) {
            this.value = this.value.replace(/\D/g, '');
        } else if (isValidInput(this.value)) {
            //console.log(this.value); // print valid user input

            lastValidInput = this.value;
            currentScore += SCORE_INCREASE;

            // game logic here
            rem = calculateRems(lastValidInput, searchedNumber);
            sheep = calculateSheeps(lastValidInput, searchedNumber);

            setResults(rem, sheep);

            if (rem === gameOver) {
                winGame(currentScore);
            }
        }
    });

}());