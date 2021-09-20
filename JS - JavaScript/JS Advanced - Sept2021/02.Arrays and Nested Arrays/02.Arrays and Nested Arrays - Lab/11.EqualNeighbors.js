function equalNeighbors(matrix) {

    let pairs = 0;

    for (let index = 0; index < matrix.length - 1; index++) {

        for (let j = 1; j < matrix[index].length; j++) {

            if (matrix[index][j] == matrix[index + 1][j]) {

                pairs++;
            }

            if (matrix[index][j] == matrix[index][j - 1]) {

                pairs++;
            }
        }
    }

    for (let index = 0; index < matrix[matrix.length - 1].length; index++) {

        if (matrix[matrix.length - 1][index] == matrix[matrix.length - 1][index + 1]) {

            pairs++;

        }
    }

    for (let index = 0; index < matrix.length - 1; index++) {

        if (matrix[index][0] == matrix[index + 1][0]) {

            pairs++;

        }
    }

    return pairs;
}

console.log(equalNeighbors([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '4']]));
console.log('*'.repeat(10));
console.log(equalNeighbors([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]));