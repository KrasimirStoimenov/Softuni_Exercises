function juiceFlavours(inputArr) {
    class Juice {
        constructor(name, quantity) {
            this.name = name;
            this._quantity = Number(quantity);
        }

        get quantity() {
            return this._quantity % 1000;
        }

        set quantity(value) {
            this._quantity += Number(value);
        }

        bottles() {
            return Math.floor(this._quantity / 1000)
        }
    }

    const resultArr = [];

    for (const juice of inputArr) {
        const [juiceName, juiceQuantity] = juice.split(' => ');
        let juiceExist = false;
        for (const resultJuice of resultArr) {
            if (resultJuice.name == juiceName) {
                resultJuice.quantity += Number(juiceQuantity);
                juiceExist = true;
            }
        }

        if (!juiceExist && juiceQuantity > 1000) {
            resultArr.push(new Juice(juiceName, juiceQuantity));
        }
    }

    resultArr.forEach(juice => {
        console.log(`${juice.name} => ${juice.bottles()}`)
    });
}

juiceFlavours(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']);

console.log('*'.repeat(20));

juiceFlavours(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']);
