function solution() {
    let resultString = '';

    return {
        append(word) {
            resultString += word;
        },
        removeStart(lettersToDelete) {
            resultString = resultString.slice(lettersToDelete);
        },
        removeEnd(lettersToDelete) {
            resultString = resultString.slice(0, resultString.length - lettersToDelete)
        },
        print() {
            console.log(resultString);
        }
    }
}


let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();


let secondZeroTest = solution();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();
