function solve() {
    const [name, hall, ticketPrice] = document.querySelectorAll('#container input');
    const movies = document.querySelector('#movies ul');
    const archive = document.querySelector('#archive ul');
    document.querySelector('#archive button').addEventListener('click', deleteArchive);
    document.querySelector('#container button').addEventListener('click', addNewMovie);

    function addNewMovie(ev) {
        ev.preventDefault();

        if (name.value != '' && hall.value != '' && ticketPrice.value != '' && !isNaN(Number(ticketPrice.value))) {
            const liElement = document.createElement('li');
            const movieNameElement = document.createElement('span');
            const hallNameElement = document.createElement('strong');
            const ticketsDiv = document.createElement('div');
            const ticketPriceElement = document.createElement('strong');
            const ticketsCountInputElements = document.createElement('input');
            ticketsCountInputElements.placeholder = 'Tickets Sold';
            const archiveButtonElement = document.createElement('button');
            archiveButtonElement.textContent = 'Archive';
            archiveButtonElement.addEventListener('click', archiveMovie);

            movieNameElement.textContent = name.value;
            hallNameElement.textContent = `Hall: ${hall.value}`;
            ticketPriceElement.textContent = Number(ticketPrice.value).toFixed(2);

            liElement.appendChild(movieNameElement);
            liElement.appendChild(hallNameElement);
            ticketsDiv.appendChild(ticketPriceElement);
            ticketsDiv.appendChild(ticketsCountInputElements);
            ticketsDiv.appendChild(archiveButtonElement);
            liElement.appendChild(ticketsDiv);
            movies.appendChild(liElement);
        }

        name.value = '';
        hall.value = '';
        ticketPrice.value = '';
    }

    function archiveMovie(ev) {
        const ticketsSoldInput = ev.target.parentElement.querySelector('input');

        if (ticketsSoldInput.value != '' && !isNaN(Number(ticketsSoldInput.value))) {
            const movieElement = ev.target.parentElement.parentElement;
            const movieName = movieElement.querySelector('span').textContent;
            const moviePrice = movieElement.querySelector('#movies div strong').textContent;

            const liElement = document.createElement('li');
            const movieNameSpanElement = document.createElement('span');
            movieNameSpanElement.textContent = movieName;
            const totalAmount = document.createElement('strong');
            const totalPrice = Number(moviePrice) * Number(ticketsSoldInput.value);
            totalAmount.textContent = `Total amount: ${totalPrice.toFixed(2)}`;
            const deleteButton = document.createElement('button');
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', deleteMovie);

            liElement.appendChild(movieNameSpanElement);
            liElement.appendChild(totalAmount);
            liElement.appendChild(deleteButton);
            archive.appendChild(liElement);
        }
    }

    function deleteMovie(ev) {
        ev.target.parentElement.remove();
    }

    function deleteArchive(ev) {
        ev.target.parentElement.querySelector('ul').textContent = '';
    }
}