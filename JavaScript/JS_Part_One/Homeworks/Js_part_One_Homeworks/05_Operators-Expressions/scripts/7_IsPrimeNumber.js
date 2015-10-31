/* 
*     7. Write an expression that checks if given positive integer number
*        n (n ≤ 100) is prime. E.g. 37 is prime.
*/
function isPrime(n) {
    if (n <= 2 && n > 0) {
        return true;
    }

    if (n === 0) {
        return false;
    }

    /* An integer is prime if it is not divisible
       by any prime less than or equal to its square root. */

    var i,
        squareRootN = Math.floor(Math.sqrt(n));

    for (i = 2; i <= squareRootN; i += 1) {
        if (n % i === 0) {
            return false;
        }
    }

    return true;
}

var number = 11;

jsConsole.writeLine("Is " + number + " prime: " + isPrime(number));
