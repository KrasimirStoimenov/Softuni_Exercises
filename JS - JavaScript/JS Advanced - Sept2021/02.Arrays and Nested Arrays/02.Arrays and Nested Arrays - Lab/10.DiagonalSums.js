function diagonalsSum(matrix) {
    let primaryDiagonalSum = 0;
    let secondaryDiagonalSum = 0;

    for (let i = 0; i < matrix.length; i++) {
        primaryDiagonalSum += matrix[i][i];
        secondaryDiagonalSum += matrix[i][matrix.length - i - 1];
    }

    const resultArray = [];
    resultArray.push(primaryDiagonalSum);
    resultArray.push(secondaryDiagonalSum);

    console.log(resultArray.join(' '));
}

diagonalsSum([[20, 40],
[10, 60]]);
console.log('*'.repeat(10));
diagonalsSum([[3, 5, 17],
[-1, 7, 14],
[1, -8, 89]]);