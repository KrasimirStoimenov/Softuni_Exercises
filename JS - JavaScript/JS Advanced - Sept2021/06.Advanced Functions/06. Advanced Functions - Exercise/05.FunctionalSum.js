function solve(number) {
    let sum = number;

    function add(secondNumber) {
        sum += secondNumber;
        return add;
    }

    add.toString = () => {
        return (sum);
    }

    return add;
}

console.log(solve(1).toString());
console.log(solve(1)(6)(-3).toString());