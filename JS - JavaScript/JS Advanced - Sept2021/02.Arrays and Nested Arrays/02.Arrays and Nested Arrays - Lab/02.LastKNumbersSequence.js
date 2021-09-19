function sequence(n, k) {
    const resultArray = [1];
    for (let i = 1; i < n; i++) {
        let sum = 0;
        for (let j = i - 1; j >= i - k; j--) {
            if (j < 0) {
                continue;
            }
            sum += resultArray[j];
        }
        resultArray.push(sum);
    }

    return resultArray;
}

console.log(sequence(6, 3));
console.log('*'.repeat(10));
console.log(sequence(8, 2));