function oddPositions(array) {
    const resultArray = array
        .filter((v, i) => i % 2 != 0)
        .map(v => v * 2)
        .reverse();

    return resultArray;
}

console.log(oddPositions([10, 15, 20, 25]));
console.log('*'.repeat(10));
console.log(oddPositions([3, 0, 10, 4, 7, 3]));