function solve(array, arg) {
    const object = {
        asc: (a, b) => a - b,
        desc: (a, b) => b - a
    }

    return array.sort(object[arg]);
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));