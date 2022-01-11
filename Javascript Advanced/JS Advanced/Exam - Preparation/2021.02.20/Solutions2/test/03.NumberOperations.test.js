const { assert } = require('chai');
let numberOperations = require('../03.NumberOperations');

describe("Testsn umberOperations", () => {
    describe("testNum", () => {
        it("Should use it properly", () => {
            assert.strictEqual(numberOperations.powNumber(4), 16);
            assert.closeTo(numberOperations.powNumber(2.3), 5.3, 0.1);
        });
    });

    describe("numberChecker", () => {
        it("Throw error if it is not an number", () => {
            assert.throws(() => numberOperations.numberChecker('abc'), Error);
            assert.throws(() => numberOperations.numberChecker(NaN), Error);
        });

        it("Should return massage if it is smaller than 100", () => {
            assert.strictEqual(numberOperations.numberChecker(99), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker('99'), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker(2.5), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker('99.9'), 'The number is lower than 100!');
            'The number is greater or equal to 100!'
        });

        it("Should return massage if it is greater or eaqal than 100", () => {
            assert.strictEqual(numberOperations.numberChecker(100), 'The number is greater or equal to 100!');
            assert.strictEqual(numberOperations.numberChecker('101'), 'The number is greater or equal to 100!');
            assert.strictEqual(numberOperations.numberChecker(229.5), 'The number is greater or equal to 100!');
            assert.strictEqual(numberOperations.numberChecker('100.9'), 'The number is greater or equal to 100!');
            'The number is greater or equal to 100!'
        });
    });

    describe("sumArrays", () => {
        it("Should return summed array", () => {
            let array1 = [1, 2, 3, 4, 5, 6, 2.2];
            let array2 = [3, 3, 2, 5];



            assert.deepEqual(numberOperations.sumArrays(array1, array2), [4, 5, 5, 9, 5, 6, 2.2]);
        });
    });
});
