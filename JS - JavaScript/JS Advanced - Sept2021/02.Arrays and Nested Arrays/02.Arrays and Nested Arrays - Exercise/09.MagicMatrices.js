function magicMatrices(matrix) {
    let magicSum = matrix[0].reduce((acc, curr) => acc + curr);

    for (let i = 0; i < matrix.length; i++) {
        const currentRow = matrix[i];
        let currentRowSum = 0;

        for (let col = 0; col < currentRow.length; col++) {
            const element = currentRow[col];
            currentRowSum += element;
        }

        if (currentRowSum != magicSum) {
            return false;
        }

    }

    for (let col = 0; col < matrix.length; col++) {
        let currentColSum = 0;

        for (let row = 0; row < matrix.length; row++) {
            const element = matrix[row][col];
            currentColSum += element;
        }

        if(currentColSum != magicSum){
            return false
        }
    }

    return true;
}

console.log(magicMatrices([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]));
console.log('*'.repeat(10));
console.log(magicMatrices([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]));
console.log('*'.repeat(10));
console.log(magicMatrices([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]));
