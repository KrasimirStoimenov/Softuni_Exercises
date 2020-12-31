function solve(firstArg,secondArg,thirdArg){
    let firstArgLength = firstArg.length;
    let secondArgLength = secondArg.length;
    let thirdArgLength = thirdArg.length;

    let sumLength = firstArgLength + secondArgLength+thirdArgLength;
    let averageSum = Math.round(sumLength/3);

    console.log(sumLength);
    console.log(averageSum);
}

solve('chocolate', 'ice cream', 'cake');
console.log('-----')
solve('pasta', '5', '22.3');