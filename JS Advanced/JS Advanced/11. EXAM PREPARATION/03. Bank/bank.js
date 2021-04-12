class Bank {
    #bankName;
    constructor(bankName) {
        this.#bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        let { firstName, lastName, personalId } = customer;
        if (this.allCustomers.some(c => c.firstName == firstName && c.lastName == lastName)) {
            throw new Error(`${firstName} ${lastName} is already our customer!`);
        }

        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney(personalId, amount) {
        if (!this.allCustomers.some(c => c.personalId == personalId)) {
            throw new Error('We have no customer with this ID!');
        }
        const currCustomer = this.allCustomers.find(c => c.personalId == personalId);
        if (!currCustomer.totalMoney) {
            currCustomer.totalMoney = amount;
            currCustomer.transaction = [];
        } else {
            currCustomer.totalMoney += amount;
        }

        
        currCustomer.transaction.push(`${currCustomer.firstName} ${currCustomer.lastName} made deposit of ${amount}$!`);
        return `${currCustomer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        if (!this.allCustomers.some(c => c.personalId == personalId)) {
            throw new Error('We have no customer with this ID!');
        }
        const currCustomer = this.allCustomers.find(c => c.personalId == personalId);

        if (currCustomer.totalMoney - amount < 0) {
            throw new Error(`${currCustomer.firstName} ${currCustomer.lastName} does not have enough money to withdraw that amount!`);
        }
        currCustomer.totalMoney -= amount;
        currCustomer.transaction.push(`${currCustomer.firstName} ${currCustomer.lastName} withdrew ${amount}$!`);
        return `${currCustomer.totalMoney}$`
    }

    customerInfo (personalId){
        if (!this.allCustomers.some(c => c.personalId == personalId)) {
            throw new Error('We have no customer with this ID!');
        }
        const currCustomer = this.allCustomers.find(c => c.personalId == personalId);
      let result = [];
        result.push(`Bank name: ${this.#bankName}`);
        result.push(`Customer name: ${currCustomer.firstName} ${currCustomer.lastName}`);
        result.push(`Customer ID: ${currCustomer.personalId}`);
        result.push(`Total Money: ${currCustomer.totalMoney}$`);
        result.push(`Transactions:`);

        currCustomer.transaction.reverse();
        let counter = currCustomer.transaction.length;

        currCustomer.transaction.forEach(element => {
            result.push(`${counter}. ${element}`);
            counter--;
        });
   
            return result.join('\n');
    }



}
let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267}));
console.log(bank.newCustomer({firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));
