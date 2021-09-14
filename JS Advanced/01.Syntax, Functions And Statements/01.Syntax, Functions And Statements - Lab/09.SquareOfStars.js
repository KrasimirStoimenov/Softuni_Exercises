function squareOfStars(n = 5) {
    for (let i = 0; i < n; i++) {
        console.log('* '.repeat(n).trimEnd());
    }
}

squareOfStars(1);
console.log('-'.repeat(10));
squareOfStars(2);
console.log('-'.repeat(10));
squareOfStars(5);
console.log('-'.repeat(10));
squareOfStars();