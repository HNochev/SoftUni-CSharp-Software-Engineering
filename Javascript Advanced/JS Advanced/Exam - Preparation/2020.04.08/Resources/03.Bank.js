class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        let firstName = customer.firstName;
        let lastName = customer.lastName;
        let personalId = customer.personalId;

        if (this.allCustomers.some(x => x.personalId === personalId)) {
            throw new Error(`${firstName} ${lastName} is already our customer!`);
        }

        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney(personalId, amount) {
        if (this.allCustomers.some(x => x.personalId === personalId)) {
            let customer = this.allCustomers.filter(x => x.personalId === personalId)[0];

            if (!customer.totalMoney) {
                customer.totalMoney = 0;
            }
            customer.totalMoney = customer.totalMoney + amount;

            if (!customer.transactions) {
                customer.transactions = [];
            }

            customer.transactions.push(`${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);

            return `${customer.totalMoney}$`;
        }
        else {
            throw new Error('We have no customer with this ID!');
        }
    }

    withdrawMoney(personalId, amount) {
        if (this.allCustomers.some(x => x.personalId === personalId)) {
            let customer = this.allCustomers.filter(x => x.personalId === personalId)[0];

            if (!customer.totalMoney) {
                customer.totalMoney = 0;
            }

            if (customer.totalMoney < amount) {
                throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
            }

            customer.totalMoney = customer.totalMoney - amount;

            if (!customer.transactions) {
                customer.transactions = [];
            }
            customer.transactions.push(`${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);

            return `${customer.totalMoney}$`;
        }
        else {
            throw new Error('We have no customer with this ID!');
        }
    }
    customerInfo(personalId) {
        if (this.allCustomers.some(x => x.personalId === personalId)) {

            let customer = this.allCustomers.filter(x => x.personalId === personalId)[0];

            let text = `Bank name: ${this._bankName}\nCustomer name: ${customer.firstName} ${customer.lastName}\nCustomer ID: ${personalId}\nTotal Money: ${customer.totalMoney}$\nTransactions:`;

            customer.transactions.reverse();

            for (let i = 0; i < customer.transactions.length; i++) {
                text = text + `\n${customer.transactions.length -i}. ${customer.transactions[i]}`;
            }

            return text;
        }
        else {
            throw new Error('We have no customer with this ID!');
        }
    }
}


let bank = new Bank('SoftUni Bank');

bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 1111111 });

bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 3333333 });

bank.depositMoney(1111111, 250);
bank.depositMoney(1111111, 250);
bank.depositMoney(3333333, 555);

bank.withdrawMoney(1111111, 125);

console.log(bank.customerInfo(1111111));