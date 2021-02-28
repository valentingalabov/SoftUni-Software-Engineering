function cards(face, suit) {
    const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    const suitToString = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663'
    }

    if (validFaces.includes(face) == false) {
        throw new Error('Invalid Face');
    } else if (Object.keys(suitToString).includes(suit) == false)
        throw new Error('Invalid Suit');

    return {
        face,
        suit,
        toString() {
            return `${face}${suitToString[suit]}`;
        }
    }
}

const myCard = cards('A', 'S');
console.log(myCard.toString());

const myCard1 = cards('10', 'H');
console.log(myCard1.toString());

const myCard2 = cards('1', 'C');
console.log(myCard2.toString());