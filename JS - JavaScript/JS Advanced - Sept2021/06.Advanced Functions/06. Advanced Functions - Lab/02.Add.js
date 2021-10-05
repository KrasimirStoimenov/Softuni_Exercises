function solution(number) {
    const currentNumber = number;

    function add(numberToAdd) {
        return currentNumber + numberToAdd;
    }

    return add;
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));

console.log('*'.repeat(10));

let add7 = solution(7);
console.log(add7(2));
console.log(add7(3));
