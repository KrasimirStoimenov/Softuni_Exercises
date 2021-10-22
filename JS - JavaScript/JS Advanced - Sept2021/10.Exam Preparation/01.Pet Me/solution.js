function solve() {
    const adoptionSectionUl = document.querySelector('#adoption ul');
    const adoptedSectionUl = document.querySelector('#adopted ul');
    const [name, age, kind, owner] = Array.from(document.querySelectorAll('#add #container input'));
    const addBtn = document.querySelector('#add #container button');
    addBtn.addEventListener('click', addPet)

    function addPet(ev) {
        ev.preventDefault();

        if (name.value != '' && !isNaN(age.value) && age.value != '' && kind.value != '' && owner.value != '') {
            const liElement = document.createElement('li');
            const pElement = document.createElement('p');
            pElement.innerHTML = `<strong>${name.value}</strong> is a <strong>${age.value}</strong> year old <strong>${kind.value}</strong>`;
            const ownerSpanElement = document.createElement('span');
            ownerSpanElement.textContent = `Owner: ${owner.value}`;
            const contactBtnElement = document.createElement('button');
            contactBtnElement.textContent = 'Contact with owner';
            contactBtnElement.addEventListener('click', changeBtn)

            liElement.appendChild(pElement);
            liElement.appendChild(ownerSpanElement);
            liElement.appendChild(contactBtnElement);
            adoptionSectionUl.appendChild(liElement);
        }

        name.value = '';
        age.value = '';
        kind.value = '';
        owner.value = '';
    }

    function changeBtn(ev) {
        const currentLiElement = ev.target.parentElement;
        const currentButton = ev.target;
        currentButton.textContent = 'Yes! I take it!';
        currentButton.removeEventListener('click', changeBtn);

        const divElement = document.createElement('div');
        const inputElement = document.createElement('input');
        inputElement.setAttribute('placeholder', 'Enter your names');

        divElement.appendChild(inputElement);
        divElement.appendChild(currentButton);
        currentLiElement.appendChild(divElement);

        currentButton.addEventListener('click', adopt);
    }

    function adopt(ev) {
        const currentBtn = ev.target;
        const newOwnerInput = ev.target.parentElement.querySelector('#adoption input');
        if (newOwnerInput.value != '') {
            const currentLiElement = ev.target.parentElement.parentElement;
            const ownerElement = currentLiElement.querySelector('span');
            ownerElement.textContent = `New Owner: ${newOwnerInput.value}`;
            const divElementToRemove = currentLiElement.querySelector('div');
            currentLiElement.removeChild(divElementToRemove);
            adoptedSectionUl.appendChild(currentLiElement);


            const checkedBtn = document.createElement('button');
            checkedBtn.textContent = 'Checked';
            currentLiElement.appendChild(checkedBtn);

            checkedBtn.addEventListener('click', removePet)
        }
    }

    function removePet(ev) {

        ev.target.parentElement.remove();
    }
}

