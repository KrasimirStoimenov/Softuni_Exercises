function cook(number, ...operations) {
    //number = Number(number);

    for (const operation of operations) {
        switch (operation) {
            case "chop":
                number /= 2;
                break;
            case "dice":
                number = Math.sqrt(number);
                break;
            case "spice":
                number += 1;
                break;
            case "bake":
                number *= 3;
                break;
            case "fillet":
                number *= 0.8;
                break;
        }

        console.log(number);
    }
}

cook('32', 'chop', 'chop', 'chop', 'chop', 'chop');
console.log('*'.repeat(10));
cook('9', 'dice', 'spice', 'chop', 'bake', 'fillet');