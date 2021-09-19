function aggregate(array) {
    let sum = sumElements(array);
    let sumDividedByOne = dividedByOne(array);
    let concatenatedString = concatenateArrayAsString(array);

    console.log(sum);
    console.log(sumDividedByOne);
    console.log(concatenatedString)
}

function sumElements(array) {
    let sum = 0;

    array.forEach(element => {
        sum += element;
    });

    return sum;
}

function dividedByOne(array) {
    let sum = 0;
    array.forEach(element => {
        let currentSum = 1 / element;

        sum += currentSum;
    });

    return sum;
}

function concatenateArrayAsString(array){
    let concatenatedString = '';

    array.forEach(element => {
        concatenatedString+=element.toString();
    });

    return concatenatedString;
}

aggregate([1, 2, 3]);
console.log('-'.repeat(10));
aggregate([2, 4, 8, 16]);