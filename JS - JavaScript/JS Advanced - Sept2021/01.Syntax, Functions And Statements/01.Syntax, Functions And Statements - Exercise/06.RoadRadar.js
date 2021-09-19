function radar(speed, area) {
    let limit;

    switch (area) {
        case "motorway":
            limit = 130;
            break;
        case "interstate":
            limit = 90;
            break;
        case "city":
            limit = 50;
            break;
        case "residential":
            limit = 20;
            break;
    }

    if (speed > limit) {
        let speedDifference = speed - limit;
        let status;

        if (speedDifference <= 20) {
            status = "speeding";
        }
        else if (speedDifference <= 40) {
            status = "excessive speeding";
        }
        else {
            status = "reckless driving";
        }

        console.log(`The speed is ${speedDifference} km/h faster than the allowed speed of ${limit} - ${status}`);
    }
    else {
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    }
}

radar(40, 'city');
console.log('*'.repeat(10));
radar(21, 'residential');
console.log('*'.repeat(10));
radar(120, 'interstate');
console.log('*'.repeat(10));
radar(200, 'motorway');