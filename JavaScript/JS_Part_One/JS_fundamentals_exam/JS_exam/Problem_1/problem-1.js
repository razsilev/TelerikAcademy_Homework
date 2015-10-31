function solve(args) {
    var moneyHave = args[0] * 1,
        i,
        currentMony = 0,
        maxMoney = 0,
        cakesPrice = [];

    for (i = 1; i < args.length; i += 1) {
        cakesPrice.push(args[i] * 1);
    }

    for (i = 0; i > -1; i += 1) {
        
        if (i * cakesPrice[0] > moneyHave) {
            break;
        }

        for (var j = 0; j > -1; j += 1) {

            if (j * cakesPrice[1] > moneyHave) {
                break;
            }

            for (var k = 0; k > -1; k += 1) {

                currentMony = 0;

                currentMony += i * cakesPrice[0];
                currentMony += j * cakesPrice[1];
                currentMony += k * cakesPrice[2];

                if (currentMony === moneyHave) {
                    return currentMony;
                }

                if (currentMony < moneyHave) {
                    if (maxMoney < currentMony) {
                        maxMoney = currentMony;
                    }
                } else {
                    break;
                }
            }

        }

    }

    return maxMoney;
}

var args = [
    '110',
    '13',
    '15',
    '17'];

var args2 = [
    '20',
    '11',
    '200',
    '300'];

var args3 = [
    '110',
    '19',
    '29',
    '39'];

console.dir(solve(args));
console.dir(solve(args2));
console.dir(solve(args3));