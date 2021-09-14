function daysCount(month, year) {
    let days = new Date(year, month, 0).getDate();
    console.log(days);
}

daysCount(1, 2012);
console.log('-'.repeat(10));
daysCount(2, 2021);