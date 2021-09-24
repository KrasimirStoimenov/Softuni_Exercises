function heroRegister(array) {
    const heroes = [];
    array.forEach(row => {
        let [name, level, items] = row.split(' / ');

        const hero = {};
        hero.name = name;
        hero.level = Number(level);
        hero.items = items ?items.split(', ') : [];

        heroes.push(hero);
    });

    return JSON.stringify(heroes);
}

console.log(heroRegister(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']));
console.log('*'.repeat(10));
heroRegister(['Jake / 1000 / Gauss, HolidayGrenade']);