const { assert } = require('chai');
const sum = require('../04.SumOfNumbers');

it('Shoud add positive numbers', () => {
    //Arange
    let input = [1, 2, 3, 4, 5];
    let expectedResult = 15;
    //Act
    let actualResult = sum(input);
    //Assert
    assert.strictEqual(actualResult, expectedResult);
});

it('Shoud add positive numbers', () => {
    //Arange
    let input = [1];
    let expectedResult = 1;
    //Act
    let actualResult = sum(input);
    //Assert
    assert.strictEqual(actualResult, expectedResult);
});

it('Shoud add positive numbers', () => {
    //Arange
    let input = [1, 1, 1, 1, 1];
    let expectedResult = 5;
    //Act
    let actualResult = sum(input);
    //Assert
    assert.strictEqual(actualResult, expectedResult);
});