function drawSquareOfStars(number=5) {

    for (let row = 0; row < number; row++) {

        let line = '* '.repeat(number);
        console.log(line);
    }
}

drawSquareOfStars();
console.log('-----');
drawSquareOfStars(1);
console.log('-----');
drawSquareOfStars(2);
console.log('-----');
drawSquareOfStars(4);