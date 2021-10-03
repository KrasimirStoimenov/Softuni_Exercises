function addItem() {
    const elements = document.getElementById('items');
    const input = document.getElementById('newItemText');

    const newElement = document.createElement('li');
    newElement.textContent = input.value;
    elements.appendChild(newElement);

    input.value = '';
}