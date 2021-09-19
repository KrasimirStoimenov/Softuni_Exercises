function biggerHalf(array) {
    array.sort((a, b) => a - b);
    const elementsToRemove = Math.floor(array.length / 2);

    for (let i = 0; i < elementsToRemove; i++) {
        array.shift();
    }

    return array;
}

console.log(biggerHalf([4, 7, 2, 5]));
console.log('*'.repeat(10));
console.log(biggerHalf([3, 19, 14, 7, 2, 19, 6]));