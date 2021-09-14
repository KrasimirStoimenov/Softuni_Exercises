function previousDay(year, month, day) {
    let date = new Date(year, month - 1, day);
    date.setDate(date.getDate() - 1);

    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`)
}

previousDay(2016, 9, 30);
console.log('*'.repeat(10));
previousDay(2016, 10, 1);

// Date.getMonth() and setMonth() in construnctor - Returns the month (0–11) in the specified date according to local time.