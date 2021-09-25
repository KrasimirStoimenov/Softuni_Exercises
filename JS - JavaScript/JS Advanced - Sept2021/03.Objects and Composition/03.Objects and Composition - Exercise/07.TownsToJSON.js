function townsToJSON(input) {
    const result = [];
    const substringed = input[0].substring(2, input[0].length - 2);
    const [firstArg, secondArg, thirdArg] = substringed.split(' | ');

    for (let i = 1; i < input.length; i++) {
        const substringed = input[i].substring(2, input[i].length - 2);
        const [currentTown, currentLatitude, currentLongitude] = substringed.split(' | ');

        const obj = {};
        obj[firstArg] = currentTown;
        obj[secondArg] = Number(Number(currentLatitude).toFixed(2));
        obj[thirdArg] = Number(Number(currentLongitude).toFixed(2));

        result.push(obj);
    }

    const json = JSON.stringify(result);
    console.log(json)
}

townsToJSON(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']);

console.log('*'.repeat(10));

townsToJSON(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']);