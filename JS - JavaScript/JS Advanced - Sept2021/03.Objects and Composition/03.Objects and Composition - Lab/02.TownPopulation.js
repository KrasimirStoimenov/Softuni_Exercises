function townPopulation(townsAsStrings) {
    const towns = {};

    for (const town of townsAsStrings) {
        const args = town.split(' <-> ');
        const name = args[0];
        let population = Number(args[1]);

        if (towns[name] != undefined) {
            population += towns[name];
        }
        towns[name]=population;
    }

    for(let town in towns){
        console.log(`${town} : ${towns[town]}`)
    }
}

townPopulation(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']);
console.log('*'.repeat(10));
townPopulation(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']);