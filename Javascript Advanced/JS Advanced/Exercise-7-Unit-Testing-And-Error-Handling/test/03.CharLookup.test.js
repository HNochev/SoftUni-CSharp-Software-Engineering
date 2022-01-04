const { assert } = require('chai');
let lookupChar = require('../03.CharLookup');

describe('lookupChar testing functionalities', () => {
    it('Shoud return undefined when first parameter is not string', () => {
        let expectedResult = undefined;
        let actualResult = lookupChar(5353, 2);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Shoud return undefined when second parameter can not be parsed to int', () => {
        let expectedResult = undefined;
        let actualResult = lookupChar('5353', 3.14);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Shoud return "Incorrect index" when second parameter is out of range', () => {
        let expectedResult = 'Incorrect index';

        assert.strictEqual(lookupChar('string', -1), expectedResult);
        assert.strictEqual(lookupChar('string', 10), expectedResult);
    });

    it('Shoud return correct char when parameters are correct', () => {

        assert.strictEqual(lookupChar('string', 0), 's');
        assert.strictEqual(lookupChar('string', 5), 'g');
    });
});