function addItem() {
    const inputText = document.getElementById('newItemText');
    const inputValue = document.getElementById('newItemValue');
    const selectElement = document.getElementById('menu');
    const createOption = document.createElement('option');
    createOption.textContent = inputText.value;
    createOption.value = inputValue.value;
    
    selectElement.appendChild(createOption);

    inputText.value = '';
    inputValue.value = '';
}