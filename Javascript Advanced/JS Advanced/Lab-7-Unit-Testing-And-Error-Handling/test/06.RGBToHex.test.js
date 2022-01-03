const { assert } = require('chai');
const rgbToHexColor = require('../06.RGBToHex');

describe('Test RGBToHexColor functionality', () => {
    it('Should pass when correct colors are provided', () => {
        let red = 48;
        let green = 03;
        let blue = 15;

        let expectedResult = '#30030F';

        let actualResult = rgbToHexColor(red, green, blue);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Should pass when correct smallest colors are provided', () => {
        let red = 0;
        let green = 0;
        let blue = 0;

        let expectedResult = '#000000';

        let actualResult = rgbToHexColor(red, green, blue);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Should pass when correct biggest colors are provided', () => {
        let red = 255;
        let green = 255;
        let blue = 255;

        let expectedResult = '#FFFFFF';

        let actualResult = rgbToHexColor(red, green, blue);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Should fail when wrong colors are provided', () => {
        let red = 2424;
        let green = 2324;
        let blue = 2342;

        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Should fail when wrong red is provided', () => {
        let red = -18;
        let green = 10;
        let blue = 10;

        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Should fail when wrong blue is provided', () => {
        let red = 10;
        let green = 10;
        let blue = -10;

        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Should fail when wrong green is provided', () => {
        let red = 10;
        let green = -1;
        let blue = 10;

        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Should fail when wrong type input is provided', () => {
        let red = 10;
        let green = 'b';
        let blue = 10;

        let expectedResult = undefined;

        let actualResult = rgbToHexColor(red, green, blue);

        assert.strictEqual(actualResult, expectedResult);
    });

    it('Should fail when no input is provided', () => {
        let expectedResult = undefined;

        let actualResult = rgbToHexColor();

        assert.strictEqual(actualResult, expectedResult);
    });
});
