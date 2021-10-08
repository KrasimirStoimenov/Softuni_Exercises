function solve() {
    const [name, hall, ticketPrice] = document.querySelectorAll('#container input');
    const movies = document.querySelector('#movies ul');
    const archive = document.querySelector('#archive ul');
    document.querySelector('#container button').addEventListener('click', addNewMovie);

    function addNewMovie(ev) {
        ev.preventDefault();

        if (name.value != '' && hall.value != '' && !isNaN(Number(ticketPrice.value))) {
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
            const movieName = movieElement.querySelector('span');
            console.log(movieName);
        }
    }
}