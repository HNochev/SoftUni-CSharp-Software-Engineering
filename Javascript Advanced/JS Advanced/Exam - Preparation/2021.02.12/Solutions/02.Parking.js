class Parking {
    constructor(capacity, vehicles) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.vehicles.length >= this.capacity) {
            throw new Error('Not enough parking space.');
        }

        let car = {
            carModel: carModel,
            carNumber: carNumber,
            payed: false,
        };

        this.vehicles.push(car);
        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        let car = this.vehicles.filter(x => x.carNumber === carNumber)[0];

        if (!car) {
            throw new Error("The car, you're looking for, is not found.");
        }

        if (car.payed === false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }

        this.vehicles = this.vehicles.filter(x => x.carNumber !== carNumber);
        return `${carNumber} left the parking lot.`;
    }

    pay(carNumber) {
        let car = this.vehicles.filter(x => x.carNumber === carNumber)[0];

        if (!car) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }

        if (car.payed === true) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }

        car.payed = true;
        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {

        if (!carNumber) {
            let text = `The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.`;

            this.vehicles.sort((x, y) => x.carModel.localeCompare(y.carModel));

            for (const currCar of this.vehicles) {
                text = text + `\n${currCar.carModel} == ${currCar.carNumber} - ${currCar.payed === true ? 'Has payed' : 'Not payed'}`
            }

            return text;
        }

        let car = this.vehicles.filter(x => x.carNumber === carNumber)[0];

        return `${car.carModel} == ${car.carNumber} - ${car.payed === true ? 'Has payed' : 'Not payed'}`;
    }
}


let parking = new Parking(12);

try {
    console.log(parking.addCar("Volvo t600", "TX3691CA"));
    console.log(parking.getStatistics());

    console.log(parking.pay("TX3691CA"));
    console.log(parking.removeCar("TX3691CA"));

} catch (error) {
    console.log(error.message);
}
