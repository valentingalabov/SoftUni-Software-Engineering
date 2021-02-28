function printDeckOfCards(cards) {
    try {
        function createCard(face, suit) {
            const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
            const suitToString = {
                'S': '\u2660',
                'H': '\u2665',
                'D': '\u2666',
                'C': '\u2663'
            }

            if (validFaces.includes(face) == false) {
                throw new Error(`Invalid card: ${face}${suit}`);
            } else if (Object.keys(suitToString).includes(suit) == false)
                throw new Error(`Invalid card: ${face}${suit}`);

            return {
                face,
                suit,
                toString() {
                    return `${face}${suitToString[suit]}`;
                }
            }
        }
        let result = [];
        for (let card of cards) {
            let face = '';
            let suit = '';
            if (card.length == 3) {
                face = card[0] + card[1];
                suit = card[2];

            } else {
                face = card[0];
                suit = card[1];
            }

            result.push(createCard(face, suit).toString());

        }

        console.log(result.join(' '));
        
    } catch (error) {
        console.log(error.message);
    }
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);
