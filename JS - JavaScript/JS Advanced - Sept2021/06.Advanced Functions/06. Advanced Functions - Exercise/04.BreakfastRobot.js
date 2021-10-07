function solution() {
    const recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    }

    const stock = {
        carbohydrate: 0,
        flavour: 0,
        fat: 0,
        protein: 0
    }

    function restock(element, quantity) {
        stock[element] += Number(quantity);
        return 'Success';
    }

    function prepare(recipe, quantity) {
        const remainingStock = {};

        for (const element in recipes[recipe]) {
            const remaining = stock[element] - recipes[recipe][element] * Number(quantity);
            if (remaining < 0) {
                return `Error: not enough ${element} in stock`;
            }

            remainingStock[element] = remaining;
        }

        Object.assign(stock, remainingStock);

        return `Success`;
    }

    function report() {
        return `protein=${stock.protein} carbohydrate=${stock.carbohydrate} fat=${stock.fat} flavour=${stock.flavour}`;
    }

    function commands(string) {
        const [command, item, quantity] = string.split(' ');

        if (command == 'restock') {
            return restock(item, quantity);
        }
        else if (command == 'prepare') {
            return prepare(item, quantity);
        }
        else if (command == 'report') {
            return report();
        }
    }

    return commands;
}

let manager = solution();
console.log(manager("restock flavour 50")); // Success 
console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock 
console.log(manager("restock carbohydrate 10"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare apple 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare burger 1"));
console.log(manager("report"));

console.log('*'.repeat(10));

let manager2 = solution();
console.log(manager2("prepare turkey 1"));
console.log(manager2("restock protein 10"));
console.log(manager2("prepare turkey 1"));
console.log(manager2("restock carbohydrate 10"));
console.log(manager2("prepare turkey 1"));
console.log(manager2("restock fat 10"));
console.log(manager2("prepare turkey 1"));
console.log(manager2("restock flavour 10"));
console.log(manager2("prepare turkey 1"));
console.log(manager2("report"));


