class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            'child': 150,
            'student': 300,
            'collegian': 500,
        }
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        const currentParticipant = {
            name,
            condition,
            power: 100,
            wins: 0
        };

        const exists = this.listOfParticipants.find(x => x.name == name);
        if (exists != undefined) {
            return `The ${name} is already registered at the camp.`;
        }

        let allowedConditions = Object.keys(this.priceForTheCamp);
        if (!allowedConditions.includes(condition)) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        const priceForStay = this.priceForTheCamp[condition];
        if (money < priceForStay) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        this.listOfParticipants.push(currentParticipant);

        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name) {
        const exists = this.listOfParticipants.find(x => x.name == name);

        if (exists == undefined) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        const index = this.listOfParticipants.indexOf(exists);
        this.listOfParticipants.splice(index, 1);

        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, firstName, ...secondName) {
        const firstParticipant = this.listOfParticipants.find(x => x.name == firstName);
        if (firstParticipant == undefined) {
            throw new Error('Invalid entered name/s.')
        }

        if (typeOfGame == 'Battleship') {
            firstParticipant.power += 20;
            return `The ${firstParticipant.name} successfully completed the game ${typeOfGame}.`;
        }
        else if (typeOfGame == 'WaterBalloonFights') {
            const secondParticipant = this.listOfParticipants.find(x => x.name == secondName[0]);
            if (secondParticipant == undefined) {
                throw new Error(`Invalid entered name/s.`)
            }

            if (firstParticipant.condition != secondParticipant.condition) {
                throw new Error(`Choose players with equal condition.`);
            }

            if (firstParticipant.power > secondParticipant.power) {
                firstParticipant.wins++;
                return `The ${firstParticipant.name} is winner in the game ${typeOfGame}.`
            }
            else if (secondParticipant.power > firstParticipant.power) {
                secondParticipant.wins++;
                return `The ${secondParticipant.name} is winner in the game ${typeOfGame}.`
            }
            else {
                return `There is no winner.`;
            }
        }
    }

    toString() {
        const sortedParticipants = this.listOfParticipants.sort((a, b) => b.wins - a.wins);
        const participants = sortedParticipants.map(x => `${x.name} - ${x.condition} - ${x.power} - ${x.wins}`);

        const resultString = [
            `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`,
            participants.join('\n')
        ]

        return resultString.join('\n');
    }
}

// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 200));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Leila Wolfe", "childd", 200));

// console.log('*'.repeat(50));

// const summerCamp2 = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp2.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp2.unregisterParticipant("Petar"));
// console.log(summerCamp2.unregisterParticipant("Petar Petarson"));

// console.log('*'.repeat(50));

// const summerCamp3 = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp3.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp3.timeToPlay("Battleship", "Petar Petarson"));
// console.log(summerCamp3.registerParticipant("Sara Dickinson", "child", 200));
// //console.log(summerCamp3.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
// console.log(summerCamp3.registerParticipant("Dimitur Kostov", "student", 300));
// console.log(summerCamp3.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

// console.log('*'.repeat(50));

const summerCamp4 = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp4.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp4.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp4.registerParticipant("Sara Dickinson", "child", 200));
//console.log(summerCamp4.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp4.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp4.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp4.toString());

