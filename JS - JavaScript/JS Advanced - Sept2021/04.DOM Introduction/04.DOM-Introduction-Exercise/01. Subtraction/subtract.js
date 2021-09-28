function subtract() {
    let firstElement = Number(document.getElementById('firstNumber').value);
    let secondElement = Number(document.getElementById('secondNumber').value);

    let result = document.getElementById('result');

    result.textContent = firstElement - secondElement;
}