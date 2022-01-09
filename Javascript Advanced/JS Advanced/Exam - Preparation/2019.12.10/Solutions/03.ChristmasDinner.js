class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }

    set budget(value) {
        if (value < 0) {
            throw new Error('The budget cannot be a negative number');
        }
        this._budget = value;
    }

    shopping(product) {
        let producType = product[0];
        let productPrice = product[1];

        if (this._budget < productPrice) {
            throw new Error('Not enough money to buy this product');
        }

        this.products.push(producType);
        this._budget = this._budget - productPrice;
        return `You have successfully bought ${producType}!`;
    }

    recipes(recipe) {
        let recipeName = recipe.recipeName;
        let listOfProducts = recipe.productsList;

        for (const product of listOfProducts) {
            if (this.products.includes(product) === false) {
                throw new Error('We do not have this product');
            }
        }

        this.dishes.push(recipe);
        return `${recipeName} has been successfully cooked!`;
    }

    inviteGuests(name, dish) {
        if (this.dishes.some(x => x.recipeName === dish)) {
            if (this.guests[name]) {
                throw new Error('This guest has already been invited');
            }

            this.guests[name] = dish;
            return `You have successfully invited ${name}!`;
        }
        else {
            throw new Error('We do not have this dish');
        }
    }

    showAttendance() {
        let text = '';
        for (const [key, value] of Object.entries(this.guests)) {
            let neededDish = this.dishes.filter(x => x.recipeName == value)[0];
            text = text + `${key} will eat ${value}, which consists of ${neededDish.productsList.join(', ')}\n`;
        }

        return text.trimEnd();
    }
}

try {
    let dinner = new ChristmasDinner(300);

    dinner.shopping(['Salt', 1]);
    dinner.shopping(['Beans', 3]);
    dinner.shopping(['Cabbage', 4]);
    dinner.shopping(['Rice', 2]);
    dinner.shopping(['Savory', 1]);
    dinner.shopping(['Peppers', 1]);
    dinner.shopping(['Fruits', 40]);
    dinner.shopping(['Honey', 10]);

    dinner.recipes({
        recipeName: 'Oshav',
        productsList: ['Fruits', 'Honey']
    });
    dinner.recipes({
        recipeName: 'Folded cabbage leaves filled with rice',
        productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
    });
    dinner.recipes({
        recipeName: 'Peppers filled with beans',
        productsList: ['Beans', 'Peppers', 'Salt']
    });

    dinner.inviteGuests('Ivan', 'Oshav');
    dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
    dinner.inviteGuests('Georgi', 'Peppers filled with beans');
    
    console.log(dinner.showAttendance());
} catch (error) {
    console.log(error.message);
}

