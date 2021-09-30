function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      const inputText = JSON.parse(document.getElementsByTagName('textarea')[0].value);
      const bestRestaurantOutput = document.querySelector('#bestRestaurant p');
      const bestWorkersOutput = document.querySelector('#workers p');

      const restaurant = [0, 0, 0, 0];

      inputText.forEach(restaurantArgs => {
         restaurantArgs = restaurantArgs.match(/[^-,\s]+/g);
         const restaurantName = restaurantArgs.shift();
         const workers = restaurantArgs.filter(e => isNaN(e));
         const salaries = restaurantArgs.filter(e => !isNaN(e));

         if (restaurant[0] === restaurantName) {
            restaurant[2].push(...workers);
            restaurant[3].push(...salaries);
            restaurant[1] = calcAverageSalary(restaurant[3]);
         } else {
            const averageSalary = calcAverageSalary(salaries);
            if (averageSalary > restaurant[1]) {
               restaurant[0] = restaurantName;
               restaurant[1] = averageSalary;
               restaurant[2] = workers;
               restaurant[3] = salaries;
            }
         }
      });

      function calcAverageSalary(salaries) {
         return salaries.reduce((a, b) => Number(a) + Number(b)) / salaries.length;
      }
      function calcHighestSalary() {
         return Math.max.apply(null, restaurant[3]);
      }
      function sortSalaries() {
         let workersAndSalaries = {};
         restaurant[2].forEach((e, i) => {
            workersAndSalaries[e] = restaurant[3][i];
         });
         let sorted = Object.entries(workersAndSalaries).sort((a, b) => b[1] - a[1]);
         print(sorted);
      }
      sortSalaries();

      function print(sorted) {
         bestRestaurantOutput.textContent =
            `Name: ${restaurant[0]} Average Salary: ${(restaurant[1]).toFixed(2)} Best Salary: ${(calcHighestSalary()).toFixed(2)}`
         sorted.forEach(([name, salary]) => bestWorkersOutput.textContent += `Name: ${name} With Salary: ${salary} `);
      }
   }
}