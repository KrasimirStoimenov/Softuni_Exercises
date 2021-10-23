window.addEventListener('load', solve);

function solve() {
    const genre = document.querySelector('#genre');
    const name = document.querySelector('#name');
    const author = document.querySelector('#author');
    const date = document.querySelector('#date');
    const addBtn = document.querySelector('#add-btn');
    addBtn.addEventListener('click', addSong);
    const totalLikes = document.querySelector('#total-likes .likes p');

    function addSong(ev) {
        ev.preventDefault();

        if (genre.value != '' && name.value != '' && author.value != '' && date.value != '') {
            const allHitsContainer = document.querySelector('#all-hits .all-hits-container');
            const divHitsInfoElement = document.createElement('div');
            divHitsInfoElement.classList.add('hits-info');

            const imgElement = document.createElement('img');
            imgElement.src = './static/img/img.png';
            const genreHeadingElement = document.createElement('h2');
            genreHeadingElement.textContent = `Genre: ${genre.value}`;
            const nameHeadingElement = document.createElement('h2');
            nameHeadingElement.textContent = `Name: ${name.value}`;
            const authorHeadingElement = document.createElement('h2');
            authorHeadingElement.textContent = `Author: ${author.value}`;
            const dateHeadingElement = document.createElement('h3');
            dateHeadingElement.textContent = `Date: ${date.value}`;

            const saveBtn = document.createElement('button');
            saveBtn.classList.add('save-btn');
            saveBtn.textContent = 'Save song';
            saveBtn.addEventListener('click', saveSong)

            const likeBtn = document.createElement('button');
            likeBtn.classList.add('like-btn');
            likeBtn.textContent = 'Like song';
            likeBtn.addEventListener('click', () => {
                const [likesText, likes] = totalLikes.textContent.split(': ');
                let likesAsNumber = Number(likes);
                likesAsNumber++;
                totalLikes.textContent = `${likesText}: ${likesAsNumber}`;
                likeBtn.disabled = true;
            })

            const deleteBtn = document.createElement('button');
            deleteBtn.classList.add('delete-btn');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', () => {
                deleteBtn.parentElement.remove();
            })

            divHitsInfoElement.appendChild(imgElement);
            divHitsInfoElement.appendChild(genreHeadingElement);
            divHitsInfoElement.appendChild(nameHeadingElement);
            divHitsInfoElement.appendChild(authorHeadingElement);
            divHitsInfoElement.appendChild(dateHeadingElement);
            divHitsInfoElement.appendChild(saveBtn);
            divHitsInfoElement.appendChild(likeBtn);
            divHitsInfoElement.appendChild(deleteBtn);

            allHitsContainer.appendChild(divHitsInfoElement);
        }

        genre.value = '';
        name.value = '';
        author.value = '';
        date.value = '';
    }

    function saveSong(ev) {
        const savedHitsContainter = document.querySelector('#saved-hits .saved-container');
        const hitsInfoElement = ev.target.parentElement;
        hitsInfoElement.querySelector('.save-btn').remove();
        hitsInfoElement.querySelector('.like-btn').remove();
        savedHitsContainter.appendChild(hitsInfoElement);
    }
}