function operation(firstNumber, secondNumber, operator) {
    switch (operator) {
        case '-':
            console.log(firstNumber - secondNumber);
            break;
        case '+':
            console.log(firstNumber + secondNumber);
            break;
        case '*':
            console.log(firstNumber * secondNumber);
            break;
        case '/':
            console.log(firstNumber / secondNumber);
            break;
        case '%':
            console.log(firstNumber % secondNumber);
            break;
        case '**':
            console.log(firstNumber ** secondNumber);
            break;
    }
}

operation(5, 6, '+');
console.log('-'.repeat(10));
operation(3, 5.5, '*');