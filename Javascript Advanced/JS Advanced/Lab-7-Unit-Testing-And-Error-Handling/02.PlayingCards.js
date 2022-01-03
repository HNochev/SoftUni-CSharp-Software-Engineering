function solve(face, suit) {


    let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let suits = new Map();
    suits.set('S', '\u2660');
    suits.set('H', '\u2665');
    suits.set('D', '\u2666');
    suits.set('C', '\u2663');


    if (!faces.includes(face) || !suits.has(suit)) {
        throw new Error('Error');
    }
    suit = suits.get(suit);

    let card = {
        face,
        suit,
        toString: () => {
            return face + suit;
        }
    }

    return `${card}`;
}

try {
    console.log(solve('A', 'S'));
    console.log(solve('1', 'C'));
}
catch (e) {
    console.log(e.message);
}