function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const rows = Array.from(document.querySelectorAll('tbody tr'));
      let inputText = document.getElementById('searchField');

      rows.forEach(row => {
         if (row.textContent.includes(inputText.value)) {
            row.classList.add('select');
         }
         else {
            row.classList.remove('select');
         }
      });

      inputText.value = '';
   }
}