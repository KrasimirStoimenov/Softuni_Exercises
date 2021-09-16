function calculateTime(steps, footstepsMeters, kmh) {

    let distanceInMeters = steps * footstepsMeters;
    let metersPerHour = kmh * 1000;
    let speedMetersSec = metersPerHour / 60 / 60;
    let time = distanceInMeters / speedMetersSec;
    let breakTime = Math.floor(distanceInMeters / 500);

    let timeMin = Math.floor(time / 60);
    let timeSec = Math.round(time - (timeMin * 60));
    let timeHr = Math.floor(time / 3600);

    console.log((timeHr < 10 ? "0" : "") + timeHr + ":" + (timeMin + breakTime < 10 ? "0" : "") + (timeMin + breakTime) + ":" + (timeSec < 10 ? "0" : "") + timeSec);
}

calculateTime(4000, 0.60, 5);
console.log('*'.repeat(10));
calculateTime(2564, 0.70, 5.5);