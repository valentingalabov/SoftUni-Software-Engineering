class Hotel {
    constructor(name, capacity) {
        this.name = name;
        this.capacity = capacity;
        this.bookings = [];
        this.currentBookingNumber = 1;
        this.singleRooms = Math.floor(this.capacity * 0.5);
        this.doubleRooms = Math.floor(this.capacity * 0.3);
        this.maisonetteRooms = Math.floor(this.capacity * 0.2);
    }

    get roomsPricing() {
        return {
            single: 50,
            double: 90,
            maisonette: 135
        };
    }


    rentARoom(clientName, roomType, nights) {
        //check if other rooms have empty spaces?
        if (roomType == 'single' && this.singleRooms < 1) {
            return `No ${roomType} rooms available!${(this.doubleRooms < 1) ? '' : ` Available double rooms: ${this.doubleRooms}.`}${(this.maisonetteRooms < 1) ? '' : ` Available maisonette rooms: ${this.maisonetteRooms}.`}`;
        } else if (roomType == 'double' && this.doubleRooms < 1) {
            return `No ${roomType} rooms available!${(this.singleRooms < 1) ? '' : ` Available single rooms: ${this.singleRooms}.`}${(this.maisonetteRooms < 1) ? '' : ` Available maisonette rooms: ${this.maisonetteRooms}.`}`;
        } else if (roomType == 'maisonette' && this.maisonetteRooms < 1) {
            return `No ${roomType} rooms available!${(this.singleRooms < 1) ? '' : ` Available single rooms: ${this.singleRooms}.`}${(this.doubleRooms < 1) ? '' : ` Available double rooms: ${this.doubleRooms}.`}`;
        }


        this.bookings.push({ clientName, roomType, nights, currentBookingNumber: this.currentBookingNumber });

        const currNumber = this.currentBookingNumber;

        this.currentBookingNumber++;

        if (roomType == 'single') {
            this.singleRooms--;
        } else if (roomType == 'double') {
            this.doubleRooms--;
        } else {
            this.maisonetteRooms--;
        }

        return `Enjoy your time here Mr./Mrs. ${clientName}. Your booking is ${currNumber}.`
    }

    checkOut(currBNum) {
        let currBooking = this.bookings.find(b => b.currentBookingNumber == currBNum);
        if (!currBooking) {
            return `The booking ${currBNum} is invalid.`;
        }

        //information abaut other rooms?

        let totalMoney;
        if (currBooking.roomType == 'single') {
            totalMoney = currBooking.nights * this.roomsPricing.single;
            this.singleRooms++;

        } else if (currBooking.roomType == 'double') {
            totalMoney = currBooking.nights * this.roomsPricing.double;
            this.doubleRooms++;
        } else {
            totalMoney = currBooking.nights * this.roomsPricing.maisonette;
            this.maisonetteRooms++;
        }

        const index = this.bookings.indexOf(currBooking);
        this.bookings.splice(index, 1);

        return `We hope you enjoyed your time here, Mr./Mrs. ${currBooking.clientName}. The total amount of money you have to pay is ${totalMoney} BGN.`

    }

    report() {
        let result = [];
        result.push(`${this.name.toUpperCase()} DATABASE:`);
        result.push('-'.repeat(20));
        if (this.bookings.length < 1) {
            result.push(`There are currently no bookings.`);
            return result.join('\n');
        }



        for (let i = 0; i < this.bookings.length; i++) {
            const el = this.bookings[i];
            if (i == 0) {
                result.push(`bookingNumber - ${el.currentBookingNumber}\nclientName - ${el.clientName}\nroomType - ${el.roomType}\nnights - ${el.nights}`);
            } else {
                result.push(`${'-'.repeat('10')}\nbookingNumber - ${el.currentBookingNumber}\nclientName - ${el.clientName}\nroomType - ${el.roomType}\nnights - ${el.nights}`);
            }

        }


        return result.join('\n');
    }

}




let hotel = new Hotel('HotUni', 10);

hotel.rentARoom('Peter', 'single', 4);
hotel.rentARoom('Robert', 'double', 4);
hotel.rentARoom('Geroge', 'maisonette', 6);

console.log(hotel.report());
