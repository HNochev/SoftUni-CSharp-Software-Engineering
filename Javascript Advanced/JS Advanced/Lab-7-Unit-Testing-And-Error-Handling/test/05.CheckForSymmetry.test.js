const { assert } = require('chai');
const isSymmetric = require('../05.CheckForSymmetry');

describe('Test isSymetric functionality', () => {
    it('Should pass when symetric result is provided', () => {
        let input = [1, 2, 3, 2, 1];
        let expectedResult = true;

        let actualResult = isSymmetric(input);

        assert.equal(actualResult, expectedResult);
    });

    it('Should fail when non symetric result is provided', () => {
        let input = [1, 3, 3, 2, 1];
        let expectedResult = false;

        let actualResult = isSymmetric(input);

        assert.equal(actualResult, expectedResult);
    });

    it('Should fail when non array is provided', () => {
        let expectedResult = false;

        assert.equal(isSymmetric(null), expectedResult);
        assert.equal(isSymmetric({}), expectedResult);
        assert.equal(isSymmetric(''), expectedResult);
        assert.equal(isSymmetric(0), expectedResult);
        assert.equal(isSymmetric(true), expectedResult);
        assert.equal(isSymmetric(undefined), expectedResult);
    });

    it('Should pass when empty array is provided', () => {
        let input = [];
        let expectedResult = true;

        let actualResult = isSymmetric(input);

        assert.equal(actualResult, expectedResult);
    });

    it('Should pass when one element array is provided', () => {
        let input = ['1'];
        let expectedResult = true;

        let actualResult = isSymmetric(input);

        assert.equal(actualResult, expectedResult);
    });

    it('Should fail when elements of types are provided', () => {
        let input = ['1', 1];
        let expectedResult = false;

        let actualResult = isSymmetric(input);

        assert.equal(actualResult, expectedResult);
    });
});