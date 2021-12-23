function solve(steps, studentStepInMeters, speedKmH) {
    let distanceInMeters = steps * studentStepInMeters;
    //1km = 1000m
    //1hour = 60 * 60 = 3600s

    let speedInMetersPerSecond = speedKmH / 3.6;

    let time = distanceInMeters / speedInMetersPerSecond;
    let breaks = Math.trunc(distanceInMeters / 500);
    time = time + (breaks * 60);

    let hours = Math.trunc(time / 3600);
    let minutes = Math.trunc((time % 3600) / 60);
    let seconds = Math.round(time % 60);

    return `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
}

console.log(solve(4000, 0.60, 5));
console.log(solve(2564, 0.70, 5.5));