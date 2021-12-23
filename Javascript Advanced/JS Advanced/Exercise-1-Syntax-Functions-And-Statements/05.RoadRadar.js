function solve(speed, area) {
    let speedLimit = 0;

    switch (area) {
        case 'motorway':
            {
                speedLimit = 130;
                break;
            }
        case 'interstate':
            {
                speedLimit = 90;
                break;
            }
        case 'city':
            {
                speedLimit = 50;
                break;
            }
        case 'residential':
            {
                speedLimit = 20;
                break;
            }
    }

    if (speed <= speedLimit) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    }
    else {

        let difference = speed - speedLimit;
        let statusMessage = '';

        if (difference <= 20) {
            statusMessage = 'speeding';
        }
        else if (difference > 20 && difference <= 40) {
            statusMessage = 'excessive speeding';
        }
        else if (difference > 40) {
            statusMessage = 'reckless driving';
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${statusMessage}`)
    }
}

solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');