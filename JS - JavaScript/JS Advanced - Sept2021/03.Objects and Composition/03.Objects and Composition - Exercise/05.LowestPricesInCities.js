function lowestPrice(array) {
    const products = {};

    array.forEach(line => {
        let [town, product, price] = line.split(' | ');
        price = Number(price);

        if (products[product] == undefined) {
            products[product] = {};
        }

        products[product][town] = price;
    });

    for (const product in products) {
        const sortedProducts = Object.entries(products[product]).sort((a, b) => a[1] - b[1]);

        console.log(`${product} -> ${sortedProducts[0][1]} (${sortedProducts[0][0]})`);
    }
}

lowestPrice(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);