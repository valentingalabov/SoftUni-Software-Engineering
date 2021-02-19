function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   const rows = document.querySelectorAll('tbody tr');

   function onClick() {
      let input = document.querySelector('#searchField').value;
      let inpu1 = document.querySelector('#searchField');

      for (let row of rows) {
         if ((row.textContent).toLocaleLowerCase().includes(input.toLocaleLowerCase()) && input != "") {
            row.setAttribute('class', 'select');
         } else {
            row.removeAttribute('class');
         }
      }
   }
}