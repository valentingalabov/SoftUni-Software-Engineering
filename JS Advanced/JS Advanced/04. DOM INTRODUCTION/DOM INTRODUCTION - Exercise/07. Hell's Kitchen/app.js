function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   const input = document.querySelector('#inputs>textarea');
   const bestRestaurantP = document.querySelector('#bestRestaurant>p');
   const bestWorkersP = document.querySelector('#workers>p');

   function onClick() {
      const arr = JSON.parse(input.value);

      let restaurants = {}

      arr.forEach((line) => {
         const tokens = line.split(' - ');
         const name = tokens[0];
         const workersArr = tokens[1].split(', ');
         let workers = [];



         for (let worker of workersArr) {
            let workerTokens = worker.split(' ');
            const salary = Number(workerTokens[1])
            workers.push({
               name: workerTokens[0],
               salary
            })
         }

         if (restaurants[name]) {
            workers = workers.concat(restaurants[name].workers);
         }

         workers.sort((a, b) => b.salary - a.salary);

         const bestSalary = workers[0].salary;
         const averageSalary = workers
            .reduce((sum, worker) => sum + worker.salary, 0) / workers.length;

         restaurants[name] = {
            workers,
            averageSalary,
            bestSalary
         }
         console.log(restaurants);
      });
      let bestRestaurantSalary = 0;
      let bestRestaurant = undefined;

      for (const name in restaurants) {
         if (restaurants[name].averageSalary > bestRestaurantSalary) {
            bestRestaurant = {
               name,
               workers: restaurants[name].workers,
               bestSalary: restaurants[name].bestSalary,
               averageSalary: restaurants[name].averageSalary
            }
            bestRestaurantSalary = restaurants[name].averageSalary;
         }
      }

      let bestWorkers = bestRestaurant.workers.sort((a, b) => b.salary - a.salary);

      bestRestaurantP.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;
      
      let workersResult = [];

      bestRestaurant.workers.forEach(worker => {
         workersResult.push(`Name: ${worker.name} With Salary: ${worker.salary}`);
      });
     
      bestWorkersP.textContent = workersResult.join(' ');

   }
}
