function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {

      let allInputTrElements = Array.from(document.querySelectorAll('.container tbody tr'));
      let inputElement = document.getElementById('searchField');

      let searchText = inputElement.value;

      allInputTrElements.forEach(element => {
         element.className = '';
      });

      allInputTrElements.forEach(element => {
         for (let i = 0; i < element.children.length; i++) {
            if (element.children[i].textContent.includes(searchText)) {
               element.className = 'select';
            }
         }
      });
   }
}