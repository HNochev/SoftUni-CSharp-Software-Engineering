let { assert, expect } = require('chai');
let StringBuilder = require('../13.StringBuilder');

describe('StringBuilder', () => {
    describe('constructor', () => {
        it('Shoud initialize with empty array if undefined is passed', () => {
            let sb = new StringBuilder(undefined);
            assert.strictEqual(sb.toString(), '');
        });

        it('Shoud throw error if not a string is passed', () => {
            assert.throws(() => new StringBuilder(3.14), TypeError);
            assert.throws(() => new StringBuilder(true), TypeError);
            assert.throws(() => new StringBuilder(null), TypeError);
        });

        it('Shoud be correct if correct string is passed', () => {
            let sb = new StringBuilder('Bgaming');
            assert.strictEqual(sb.toString(), 'Bgaming');
        });
    });

    describe('append', () => {
        it('Shoud throw error if not a string is passed', () => {
            let sb = new StringBuilder('Bgaming');

            assert.throws(() => sb.append(3.14), TypeError);
            assert.throws(() => sb.append(true), TypeError);
            assert.throws(() => sb.append(null), TypeError);
        });

        it('Shoud append string correctly, if string is passed', () => {
            let sb = new StringBuilder('Bgaming');

            let expected1 = 'Bgaming the best';
            let expected2 = 'Bgaming the best number one';

            sb.append(' the best');
            assert.strictEqual(sb.toString(), expected1);
            sb.append(' number one');
            assert.strictEqual(sb.toString(), expected2);
        });

        it('Should correctly append only the passed string chars', () => {
            let initial = 'test';
            let validString = 'wow';
            let validString2 = '123';

            let expected = 'testwow';
            let expected2 = 'testwow123';
            let expected3 = 'testwow23';

            let sb = new StringBuilder(initial);

            sb.append(validString);
            //expect(sb.toString()).to.equal(expected);
            assert.strictEqual(sb.toString(), expected);

            sb.append(validString2);
            //expect(sb.toString()).to.equal(expected2);
            assert.strictEqual(sb.toString(), expected2);

            sb.remove(7, 1);
            //expect(sb.toString()).to.equal(expected3);
            assert.strictEqual(sb.toString(), expected3);
        });
    });

    describe('prepend', () => {
        it('Shoud throw error if not a string is passed', () => {
            let sb = new StringBuilder('Bgaming');

            assert.throws(() => sb.prepend(3.14), TypeError);
            assert.throws(() => sb.prepend(true), TypeError);
            assert.throws(() => sb.prepend(null), TypeError);
        });

        it('Shoud prepend string correctly, if string is passed', () => {
            let sb = new StringBuilder('Bgaming');

            let expected1 = 'the best Bgaming';
            let expected2 = 'number one the best Bgaming';

            sb.prepend('the best ');
            assert.strictEqual(sb.toString(), expected1);
            sb.prepend('number one ');
            assert.strictEqual(sb.toString(), expected2);
        });

        it('Should correctly prepend only the passed string chars', () => {
            let initial = 'car';
            let validString = 'fast ';
            let validString2 = 'very ';

            let sb = new StringBuilder(initial);

            let expected = 'fast car';
            let expected2 = 'very fast car';
            let expected3 = 'very fat car';
            sb.prepend(validString);
            //expect(sb.toString()).to.equal(expected);
            assert.strictEqual(sb.toString(), expected);

            sb.prepend(validString2);
            //expect(sb.toString()).to.equal(expected2);
            assert.strictEqual(sb.toString(), expected2);

            sb.remove(7, 1);
            //expect(sb.toString()).to.equal(expected3);
            assert.strictEqual(sb.toString(), expected3);
        });
    });

    describe('insertAt', () => {
        it('Shoud throw error if not a string is passed', () => {
            let sb = new StringBuilder('Bgaming');

            assert.throws(() => sb.insertAt(3.14, 4), TypeError);
            assert.throws(() => sb.insertAt(true, 4), TypeError);
            assert.throws(() => sb.insertAt(null, 4), TypeError);
        });

        it('Shoud insert at index of string correctly, if string is passed', () => {
            let sb = new StringBuilder('Bgaming');

            let expected1 = 'Bgagaming';
            let expected2 = 'Bgagamingga';

            sb.insertAt('ga', 1);
            assert.strictEqual(sb.toString(), expected1);
            sb.insertAt('ga', 9)
            assert.strictEqual(sb.toString(), expected2);
        });

// Това е проверката заради която не минаваше с 100/100, а с 88/100
        it('Should correctly insert only chars', () => {
            let initial = ' faast';
            let validString = 'car';
            let validString2 = 'is ';

            let sb = new StringBuilder(initial);

            let expected = 'car faast';
            let expected2 = 'car is faast';
            let expected3 = 'car is fat';

            sb.insertAt(validString, 0);
            //expect(sb.toString()).to.equal(expected);
            assert.strictEqual(sb.toString(), expected);

            sb.insertAt(validString2, 4);
            //expect(sb.toString()).to.equal(expected2);
            assert.strictEqual(sb.toString(), expected2);

            sb.remove(9, 2);
            //expect(sb.toString()).to.equal(expected3);
            assert.strictEqual(sb.toString(), expected3);
        });
    });

    describe('remove', () => {
        it('Shoud remove from index of string to given length correctly', () => {
            let sb = new StringBuilder('Bgaming');

            let expected1 = 'Bgang';
            let expected2 = 'gang';

            sb.remove(3, 2);
            assert.strictEqual(sb.toString(), expected1);
            sb.remove(0, 1)
            assert.strictEqual(sb.toString(), expected2);
        });
    });

    describe('toString', () => {
        it('Shoud remove from index of string to given length correctly', () => {
            let sb = new StringBuilder('Bgaming');
            let sb2 = new StringBuilder();

            let expected1 = 'Bgaming';
            let expected2 = '';

            assert.strictEqual(sb.toString(), expected1);
            assert.strictEqual(sb2.toString(), expected2);
        });
    });
})