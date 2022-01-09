class Vacationer {
    constructor(fullName, creditCard) {
        this.fullName = fullName;
        this.idNumber = this.generateIDNumber();
        this.wishList = [];


        if (!creditCard) {
            this.creditCard = {
                cardNumber: 1111,
                expirationDate: '',
                securityNumber: 111,
            }
        }
        else {

            if (creditCard.length !== 3) {
                throw new Error('Missing credit card information');
            }

            if (typeof creditCard[0] !== 'number' || typeof creditCard[2] !== 'number') {
                throw new Error('Invalid credit card details');
            }

            this.creditCard = {
                cardNumber: creditCard[0],
                expirationDate: creditCard[1],
                securityNumber: creditCard[2],
            }
        }
    }

    get fullName() {
        return this._fullName;
    }

    set fullName(value) {
        if (value.length !== 3) {
            throw new Error('Name must include first name, middle name and last name');
        }

        let pattern = /^[A-Z][a-z]+ [A-Z][a-z]+ [A-Z][a-z]+$/g
        if (!pattern.test(value.join(" "))) {
            throw new Error("Invalid full name");
        }

        this._fullName = { firstName: value[0], middleName: value[1], lastName: value[2] };
    }

    generateIDNumber() {
        this.idNumber = 231 * Number(this.fullName.firstName.charCodeAt(0)) + 139 * this.fullName.middleName.length;

        if (this.fullName.lastName.endsWith('a') ||
            this.fullName.lastName.endsWith('e') ||
            this.fullName.lastName.endsWith('o') ||
            this.fullName.lastName.endsWith('i') ||
            this.fullName.lastName.endsWith('u')) {
            return this.idNumber = String(this.idNumber) + '8';
        }
        else {
            return this.idNumber = String(this.idNumber) + '7';
        }
    }

    addCreditCardInfo(input) {
        if (input.length !== 3) {
            throw new Error('Missing credit card information');
        }

        if (typeof input[0] !== 'number' || typeof input[2] !== 'number') {
            throw new Error('Invalid credit card details');
        }

        this.creditCard = {
            cardNumber: input[0],
            expirationDate: input[1],
            securityNumber: input[2],
        }
    }

    addDestinationToWishList(destination) {
        if (this.wishList.includes(destination)) {
            throw new Error('Destination already exists in wishlist');
        }

        this.wishList.push(destination);

        this.wishList.sort((x, y) => x.length - y.length);
    }

    getVacationerInfo() {
        let text = `Name: ${this.fullName.firstName} ${this.fullName.middleName} ${this.fullName.lastName}\nID Number: ${this.idNumber}\nWishlist:\n`;

        if (this.wishList.length === 0) {
            text = text + 'empty';
        }
        else {
            text = text + `${this.wishList.join(', ')}`;
        }

        text = text + `\nCredit Card:\nCard Number: ${this.creditCard['cardNumber']}\nExpiration Date: ${this.creditCard['expirationDate']}\nSecurity Number: ${this.creditCard['securityNumber']}`;

        return text;
    }
}


let classInstance1 = new Vacationer(["Tania", "Ivanova", "Zhivkova"], [123456789, "10/01/2018", 777]);

console.log(classInstance1.getVacationerInfo());

let classInstance2 = new Vacationer(["Vania", "Ivanova", "Zhivkova"]);

classInstance2.addDestinationToWishList('Spain');
classInstance2.addDestinationToWishList('Germany');

console.log(classInstance2.getVacationerInfo());