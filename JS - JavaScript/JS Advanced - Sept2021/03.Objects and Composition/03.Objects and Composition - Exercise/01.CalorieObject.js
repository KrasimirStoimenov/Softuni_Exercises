function calories(array) {
    const resultObj = {};
    for (let i = 0; i < array.length; i += 2) {
        resultObj[array[i]] = Number(array[i + 1]);
    }

    console.log(resultObj);
}

calories(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
console.log('*'.repeat(10));
calories(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);