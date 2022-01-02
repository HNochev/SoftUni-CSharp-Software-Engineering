function solution() {
    const recipes = {
        apple: { carbohydrate: 1, flavour: 2, order: ['carbohydrate', 'flavour'] },
        lemonade: { carbohydrate: 10, flavour: 20, order: ['carbohydrate', 'flavour'] },
        burger: { carbohydrate: 5, fat: 7, flavour: 3, order: ['carbohydrate', 'fat', 'flavour'] },
        eggs: { protein: 5, fat: 1, flavour: 1, order: ['protein', 'fat', 'flavour'] },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10, order: ['protein', 'carbohydrate', 'fat', 'flavour'] }
    };
    let stock = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };
    function management(request) {
        let [command, type, quantity] = request.split(' ');
        switch (command) {
            case 'prepare':
                return prepareFood();
            case 'restock':
                stock[type] += Number(quantity);
                return 'Success';
            case 'report':
                return `protein=${stock.protein} carbohydrate=${stock.carbohydrate} fat=${stock.fat} flavour=${stock.flavour}`;
        }

        function prepareFood() {
            for (const x of recipes[type].order) {
                if ((recipes[type][x] * quantity) > stock[x]) {
                    return `Error: not enough ${x} in stock`
                }
            }
            for (const x of recipes[type].order) {
                stock[x] -= (recipes[type][x] * quantity)
            }
            return 'Success';
        }
    }
    return management;
}

//Test Cases
// let manager = solution (); 
// console.log (manager ("restock flavour 50")); 
// console.log (manager ("prepare lemonade 4")); 
// console.log (manager ("restock carbohydrate 10")); 
// console.log (manager ("restock flavour 10")); 
// console.log (manager ("prepare apple 1"));  
// console.log (manager ("restock fat 10")); 
// console.log (manager ("prepare burger 1")); 
// console.log (manager ("report")); 

let manager = solution();
console.log(manager("prepare turkey 1"));
console.log(manager("restock protein 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("restock carbohydrate 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare turkey 1"));
console.log(manager("report"));