
const { assert } = require('chai');
let HolidayPackage = require('../02.HolidayPackage');

describe("HolidayPackage tests", () => {
    describe("constructor", () => {
        it("constructor", () => {
            let holidayPackage = new HolidayPackage('Bansko', 'Winter');

            assert.deepEqual(holidayPackage.vacationers, []);
            assert.strictEqual(holidayPackage.destination, 'Bansko');
            assert.strictEqual(holidayPackage.season, 'Winter');
            assert.strictEqual(holidayPackage.insuranceIncluded, false);
        });
    });

    describe("showVacationers", () => {
        it("Should return string with no vacantioners", () => {
            let holidayPackage = new HolidayPackage('Bansko', 'Winter');

            assert.strictEqual(holidayPackage.showVacationers(), 'No vacationers are added yet');
        });

        it("Should return string with vacantioners", () => {
            let holidayPackage = new HolidayPackage('Bansko', 'Winter');

            holidayPackage.addVacationer('Ivan Ivanov');
            holidayPackage.addVacationer('Dimitar Ivanov');

            assert.strictEqual(holidayPackage.showVacationers(), `Vacationers:\nIvan Ivanov\nDimitar Ivanov`);
        });
    });

    describe("addVacationer", () => {
        it("Should throw an error if vacantioneer name is not valid", () => {

            let holidayPackage = new HolidayPackage('Bansko', 'Winter');

            assert.throws(() => holidayPackage.addVacationer(' '), Error);
            assert.throws(() => holidayPackage.addVacationer(null), Error);
            assert.throws(() => holidayPackage.addVacationer(undefined), Error);
            assert.throws(() => holidayPackage.addVacationer(133), Error);
            assert.throws(() => holidayPackage.addVacationer(true), Error);
            assert.throws(() => holidayPackage.addVacationer(), Error);

            assert.throws(() => holidayPackage.addVacationer('Ivan'), Error);
            assert.throws(() => holidayPackage.addVacationer('Ivan Georgiev Ivanov'), Error);
        });

        it("Should push vacantioneer if everything is valid", () => {

            let holidayPackage = new HolidayPackage('Bansko', 'Winter');

            holidayPackage.addVacationer('Ivan Ivanov');
            holidayPackage.addVacationer('Dimitar Ivanov');

            assert.strictEqual(holidayPackage.vacationers.length, 2);
        });
    });

    describe("generateHolidayPackage", () => {
        it("Should throw an error if no vacantioneers are added", () => {
            let holidayPackage = new HolidayPackage('Bansko', 'Winter');

            assert.throws(() => holidayPackage.generateHolidayPackage(), Error);
        });

        it("Should determine the price", () => {
            let holidayPackage = new HolidayPackage('Bansko', 'Winter');

            holidayPackage.addVacationer('Ivan Ivanov');
            holidayPackage.addVacationer('Dimitar Ivanov');

            assert.strictEqual(holidayPackage.generateHolidayPackage(), "Holiday Package Generated\n" + "Destination: " + 'Bansko' + "\n" + `Vacationers:\nIvan Ivanov\nDimitar Ivanov` + "\n" + "Price: " + '1000');

            holidayPackage.season = 'Summer';

            assert.strictEqual(holidayPackage.generateHolidayPackage(), "Holiday Package Generated\n" + "Destination: " + 'Bansko' + "\n" + `Vacationers:\nIvan Ivanov\nDimitar Ivanov` + "\n" + "Price: " + '1000');

            holidayPackage.season = 'Other';

            assert.strictEqual(holidayPackage.generateHolidayPackage(), "Holiday Package Generated\n" + "Destination: " + 'Bansko' + "\n" + `Vacationers:\nIvan Ivanov\nDimitar Ivanov` + "\n" + "Price: " + '800');

            holidayPackage.insuranceIncluded = true;

            assert.strictEqual(holidayPackage.generateHolidayPackage(), "Holiday Package Generated\n" + "Destination: " + 'Bansko' + "\n" + `Vacationers:\nIvan Ivanov\nDimitar Ivanov` + "\n" + "Price: " + '900');

            holidayPackage.season = 'Summer';

            assert.strictEqual(holidayPackage.generateHolidayPackage(), "Holiday Package Generated\n" + "Destination: " + 'Bansko' + "\n" + `Vacationers:\nIvan Ivanov\nDimitar Ivanov` + "\n" + "Price: " + '1100');
        });
    });
});