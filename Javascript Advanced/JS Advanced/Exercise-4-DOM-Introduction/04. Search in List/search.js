function search() {
   let allTownsLiElements = Array.from(document.querySelectorAll('#towns li'));
   let inputElement = document.getElementById('searchText');
   let resultDivElement = document.getElementById('result');

   allTownsLiElements.forEach(element => {
      element.style.fontWeight = 'normal';
      element.style.textDecoration = 'none';
   });

   let neededTowns = allTownsLiElements
      .filter(x => x.textContent.includes(inputElement.value))
      .map(x => {
         x.style.fontWeight = 'bold';
         x.style.textDecoration = 'underline';
      });

   resultDivElement.textContent = `${neededTowns.length} matches found`;

   /*   neededTowns.forEach(element => {
         element.style.fontWeight = 'bold';
         element.style.textDecoration = 'underline';
      }); */
}
