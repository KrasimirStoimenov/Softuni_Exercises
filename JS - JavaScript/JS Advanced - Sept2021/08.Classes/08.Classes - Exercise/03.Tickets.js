function solve(tickets, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    const ticketsObjects = [];

    tickets.forEach(ticket => {
        const [destination, price, status] = ticket.split('|');
        const currentTicket = new Ticket(destination, Number(price), status);

        ticketsObjects.push(currentTicket);
    });

    if (criteria == 'destination') {
        ticketsObjects.sort((a, b) => a.destination.localeCompare(b.destination));
    }
    else if (criteria == 'price') {
        ticketsObjects.sort((a, b) => a.price - b.price);
    }
    else if (criteria == 'status') {
        ticketsObjects.sort((a, b) => a.status.localeCompare(b.status));
    }

    return ticketsObjects;
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'));

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'));