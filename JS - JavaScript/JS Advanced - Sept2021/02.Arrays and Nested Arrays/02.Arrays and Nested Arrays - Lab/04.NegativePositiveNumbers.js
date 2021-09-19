function positiveNegativeNumbers(array) {
    const resultArray = [];
    for (const element of array) {
        if (element < 0) {
            resultArray.unshift(element);
        }
        else {
            resultArray.push(element);
        }
    }

    return resultArray;
}

console.log(positiveNegativeNumbers([7, -2, 8, 9]));
console.log('*'.repeat(10));
console.log(positiveNegativeNumbers([3, -2, 0, -1]));