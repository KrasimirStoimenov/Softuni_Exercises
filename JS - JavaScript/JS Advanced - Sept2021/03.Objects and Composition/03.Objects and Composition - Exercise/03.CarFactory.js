function carFactory(car) {

    return {
        model: car.model,
        engine: getEngine(car.power),
        carriage: {
            type: car.carriage,
            color: car.color
        },
        wheels: new Array(4).fill(car.wheelsize % 2 == 0 ? car.wheelsize - 1 : car.wheelsize)
    }

    function getEngine(power) {
        const resultEngine = {};
        if (power <= 90) {
            resultEngine.power = 90;
            resultEngine.volume = 1800;
        }
        else if (power <= 120) {
            resultEngine.power = 120;
            resultEngine.volume = 2400;
        }
        else if (power <= 200) {
            resultEngine.power = 200;
            resultEngine.volume = 3500;
        }

        return resultEngine;
    }
}

console.log(carFactory({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));
console.log('*'.repeat(10));
console.log(carFactory({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}));