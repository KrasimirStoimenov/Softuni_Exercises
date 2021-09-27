function sumTable() {
    let sum = 0;

    const elements = document.getElementsByTagName('tr');

    for (let i = 1; i < elements.length; i++) {
        const priceAsString = elements[i].lastElementChild.textContent;
        const priceAsNumber = Number(priceAsString);

        sum += priceAsNumber;
    }

    const total = document.getElementById('sum');

    total.textContent = sum;
}