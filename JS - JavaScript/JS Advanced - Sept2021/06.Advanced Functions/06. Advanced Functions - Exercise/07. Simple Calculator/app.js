function calculator() {
    let firstNumber;
    let secondNumber;
    let result;

    function init() {
        firstNumber = document.querySelector('#num1');
        secondNumber = document.querySelector('#num2');
        result = document.querySelector('#result');
    }

    function add() {
        result.value = Number(firstNumber.value) + Number(secondNumber.value);
    }

    function subtract() {
        result.value = Number(firstNumber.value) - Number(secondNumber.value);
    }

    return {
        init,
        add,
        subtract
    }
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');
