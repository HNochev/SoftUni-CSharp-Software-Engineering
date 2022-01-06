
const { assert } = require('chai');
let PaymentPackage = require('../12.PaymentPackage');

describe('PaymentPackage', () => {
    describe('constructor', () => {
        it('Shoud throw new error if name is not string', () => {
            assert.throws(() => new PaymentPackage(3.14, 5), Error);
            assert.throws(() => new PaymentPackage(true, 5), Error);
        });

        it('Shoud throw new error if name is null', () => {
            assert.throws(() => new PaymentPackage('', 5), Error);
            assert.throws(() => new PaymentPackage(null, 5), Error);
        });

        it('Shoud return correct output if name and value are correct', () => {
            let expected = 'Package: Bgaming\n- Value (excl. VAT): 100\n- Value (VAT 20%): 120';
            let paymentPackage = new PaymentPackage('Bgaming', 100);

            assert.strictEqual(paymentPackage.toString(), expected);
        });

        it('Shoud return correct output if name and value are correct on edge', () => {
            let expected = 'Package: B\n- Value (excl. VAT): 0\n- Value (VAT 20%): 0';
            let paymentPackage = new PaymentPackage('B', 0);

            assert.strictEqual(paymentPackage.toString(), expected);
        });
        it('Shoud return correct output if name and value are correct on edge', () => {
            let expected = 'Package: Bg\n- Value (excl. VAT): 2.45\n- Value (VAT 20%): 2.94';
            let paymentPackage = new PaymentPackage('Bg', 2.45);

            assert.strictEqual(paymentPackage.toString(), expected);
        });

        it('Shoud throw new error if value is not number', () => {
            assert.throws(() => new PaymentPackage('Bgaming', 'Bgaming'), Error);
            assert.throws(() => new PaymentPackage('Bgaming', true), Error);
            assert.throws(() => new PaymentPackage('Bgaming', []), Error);
        });

        it('Shoud throw new error if value is small than 0', () => {
            assert.throws(() => new PaymentPackage('dsf', -1), Error);
            assert.throws(() => new PaymentPackage('sffs', -1000), Error);
        });

        it('Shoud throw new error if VAT is not number', () => {
            let test = new PaymentPackage('Bgaming', 100);

            assert.throws(() => test.VAT = true, Error);
            assert.throws(() => test.VAT = 'string', Error);
            assert.throws(() => test.VAT = [], Error);
        });

        it('Shoud throw new error if VAT is small than 0', () => {
            let test = new PaymentPackage('Bgaming', 100);

            assert.throws(() => test.VAT = -1, Error);
            assert.throws(() => test.VAT = -1000, Error);
        });

        it('Shoud throw new error if active is not boolean', () => {
            let test = new PaymentPackage('Bgaming', 100);

            assert.throws(() => test.active = 3.2, Error);
            assert.throws(() => test.active = 'string', Error);
            assert.throws(() => test.active = [], Error);
        });

        it('Shoud have correct defaut values when correct others passed', () => {
            let test = new PaymentPackage('Bgaming', 100);

            assert.strictEqual(test.VAT, 20);
            assert.strictEqual(test.active, true);
        });

        it('Should return correct string representation with false active', () => {
            let test = new PaymentPackage('B', 1);

            test.active = false;

            let expected = 'Package: B (inactive)\n- Value (excl. VAT): 1\n- Value (VAT 20%): 1.2';

            assert.strictEqual(test.toString(), expected);
        });
    });
});