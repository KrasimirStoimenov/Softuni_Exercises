function cityTaxes(name, population, treasury) {
    return {
        name: name,
        population: population,
        treasury: treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate
        },
        applyGrowth(percentage) {
            this.population = Math.floor(this.population * (percentage / 100 + 1));
        },
        applyRecession(percentage) {
            this.treasury = Math.floor(this.treasury * (1 - percentage / 100));
        }
    };
}

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