const { assert } = require('chai');
let numberOperations = require('../03.NumberOperations');

describe("Tests number operations", () => {
    describe("powNumber", () => {
        it("Should return correct value", () => {
            assert.strictEqual(numberOperations.powNumber(4), 16);
            assert.closeTo(numberOperations.powNumber(2.2), 4.84, 0.001);
        });
    });

    describe("numberChecker", () => {
        it("Should throw error if input is NaN", () => {
            assert.throws(() => numberOperations.numberChecker(NaN), Error);
        });

        it("Should parse the input", () => {
            assert.strictEqual(numberOperations.numberChecker('45'), 'The number is lower than 100!')
        });

        it("Should return one string if input is smaller than 100", () => {
            assert.strictEqual(numberOperations.numberChecker(99), 'The number is lower than 100!')
        });

        it("Should return one string if input is биггер than 100", () => {
            assert.strictEqual(numberOperations.numberChecker(100), 'The number is greater or equal to 100!')
        });
    });

    describe("sumArrays", () => {
        it("Should throw error if input is NaN", () => {
            let array1 = [1, 2, 3, 4];
            let array2 = [1, 2, 3];

            let expected = [2, 4, 6, 4];

            assert.strictEqual(numberOperations.sumArrays(array1, array2)[0], expected[0]);
            assert.strictEqual(numberOperations.sumArrays(array1, array2)[1], expected[1]);
            assert.strictEqual(numberOperations.sumArrays(array1, array2)[2], expected[2]);
            assert.strictEqual(numberOperations.sumArrays(array1, array2)[3], expected[3]);
        });
    });
});

