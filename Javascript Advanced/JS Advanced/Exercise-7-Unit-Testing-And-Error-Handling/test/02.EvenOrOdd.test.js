const { assert } = require('chai');
let isOddOrEven = require('../02.EvenOrOdd');

describe('isOddOrEven functionalities tests', () => {
    it('Should return undefined when variable is not string', () => {

        let expectedResult = undefined;
        let actualResult = isOddOrEven(434);

        assert.strictEqual(actualResult, expectedResult);
    });
    it('Should return even when variable has even length', () => {

        let expectedResult = 'even';
        let actualResult = isOddOrEven('43');

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Should return odd when variable has odd lenght', () => {

        assert.strictEqual(isOddOrEven('o'), 'odd');

    });
})