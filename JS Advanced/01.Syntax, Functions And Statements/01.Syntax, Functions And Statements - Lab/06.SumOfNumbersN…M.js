function sumNumbers(firstNumber, secondNumber) {
    let firstNumberParsed = Number(firstNumber);
    let secondNumberParsed = Number(secondNumber);

    let result = 0;

    for (let i = firstNumberParsed; i <= secondNumberParsed; i++) {
        result += i;
    }

    console.log(result);
}

sumNumbers('1', '5');
console.log('-'.repeat(10));
sumNumbers('-8', '20');