function gcd(firstNumber, secondNumber) {
    let divisor = 0;
    for (let i = 1; i < 10; i++) {
        if (firstNumber % i == 0 && secondNumber % i == 0) {
            divisor = i;
        }
    }
    console.log(divisor);
}

gcd(15, 5);
console.log('*'.repeat(10));
gcd(2154, 458);