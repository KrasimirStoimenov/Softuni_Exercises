function area(radius) {
    let typeOfRadius = typeof (radius);
    if (typeOfRadius != 'number') {
        console.log(`We can not calculate the circle area, because we receive a ${typeOfRadius}.`)
        return;
    }

    let r = Math.PI * radius ** 2;
    console.log(r.toFixed(2));
}

area(5);
console.log('-'.repeat(10));
area('name');