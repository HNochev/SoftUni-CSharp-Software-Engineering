const { assert } = require('chai');
let testNumbers = require('../03.Third');

describe("Tests Thrid Exam Task", () => {
    describe("TODO …", () => {
        it("Should check if parameters are numbers", () => {
            assert.strictEqual(testNumbers.sumNumbers('abc', 2), undefined);
            assert.strictEqual(testNumbers.sumNumbers(2, 'abc'), undefined);
            assert.strictEqual(testNumbers.sumNumbers('bgaming', 'abc'), undefined);
            assert.strictEqual(testNumbers.sumNumbers(false, true), undefined);
        });

        it("Should return correct sum", () => {
            assert.strictEqual(testNumbers.sumNumbers(2, 2), (4).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(2.3,2.3), (4.60).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(2.55,2.55), (5.10).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(2.54332,2.2213123), (4.76).toFixed(2));
        });

    });

    describe("TODO …", () => {
        it("Should throw if input is not a number", () => {
            assert.throws(()=> testNumbers.numberChecker('abv'), Error);
            assert.throws(()=> testNumbers.numberChecker(NaN), Error);
        });

        it("Should return even", () => {
            assert.strictEqual(testNumbers.numberChecker(2), 'The number is even!');
            assert.strictEqual(testNumbers.numberChecker('4'), 'The number is even!');
        });

        it("Should return odd", () => {
            assert.strictEqual(testNumbers.numberChecker(3), 'The number is odd!');
            assert.strictEqual(testNumbers.numberChecker('5'), 'The number is odd!');
        });
    });

    describe("TODO …", () => {
        it("Should return correct sum array", () => {
            let arr = [1,2,3,4, 6,7,8,9];

            assert.strictEqual(testNumbers.averageSumArray(arr), 5);
        });
    });
});
