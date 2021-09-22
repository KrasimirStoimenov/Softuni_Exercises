function city(name, population, treasury) {
    const city = {
        name: name,
        population: population,
        treasury: treasury
    };

    return city;
}

console.log(city('Tortuga', 7000, 15000));
console.log('*'.repeat(10));
console.log(city('Santo Domingo', 12000, 23500));