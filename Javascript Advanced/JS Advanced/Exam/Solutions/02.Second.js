class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(productsArr) {
        for (const product of productsArr) {
            let productElements = product.split(' ');

            let productName = productElements[0];
            let productQuantity = productElements[1];
            let productTotalPrice = productElements[2];

            productQuantity = Number(productQuantity);
            productTotalPrice = Number(productTotalPrice);

            if (this.budgetMoney >= productTotalPrice) {
                this.budgetMoney = this.budgetMoney - productTotalPrice;

                if (!this.stockProducts[`${productName}`]) {
                    this.stockProducts[`${productName}`] = productQuantity;
                }
                else {
                    this.stockProducts[`${productName}`] = this.stockProducts[`${productName}`] + productQuantity;
                }

                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);
            }
            else {
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        }
        return this.history.join('\n');
    }

    addToMenu(meal, neededProductsArr, price) {

        if (this.menu[`${meal}`]) {
            return `The ${meal} is already in the our menu, try something different.`;
        }
        else {
            this.menu[`${meal}`] = {
                products: [neededProductsArr],
                price: Number(price)
            }

            let countProducts = Object.keys(this.menu).length;
            if (countProducts === 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
            }
            else {
                return `Great idea! Now with the ${meal} we have ${countProducts} meals in the menu, other ideas?`;
            }
        }
    }

    showTheMenu() {
        if (Object.entries(this.menu).length === 0) {
            return `Our menu is not ready yet, please come later...`;
        }

        let text = '';
        for (const [key, value] of Object.entries(this.menu)) {
            text = text + `${key} - $ ${value[1]}\n`;
        }

        text = text.trimEnd();

        return text;
    }

    makeTheOrder(mealName) {
        if (!this.menu[`${mealName}`]) {
            return `There is not ${mealName} yet in our menu, do you want to order something else?`;
        }
        else {
            let chosedProduct = this.menu[`${mealName}`];

            for (const product of chosedProduct.products[0]) {
                let productElements = product.split(' ');

                let productName = productElements[0];
                let productQuantity = productElements[1];
                productQuantity = Number(productQuantity);

                if (!this.stockProducts[`${productName}`] || this.stockProducts[`${productName}`] < productQuantity) {
                    return `For the time being, we cannot complete your order (${mealName}), we are very sorry...`;
                }
            }

            this.budgetMoney = this.budgetMoney + chosedProduct[1];

            for (const product of chosedProduct[0]) {
                let productElements = product.split(' ');

                let productName = productElements[0];
                let productQuantity = productElements[1];

                productQuantity = Number(productQuantity);

                this.stockProducts[`${productName}`] = this.stockProducts[`${productName}`] - productQuantity;
            }

            return `Your order (${mealName}) will be completed in the next 30 minutes and will cost you ${chosedProduct[1]}.`;
        }
    }
}


let kitchen = new Restaurant(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));

console.log(kitchen.showTheMenu());

console.log(kitchen.makeTheOrder('frozenYogurt'));