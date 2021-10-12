function validate() {
    document.querySelector('#company').addEventListener('change', (ev) => {
        console.log(ev.target);
        if (document.querySelector('#company').checked) {
            document.querySelector('#companyInfo').style.display = 'block';
        } else {
            document.querySelector('#companyInfo').style.display = 'none';
        }
    });

    document.querySelector('#submit').addEventListener('click', (ev) => {
        const validOut = [];
        const userName = document.querySelector('#username');
        const email = document.querySelector('#email');
        const passWord = document.querySelector('#password');
        const confirmPass = document.querySelector('#confirm-password');
        const companyInfo = document.querySelector('#company');
        const userTest = /^[A-Za-z0-9]{3,20}$/;
        const emailTest = /^[^@.]+@[^@]*\.[^@]*$/;
        const passTest = /^[\w]{5,15}$/;

        if (userTest.exec(userName.value) === null) {
            userName.style.borderColor = 'red';
            validOut.push(false);
        } else {
            userName.style.border = 'none';
            validOut.push(true);
        }

        if (emailTest.exec(email.value) === null) {
            email.style.borderColor = 'red';
            validOut.push(false);
        } else {
            email.style.border = 'none';
            validOut.push(true);
        }

        if (
            passWord.value === confirmPass.value &&
            passTest.exec(confirmPass.value) != null &&
            passTest.exec(passWord.value) != null
        ) {
            confirmPass.style.border = 'none';
            passWord.style.border = 'none';
            validOut.push(true);
        } else {
            confirmPass.style.borderColor = 'red';
            passWord.style.borderColor = 'red';
            validOut.push(false);
        }

        if (companyInfo.checked) {
            const company = document.querySelector('#companyNumber');
            if (company.value < 1000 || company.value > 9999) {
                company.style.borderColor = 'red';
                validOut.push(false);
            } else {
                company.style.border = 'none';
                validOut.push(true);
            }
        }

        if (!validOut.includes(false)) {
            document.querySelector('#valid').style.display = 'block';
        } else {
            document.querySelector('#valid').style.display = 'none';
        }
    });
}