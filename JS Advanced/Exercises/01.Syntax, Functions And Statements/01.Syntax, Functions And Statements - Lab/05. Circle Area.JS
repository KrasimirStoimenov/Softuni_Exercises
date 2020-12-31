function calculateCircleArea(argument) {

    if (typeof (argument) == 'number') {

        let result = Math.pow(argument, 2) * Math.PI;
        console.log(result.toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${typeof(argument)}.`)
    }
}

calculateCircleArea(5);
console.log('-----');
calculateCircleArea('name');