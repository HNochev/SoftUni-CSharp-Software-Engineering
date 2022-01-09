const { assert } = require('chai');
let ChristmasMovies = require('../02.ChristmasMovies');

describe("Tests ChristmasMovies", () => {
    describe("buyMovie", () => {
        it('Should add new movie if movie is not in the collection', () => {
            let christmas = new ChristmasMovies();

            christmas.buyMovie('Home Alone 3', ['A', 'B', 'C']);

            assert.strictEqual(christmas.movieCollection.length, 1);
            assert.strictEqual(christmas.buyMovie('Iron Man 1', ['Robert Downie Jr', 'Chris Alan']), `You just got Iron Man 1 to your collection in which Robert Downie Jr, Chris Alan are taking part!`);
            assert.strictEqual(christmas.movieCollection.length, 2);

        });

        it('Should add only unique actors if is not in the collection', () => {
            let christmas = new ChristmasMovies();

            assert.strictEqual(christmas.buyMovie('Iron Man 1', ['A', 'B', 'A', 'C', 'A']), `You just got Iron Man 1 to your collection in which A, B, C are taking part!`);


        });

        it('Should throw an error if name is the same', () => {
            let christmas = new ChristmasMovies();

            christmas.buyMovie('Home Alone 3', ['A', 'B', 'C']);

            assert.strictEqual(christmas.movieCollection.length, 1);
            assert.throws(() => christmas.buyMovie('Home Alone 3', ['Robert Downie Jr', 'Chris Alan']), Error, `You already own Home Alone 3 in your collection!`);
        });


    });

    describe("discardMovie", () => {
        it('Should remove new movie if movie is in the collection and is watched', () => {
            let christmas = new ChristmasMovies();

            christmas.buyMovie('Home Alone 3', ['A', 'B', 'C']);
            christmas.watchMovie('Home Alone 3');

            assert.strictEqual(christmas.discardMovie('Home Alone 3'), `You just threw away Home Alone 3!`)
            assert.strictEqual(christmas.movieCollection.length, 0);

        });

        it('Should throw error if it is not watched', () => {
            let christmas = new ChristmasMovies();

            christmas.buyMovie('Home Alone 3', ['A', 'B', 'C']);

            assert.throws(() => christmas.discardMovie('Home Alone 3'), Error, `Home Alone 3 is not watched!`);

        });

        it('Should throw an error if name is the same', () => {
            let christmas = new ChristmasMovies();

            christmas.buyMovie('Home Alone 3', ['A', 'B', 'C']);

            assert.throws(() => christmas.discardMovie('Home Alone 2', ['Robert Downie Jr', 'Chris Alan']), Error, `Home Alone 2 is not at your collection!`);
        });
    });

    describe("watchMovie", () => {
        it('Should throw error if there is no shuch movie', () => {
            let christmas = new ChristmasMovies();

            christmas.buyMovie('Home Alone 3', ['A', 'B', 'C']);

            assert.throws(() => christmas.watchMovie('Home Alone 1'), Error, 'No such movie in your collection!');

        });
    });

    describe("favouriteMovie", () => {
        it('Should throw error if there is no watched movie', () => {
            let christmas = new ChristmasMovies();

            christmas.buyMovie('Home Alone 3', ['A', 'B', 'C']);

            assert.throws(() => christmas.favouriteMovie(), Error, 'You have not watched a movie yet this year!');
        });

        it('Should return string with most watched movie this year', () => {
            let christmas = new ChristmasMovies();

            christmas.buyMovie('Home Alone 3', ['A', 'B', 'C']);
            christmas.buyMovie('Home Alone 2', ['Macaulay Culkin']);

            christmas.watchMovie('Home Alone 3');
            christmas.watchMovie('Home Alone 3');
            christmas.watchMovie('Home Alone 3');
            christmas.watchMovie('Home Alone 2');

            assert.strictEqual(christmas.favouriteMovie(), `Your favourite movie is Home Alone 3 and you have watched it 3 times!`);
        });
    });

    describe("mostStarredActor", () => {
        it('Should throw error if there is no watched movie', () => {
            let christmas = new ChristmasMovies();


            assert.throws(() => christmas.mostStarredActor(), Error, 'You have not watched a movie yet this year!');
        });

        it('Should return string with most watched movie this year', () => {
            let christmas = new ChristmasMovies();

            christmas.buyMovie('Home Alone 3', ['A', 'B', 'C']);
            christmas.buyMovie('Home Alone 2', ['A']);

            christmas.watchMovie('Home Alone 3');
            christmas.watchMovie('Home Alone 3');
            christmas.watchMovie('Home Alone 3');
            christmas.watchMovie('Home Alone 2');

            assert.strictEqual(christmas.mostStarredActor(), `The most starred actor is A and starred in 2 movies!`);
        });
    });
});
