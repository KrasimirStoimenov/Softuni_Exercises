function extractSubsequence(numbers) {
    let currentMaxValue = Number.MIN_SAFE_INTEGER;
    const resultArray = [];

    for (let i = 0; i < numbers.length; i++) {
        const element = numbers[i];

        if (element >= currentMaxValue) {
            currentMaxValue = element;
            resultArray.push(currentMaxValue);
        }
    }

    return resultArray;
}

console.log(extractSubsequence([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]));
console.log('*'.repeat(10));
console.log(extractSubsequence([1,
    2,
    3,
    4]));
console.log('*'.repeat(10));
console.log(extractSubsequence([20,
    3,
    2,
    15,
    6,
    1]));