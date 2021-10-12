function validate() {
    const emailElement = document.getElementById('email');
    const emailRegex = /^[a-z]+@[a-z]+\.[a-z]+$/;
    emailElement.addEventListener('change', () => {
        if (!emailRegex.test(emailElement.value)) {
            emailElement.classList.add('error');
        }
        else {
            emailElement.classList.remove('error');
        }
    })
}