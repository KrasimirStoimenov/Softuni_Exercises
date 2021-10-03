function validate() {
    document.getElementById('email').addEventListener('change', onChange);
    function onChange(ev) {
        const regexValidation = /^[a-z]+@[a-z]+\.[a-z]+$/;

        if (regexValidation.test(ev.target.value)) {
            ev.target.classList.remove('error');
        }
        else {
            ev.target.classList.add('error');
        }
    }
}