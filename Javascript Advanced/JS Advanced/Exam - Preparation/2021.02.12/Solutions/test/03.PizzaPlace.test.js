const { assert } = require('chai');
let pizzUni = require('../03.PizzaPlace');

describe("Tests Pizza Place", () => {
    describe("makeAnOrder", () => {
        it('Should throw an error if obj is empty', () => {
            let obj = {

            };

            assert.throws(() => pizzUni.makeAnOrder(obj), Error);
        });

        it('Should throw an error if no input', () => {
            assert.throws(() => pizzUni.makeAnOrder(), Error);
        });

        it('Should return string if you add pizza', () => {
            let obj = {
                orderedPizza: 'Pizza',
            };

            let expected = `You just ordered Pizza`

            assert.strictEqual(pizzUni.makeAnOrder(obj), expected);
        });

        it('Should return string if you add pizzas', () => {
            let obj = {
                orderedPizza: 'Pizza, Kapone',
            };

            let expected = `You just ordered Pizza, Kapone`

            assert.strictEqual(pizzUni.makeAnOrder(obj), expected);
        });

        it('Should return string if you add pizza and drink', () => {
            let obj = {
                orderedPizza: 'Pizza, Kapone',
                orderedDrink: 'Cola',
            };

            let expected = `You just ordered Pizza, Kapone and Cola.`

            assert.strictEqual(pizzUni.makeAnOrder(obj), expected);
        });

        it('Should throw error if you order only drink', () => {
            let obj = {
                orderedDrink: 'Cola',
            };

            assert.throws(() => pizzUni.makeAnOrder(obj), Error);
        });
    });

    describe("getRemainingWork", () => {

        it('Shoud return message if all pizzas are ready', () => {
            let pizzaOne = { pizzaName: 'Pizza1', status: 'ready' };
            let pizzaTwo = { pizzaName: 'Pizza2', status: 'ready' };

            let statusArr = [pizzaOne, pizzaTwo];

            assert.strictEqual(pizzUni.getRemainingWork(statusArr), 'All orders are complete!');
        });

        it('Shoud return message if not all pizzas are ready', () => {
            let pizzaOne = { pizzaName: 'Pizza1', status: 'ready' };
            let pizzaTwo = { pizzaName: 'Pizza2', status: 'preparing' };

            let statusArr = [pizzaOne, pizzaTwo];

            assert.strictEqual(pizzUni.getRemainingWork(statusArr), `The following pizzas are still preparing: ${pizzaTwo.pizzaName}.`);
        });

        it('Shoud return message if all pizzas are not ready', () => {
            let pizzaOne = { pizzaName: 'Pizza1', status: 'preparing' };
            let pizzaTwo = { pizzaName: 'Pizza2', status: 'preparing' };

            let statusArr = [pizzaOne, pizzaTwo];

            assert.strictEqual(pizzUni.getRemainingWork(statusArr), `The following pizzas are still preparing: Pizza1, Pizza2.`);
        });
    });

    describe("orderType", () => {

        it('Should return price with discont if typeOfOrder = Carry Out', () => {
            let totalSum = 10;
            let typeOfOrder = 'Carry Out';

            assert.strictEqual(pizzUni.orderType(totalSum, typeOfOrder), 9);
        });

        it('Should return price with discont if typeOfOrder = Delivery', () => {
            let totalSum = 10;
            let typeOfOrder = 'Delivery';

            assert.strictEqual(pizzUni.orderType(totalSum, typeOfOrder), 10);
        });
    });
});
