const { assert } = require('chai');
let mathEnforcer = require('../04.MathEnforcer');

describe('mathEnforcer tests', () => {
    describe('addFive', () => {
        it('Should return undefined when parameter is not a number', () => {
            assert.strictEqual(mathEnforcer.addFive(undefined), undefined);
            assert.strictEqual(mathEnforcer.addFive(null), undefined);
            assert.strictEqual(mathEnforcer.addFive('20'), undefined);

//           expect(mathEnforcer.addFive(undefined)).to.equal(undefined);
//           expect(mathEnforcer.addFive(null)).to.equal(undefined);
//           expect(mathEnforcer.addFive('20')).to.equal(undefined);
        })
 
        it('Should return number plus 5 when parameter is valid number', () => {
            assert.strictEqual(mathEnforcer.addFive(10), 15);
            assert.closeTo(mathEnforcer.addFive(1.1 + 2.2), 8.3, 0.01);
            assert.strictEqual(mathEnforcer.addFive(-10), -5);
            
//          expect(mathEnforcer.addFive(10)).to.equal(15);
//          expect(mathEnforcer.addFive(1.1 + 2.2)).to.closeTo(8.3, 0.01);
//          expect(mathEnforcer.addFive(-10)).to.equal(-5);
        })
    })
 
    describe('subtractTen', () => {
        it('Should return undefined when parameter is not a number', () => {
            assert.strictEqual(mathEnforcer.subtractTen(undefined), undefined);
            assert.strictEqual(mathEnforcer.subtractTen(null), undefined);
            assert.strictEqual(mathEnforcer.subtractTen('20'), undefined);
           
//           expect(mathEnforcer.subtractTen(undefined)).to.equal(undefined);
//           expect(mathEnforcer.subtractTen(null)).to.equal(undefined);
//           expect(mathEnforcer.subtractTen('20')).to.equal(undefined);
        })
 
        it('Should return number plus 5 when parameter is valid number', () => {
            assert.strictEqual(mathEnforcer.subtractTen(10), 0);
            assert.closeTo(mathEnforcer.subtractTen(1.1 + 2.2), -6.7, 0.01);
            assert.strictEqual(mathEnforcer.subtractTen(-10), -20);
            
//          expect(mathEnforcer.subtractTen(10)).to.equal(0);
//          expect(mathEnforcer.subtractTen(1.1 + 2.2)).to.closeTo(-6.7, 0.01);
//          expect(mathEnforcer.subtractTen(-10)).to.equal(-20);
        })
    })
 
    describe('sum', () => {
        it('Should return undefined when first parameter is not a number', () => {
            assert.strictEqual(mathEnforcer.sum(undefined, 1), undefined);
            assert.strictEqual(mathEnforcer.sum(null, 1), undefined);
            assert.strictEqual(mathEnforcer.sum('20', 1), undefined);
            
//          expect(mathEnforcer.sum(undefined, 1)).to.equal(undefined);
//          expect(mathEnforcer.sum(null, 1)).to.equal(undefined);
//          expect(mathEnforcer.sum('13', 1)).to.equal(undefined);
        })
 
        it('Should return undefined when second parameter is not a number', () => {
            assert.strictEqual(mathEnforcer.sum(1, undefined), undefined);
            assert.strictEqual(mathEnforcer.sum(1, null), undefined);
            assert.strictEqual(mathEnforcer.sum(1, '20'), undefined);
           
//          expect(mathEnforcer.sum(1, undefined)).to.equal(undefined);
//          expect(mathEnforcer.sum(1, null)).to.equal(undefined);
//          expect(mathEnforcer.sum(1, '13')).to.equal(undefined);
        })
 
        it('Should return the sum of both numbers when both parameter are valid numbers', () => {
            assert.strictEqual(mathEnforcer.sum(10,20), 30);
            assert.closeTo(mathEnforcer.sum(1.1 + 2.2, 3.3), 6.6, 0,01);
            assert.strictEqual(mathEnforcer.sum(-10,-20), -30);
            
//          expect(mathEnforcer.sum(10, 20)).to.equal(30);
//          expect(mathEnforcer.sum(1.1 + 2.2, 3.3)).to.closeTo(6.6, 0.01);
//          expect(mathEnforcer.sum(-10, -5)).to.equal(-30);
        })
    })
});