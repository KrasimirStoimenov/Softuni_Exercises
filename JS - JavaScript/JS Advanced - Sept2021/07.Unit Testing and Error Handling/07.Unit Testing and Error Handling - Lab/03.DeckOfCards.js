function printDeckOfCards(cards) {
    function createCard(face, suit) {
        const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const validSuits = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663'
        };

        if (!validFaces.includes(face) || !Object.keys(validSuits).includes(suit)) {
            throw new Error('Error');
        }

        return {
            face: face,
            suit: validSuits[suit],
            toString() {
                return this.face + this.suit;
            }
        }
    }

    try {
        console.log(cards.map(card => {
            const face = card.slice(0, -1);
            const suit = card.slice(-1);
            try {
                return createCard(face, suit)
            } catch (error) {
                throw new Error(`Invalid card: ${card}`);
            }
        }).join(' '));
    } catch (error) {
        console.log(error.message);
    }
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);