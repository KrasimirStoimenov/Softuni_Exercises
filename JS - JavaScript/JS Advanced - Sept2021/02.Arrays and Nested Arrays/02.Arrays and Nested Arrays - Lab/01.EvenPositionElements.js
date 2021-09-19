function evenPositionsElements(array) {
    const result = array.filter((v, i) => i % 2 == 0);

    console.log(result.join(' '))
}

evenPositionsElements(['20', '30', '40', '50', '60']);
console.log('*'.repeat(10));
evenPositionsElements(['5', '10']);