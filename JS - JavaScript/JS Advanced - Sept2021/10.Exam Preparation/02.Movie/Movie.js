class Movie {
    constructor(movieName, ticketPrice) {
        this.movieName = movieName;
        this.ticketPrice = Number(ticketPrice);
        this.screenings = [];
        this.totalTicketsSold = 0;
        this.totalProfit = 0;
    }

    newScreening(date, hall, description) {
        const currentScreening = {
            date,
            hall,
            description
        };
        const exists = this.screenings.find((x) => x.date == date && x.hall == hall);

        if (exists != undefined) {
            throw new Error(`Sorry, ${hall} hall is not available on ${date}`);
        }

        this.screenings.push(currentScreening);
        return `New screening of ${this.movieName} is added.`;
    }

    endScreening(date, hall, soldTickets) {
        const exists = this.screenings.find((x) => x.date == date && x.hall == hall);

        if (exists == undefined) {
            throw new Error(`Sorry, there is no such screening for ${this.movieName} movie.`);
        }

        const index = this.screenings.indexOf(exists);
        this.screenings.splice(index, 1);

        const currentProfit = soldTickets * this.ticketPrice;
        this.totalTicketsSold += soldTickets;
        this.totalProfit += currentProfit;
        return `${this.movieName} movie screening on ${date} in ${hall} hall has ended. Screening profit: ${currentProfit}`
    }

    toString() {
        let result = [
            `${this.movieName} full information:`,
            `Total profit: ${this.totalProfit.toFixed(0)}$`,
            `Sold Tickets: ${this.totalTicketsSold}`,
        ];
        if (this.screenings.length > 0) {
            result.push(`Remaining film screenings:`);
            let sorted = this.screenings.sort((a, b) => a.hall.localeCompare(b.hall));
            for (const s of sorted) {
                result.push(`${s.hall} - ${s.date} - ${s.description}`);
            }
        } else {
            result.push(`No more screenings!`);
        }
        return result.join("\n");
    }
}

let m = new Movie('Wonder Woman 1984', '10.00');
console.log(m.newScreening('October 2, 2020', 'IMAX 3D', `3D`));
console.log(m.newScreening('October 3, 2020', 'Main', `regular`));
console.log(m.newScreening('October 4, 2020', 'IMAX 3D', `3D`));
console.log(m.endScreening('October 2, 2020', 'IMAX 3D', 150));
console.log(m.endScreening('October 3, 2020', 'Main', 78));
console.log(m.toString());

m.newScreening('October 4, 2020', '235', `regular`);
m.newScreening('October 5, 2020', 'Main', `regular`);
m.newScreening('October 3, 2020', '235', `regular`);
m.newScreening('October 4, 2020', 'Main', `regular`);
console.log(m.toString());
