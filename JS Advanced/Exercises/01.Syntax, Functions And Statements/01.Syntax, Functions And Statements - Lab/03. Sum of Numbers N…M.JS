function sumNumbers(num1, num2) {

    let firstNumber = Number(num1);
    let secondNumber = Number(num2);
    let result = 0;

    for (let i = firstNumber; i <= secondNumber; i++) {
        result += i;
    }

    console.log(result);
}

sumNumbers('1', '5');
console.log('-----');
sumNumbers('-8', '20')