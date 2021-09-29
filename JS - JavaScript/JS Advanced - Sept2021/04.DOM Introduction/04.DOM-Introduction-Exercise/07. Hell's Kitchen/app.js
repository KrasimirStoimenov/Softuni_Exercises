function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      const inputText = document.getElementsByTagName('textarea')[0].value;
      const text = inputText.substring(2, inputText.length - 2);
      const splittedText = text.split('","');
      const restaurants = [];
      for (const line of splittedText) {
         const splittedLine = line.split(' - ');
         const restaurantName = splittedLine[0];
         const workersArgs = splittedLine[1].split(', ');
         const workers = [];
         let totalSalary = 0;
         let bestSalary = 0;
         workersArgs.forEach(worker => {
            const workerInfo = worker.split(' ');
            const workerName = workerInfo[0];
            const workerSalary = Number(workerInfo[1]);
            if (workerSalary > bestSalary) {
               bestSalary = workerSalary;
            }
            totalSalary += workerSalary;

            let currentWorker = {
               name: workerName,
               salary: workerSalary
            };

            workers.push(currentWorker);
         });

         const averageSalary = totalSalary / workersArgs.length;

         let restaurantObj = {
            name: restaurantName,
            workers: workers,
            bestSalary: bestSalary,
            averageSalary: averageSalary
         };

         restaurants.push(restaurantObj);
      }

      let bestRestaurant = {};
      const bestRestaurantAverageSalary = 0;
      restaurants.forEach(restaurant => {
         if (restaurant.averageSalary > bestRestaurantAverageSalary) {
            bestRestaurant = restaurant;
         }
      });

      const bestRestaurantElement = document.getElementById('bestRestaurant');
      const bestRestaurantParagraphElement = bestRestaurantElement.getElementsByTagName('p')[0];
      bestRestaurantParagraphElement.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

      const workersElement = document.getElementById('workers');
      const workersParagraphElement = workersElement.getElementsByTagName('p')[0];
      const bestRestaurantWorkers = bestRestaurant.workers;
      bestRestaurantWorkers.forEach(worker => {
         workersParagraphElement.textContent += `Name: ${worker.name} With Salary: ${worker.salary} `;
      });
      let a = 5;
   }
}