function solve(deck) {

    let result = [];
    let invalidCard = '';
    for (const card of deck) {
        let face = card.substring(0, card.length - 1);
        let suit = card[card.length - 1];
        let resultCard = '';

        if (Number.isInteger(face)) {
            throw new Error();
        }
        let numberFace = Number(face);
        if ((numberFace >= 2 && numberFace <= 10) || face === 'J' || face === 'Q' || face === 'K' || face === 'A') {
            resultCard += face;
        } else {
            invalidCard = card;
            break;
        }
            if (suit === 'S') {
                resultCard += '\u2660';
            }else if (suit === 'H') {
                resultCard += '\u2665';
            }else if (suit === 'D') {
                resultCard += '\u2666';
            }else if (suit === 'C') {
                resultCard += '\u2663';
            }else {
            invalidCard = card;
            break;
        }

        result.push(resultCard);
    }

    if (invalidCard ==='') {
        console.log(result.join(' '));
    } else {
        console.log(`Invalid card: ${invalidCard}`);
    }
}

solve(['AS', '10D', 'KH', '2C']);