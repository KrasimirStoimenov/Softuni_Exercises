function solve(num1, num2, operator) {

    let firstNumber = Number(num1);
    let secondNumber = Number(num2);
    let result;
    switch (operator) {
        case '+':
            result = firstNumber + secondNumber;
            break;
        case '-':
            result = firstNumber - secondNumber;
            break;
        case '*':
            result = firstNumber * secondNumber;
            break;
        case '/':
            result = firstNumber / secondNumber;
            break;
        case '%':
            result = firstNumber % secondNumber;
            break;
        case '**':
            result = firstNumber ** secondNumber;
            break;
    }

    console.log(result);
}


solve('5', '6', '+');
console.log('-----')
solve('3', '5.5', '*');