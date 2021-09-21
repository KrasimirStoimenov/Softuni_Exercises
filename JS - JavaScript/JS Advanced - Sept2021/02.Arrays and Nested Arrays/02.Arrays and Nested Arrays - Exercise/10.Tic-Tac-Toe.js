function ticTac(moves) {
    const matrix = [[false, false, false],
    [false, false, false],
    [false, false, false]];

    const firstPlayerMark = 'X';
    const secondPlayerMark = 'O';
    let playerTurn = 0;

    for (let i = 0; i < moves.length; i++) {
        const currentMove = moves[i].split(' ');
        const currentMoveRow = currentMove[0];
        const currentMoveCol = currentMove[1];
        let currentMark;

        if (playerTurn % 2 == 0) {
            currentMark = firstPlayerMark;
        }
        else {
            currentMark = secondPlayerMark;
        }

        if (matrix[currentMoveRow][currentMoveCol] != false) {
            console.log("This place is already taken. Please choose another!");
            continue;
        }

        matrix[currentMoveRow][currentMoveCol] = currentMark;
        
        const hasWon = checkForWin(currentMark, matrix);
        if (hasWon) {
            console.log(`Player ${currentMark} wins!`);
            break;
        }

        const hasFreePosition = checkForFreePosition(matrix);
        if (!hasFreePosition) {
            console.log("The game ended! Nobody wins :(");
            break;
        }

        playerTurn++;
    }

    
    printMatrix(matrix);

}

function checkForWin(mark, matrix) {
    let isWinner = false;
    for (let i = 0; i < 3; i++) {
        if (matrix[i][0] === mark && matrix[i][1] === mark && matrix[i][2] === mark) {
            isWinner = true;
            break;
        }
        if (matrix[0][i] === mark && matrix[1][i] === mark && matrix[2][i] === mark) {
            isWinner = true;
            break;
        }
    }
    if (!isWinner) {
        if ((matrix[0][0] === mark && matrix[1][1] === mark && matrix[2][2] === mark) ||
            (matrix[2][0] === mark && matrix[1][1] === mark && matrix[0][2] === mark)) {
            isWinner = true;
        }
    }
    return isWinner;
}

function checkForFreePosition(matrix) {
    for (let row = 0; row < matrix.length; row++) {
        const check = matrix[row].indexOf(false);
        if (check != -1) {
            return true;
        }
    }

    return false;
}

function printMatrix(matrix) {
    for (let row = 0; row < matrix.length; row++) {
        const currentRow = matrix[row];

        console.log(currentRow.join('\t'));

    }
}

ticTac(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"]);
console.log('*'.repeat(10));
ticTac(["0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]);
console.log('*'.repeat(10));
ticTac(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"]);