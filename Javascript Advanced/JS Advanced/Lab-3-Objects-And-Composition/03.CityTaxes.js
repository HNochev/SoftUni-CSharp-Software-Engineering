function cityTaxes(name, population, treasury) {
    const city = {
        name: name,
        population: population,
        treasury: treasury,
        taxRate: 10,

        collectTaxes() {
            this.treasury = Math.floor(this.treasury + (this.population * this.taxRate));
        },

        applyGrowth(percentage) {
            this.population = Math.floor(this.population * (1 + Number(percentage) / 100));
        },

        applyRecession(percentage) {
            this.treasury = Math.floor(this.treasury * (1 - Number(percentage) / 100));
        },
    };
    return city;
}

//const city = 
// cityTaxes('Tortuga',
// 7000,
// 15000);
//console.log(city);

const city =
    cityTaxes('Tortuga',
        7000,
        15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);
city.applyRecession(5);
console.log(city.treasury);
