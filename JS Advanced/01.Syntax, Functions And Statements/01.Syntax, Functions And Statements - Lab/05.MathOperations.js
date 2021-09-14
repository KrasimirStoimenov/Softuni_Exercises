function operation(firstNumber, secondNumer, operator) {
    switch (operator) {
        case '-':
            console.log(firstNumber - secondNumer);
            break;
        case '+':
            console.log(firstNumber + secondNumer);
            break;
        case '*':
            console.log(firstNumber * secondNumer);
            break;
        case '/':
            console.log(firstNumber / secondNumer);
            break;
        case '%':
            console.log(firstNumber % secondNumer);
            break;
        case '**':
            console.log(firstNumber ** secondNumer);
            break;
    }
}

operation(5, 6, '+');
console.log("--------")
operation(3, 5.5, '*');