function storeCatalogue(catalogue) {
    resultCatalogue = {};
    catalogue.forEach(el => {
        const [product, price] = el.split(' : ');

        if (resultCatalogue[product[0]] == undefined) {
            resultCatalogue[product[0]] = {}
        }

        resultCatalogue[product[0]][product] = price;
    });

    const keys = Object.keys(resultCatalogue);
    const sortedCatalogue = keys.sort();

    for (const letter of sortedCatalogue) {
        const products = Object.entries(resultCatalogue[letter]);
        const sortedProducts = products.sort((a, b) => a[0].localeCompare(b[0]));

        console.log(letter);

        for (const product of sortedProducts) {
            console.log(` ${product[0]}: ${product[1]}`)
        }
    }
}

storeCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);
console.log('*'.repeat(10));
storeCatalogue(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']);