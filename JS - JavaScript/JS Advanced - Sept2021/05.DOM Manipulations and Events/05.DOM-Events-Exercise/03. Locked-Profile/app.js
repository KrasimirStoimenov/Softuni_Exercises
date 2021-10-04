function lockedProfile() {
    const showMoreBtns = Array.from(document.querySelectorAll('.profile button'));

    for (const btn of showMoreBtns) {
        btn.addEventListener('click', showHide);
    }

    function showHide(ev) {
        const button = ev.target;
        const profile = button.parentElement;
        const radioBtn = profile.querySelector('input[type="radio"]:checked').value;

        if (radioBtn == 'unlock') {
            if (button.textContent == 'Show more') {
                profile.getElementsByTagName('div')[0].style.display = 'block';
                button.textContent = 'Hide it';
            }
            else{
                profile.getElementsByTagName('div')[0].style.display = 'none';
                button.textContent = 'Show more';
            }
        }
    }
}