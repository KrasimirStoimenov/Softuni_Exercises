function sameNumbers(numbers) {
    let numbersAsString = numbers.toString();
    let areSame = true;
    let sum = Number(numbersAsString[0]);
    for (let i = 1; i < numbersAsString.length; i++) {
        if(numbersAsString[i] != numbersAsString[i-1]){
            areSame = false;
        }

        sum+=Number(numbersAsString[i]);
    }

    console.log(areSame);
    console.log(sum);
}

sameNumbers(2222222);
console.log('*'.repeat(10));
sameNumbers(1234);