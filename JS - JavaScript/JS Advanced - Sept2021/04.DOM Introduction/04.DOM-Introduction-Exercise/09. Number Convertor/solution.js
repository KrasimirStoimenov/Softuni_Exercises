function solve() {
    const binaryOption = document.createElement('option');
    binaryOption.textContent = 'Binary';
    binaryOption.value = 'binary';

    const hexadecimalOption = document.createElement('option');
    hexadecimalOption.textContent = 'Hexadecimal';
    hexadecimalOption.value = 'hexadecimal';

    const selectMenuTo = document.getElementById('selectMenuTo');
    selectMenuTo.appendChild(binaryOption);
    selectMenuTo.appendChild(hexadecimalOption);

    const button = document.querySelector('#container>button');

    button.addEventListener('click', calculate)
    function calculate() {
        const input = document.getElementById('input').value;
        const result = document.getElementById('result');

        if (selectMenuTo.value == 'binary') {
            result.value = Number(input).toString(2);
        } else if (selectMenuTo.value == 'hexadecimal') {
            result.value = Number(input).toString(16).toUpperCase();
        }
    }
}