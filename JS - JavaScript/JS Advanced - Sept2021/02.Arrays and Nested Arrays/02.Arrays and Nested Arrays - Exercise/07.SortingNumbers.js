function sortArray(numbers) {
    numbers = numbers.sort((a, b) => a - b);
    const resultArray = [];

    while (numbers.length > 0) {
        resultArray.push(numbers.shift());
        resultArray.push(numbers.pop());
    }

    return resultArray;
}

console.log(sortArray([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));