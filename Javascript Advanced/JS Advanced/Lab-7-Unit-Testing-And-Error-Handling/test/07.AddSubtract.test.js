const { assert, expect } = require('chai');
const createCalculator = require('../07.AddSubtract');

describe('Test addSubstract functionality', () => {
    it('Should add when correct num is provided', () => {
        let calculator = createCalculator();
        let expectedResult = 1;
        calculator.add(1);
        let actualResult = calculator.get();

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Should substract when correct num is provided', () => {
        let calculator = createCalculator();
        let expectedResult = -1;
        calculator.subtract(1);
        let actualResult = calculator.get();

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Should get when correct get is provided', () => {
        let calculator = createCalculator();
        let expectedResult = 0;
        let actualResult = calculator.get();

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Should fail when wrong num is provided', () => {
        let calculator = createCalculator();

        calculator.add('dsf');
        let actualResult = calculator.get();

        expect(actualResult).to.be.NaN;
    });

    it('Should work when strinng num is provided', () => {
        let calculator = createCalculator();

        let expectedResult = 1;
        calculator.add('1');
        let actualResult = calculator.get();

        assert.strictEqual(actualResult, expectedResult);
    });
});