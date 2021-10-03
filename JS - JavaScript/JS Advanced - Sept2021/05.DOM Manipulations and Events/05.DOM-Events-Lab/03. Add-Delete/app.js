function addItem() {
    const elements = document.getElementById('items');
    const input = document.getElementById('newItemText');

    const newlyAddedElement = document.createElement('li');
    newlyAddedElement.textContent = input.value;
    elements.appendChild(newlyAddedElement);

    const elementToDelete = document.createElement('a');
    elementToDelete.href = '#';
    elementToDelete.textContent = '[Delete]';
    newlyAddedElement.appendChild(elementToDelete);

    elementToDelete.addEventListener('click', (e) => e.target.parentElement.remove());

    input.value = '';
}