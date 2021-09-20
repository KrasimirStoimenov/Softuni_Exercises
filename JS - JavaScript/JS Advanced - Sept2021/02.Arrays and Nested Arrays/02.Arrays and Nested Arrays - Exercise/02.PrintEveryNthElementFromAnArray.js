function printNthElement(array, step) {
    const resultArray = [];

    for (let i = 0; i < array.length; i += step) {
        resultArray.push(array[i]);
    }

    return resultArray;
}

console.log(printNthElement(['5',
    '20',
    '31',
    '4',
    '20'],
    2));
console.log('*'.repeat(10));
console.log(printNthElement(['dsa',
    'asd',
    'test',
    'tset'],
    2));
console.log('*'.repeat(10));
console.log(printNthElement(['1',
    '2',
    '3',
    '4',
    '5'],
    6));