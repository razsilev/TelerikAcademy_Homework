function solve(input) {
    var arr = input.map(Number),
        maxSum = arr[1],
        currentSum = 0,
        i;

    for (i = 1; i < arr.length; i += 1) {
        currentSum = arr[i] + Math.max(currentSum, 0);
        maxSum = Math.max(maxSum, currentSum);
    }

    return maxSum;
}