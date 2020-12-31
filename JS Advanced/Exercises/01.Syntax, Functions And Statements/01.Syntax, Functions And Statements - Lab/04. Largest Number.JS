function findLargestNumber(firstNumber, secondNumber, thirdNumber) {

    let biggerFromFirstTwo = Math.max(firstNumber, secondNumber);
    let biggestNumber = Math.max(biggerFromFirstTwo, thirdNumber);

    console.log(`The largest number is ${biggestNumber}.`);
}

findLargestNumber(5, -3, 16)
console.log('-----')
findLargestNumber(-3, -5, -22.5)