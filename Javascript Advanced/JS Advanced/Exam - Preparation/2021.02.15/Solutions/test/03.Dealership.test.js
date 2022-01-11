const { assert } = require('chai');
let dealership = require('../03.Dealership');


describe("Tests dealership", () => {
    describe("newCarCost", () => {

        it('Shoud give discount if car model is in the list', () => {
            assert.strictEqual(dealership.newCarCost('Audi A6 4K', 55000), 35000);
        });

        it('Shoudnt give discount if car model is not in the list', () => {
            assert.strictEqual(dealership.newCarCost('Opel', 55000), 55000);
        });
    });

    describe("carEquipment", () => {

        it('Shoud add all required extras', () => {
            let extrasArr = ['A', 'B', 'C', 'D', 'E'];
            let extrasSelected = [1, 2, 4];

            assert.strictEqual(dealership.carEquipment(extrasArr, extrasSelected)[0], 'B');
            assert.strictEqual(dealership.carEquipment(extrasArr, extrasSelected)[1], 'C');
            assert.strictEqual(dealership.carEquipment(extrasArr, extrasSelected)[2], 'E');
        });
    });

    describe("euroCategory", () => {

        it('Shoud return message when euro category is smaller than 4', () => {
            assert.strictEqual(dealership.euroCategory(3), 'Your euro category is low, so there is no discount from the final price!');
        });

        it('Shoud return message when euro category is bigger or equal to 4', () => {
            assert.strictEqual(dealership.euroCategory(4), `We have added 5% discount to the final price: 14250.`);
        });
    });
});
