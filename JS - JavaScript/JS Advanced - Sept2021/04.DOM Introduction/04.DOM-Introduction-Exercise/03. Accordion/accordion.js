function toggle() {
    let buttonElement = document.querySelector('.button');
    let paragraphElement = document.getElementById('extra');

    if (buttonElement.textContent == 'More') {
        paragraphElement.style.display = 'block';
        buttonElement.textContent = 'Less';
    }
    else {
        paragraphElement.style.display = 'none';
        buttonElement.textContent = 'More';
    }
}