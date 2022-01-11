function solve() {
   let buttonElement = document.querySelector('.btn');

   buttonElement.addEventListener('click', (e) => {
      e.preventDefault();

      let creatorElement = document.querySelector('#creator');
      let titleElement = document.querySelector('#title');
      let categoryElement = document.querySelector('#category');
      let contentElement = document.querySelector('#content');

      if (!creatorElement.value || !titleElement.value || !categoryElement.value || !contentElement.value) {
         return;
      }

      let currentPost = {
         creator: creatorElement.value,
         title: titleElement.value,
         category: categoryElement.value,
         content: contentElement.value,
      }

      let sectionElement = document.querySelector('.site-content main section');

      let deleteButton = createElement('button', 'Delete');
      deleteButton.classList.add('btn');
      deleteButton.classList.add('delete');
      deleteButton.addEventListener('click', (e) => {
         e.target.parentElement.parentElement.remove();
      });

      let archiveButton = createElement('button', 'Archive');
      archiveButton.classList.add('btn');
      archiveButton.classList.add('archive');
      archiveButton.addEventListener('click', (e) => {
         let articleE = e.target.parentElement.parentElement;
         let articleHeading = articleE.querySelector('h1');
         let liElement = createElement('li', articleHeading.textContent);

         let olElement = document.querySelector('.archive-section ol');

         olElement.appendChild(liElement);

         e.target.parentElement.parentElement.remove();

         switching = true;

         while (switching) {

            switching = false;
            b = olElement.getElementsByTagName("LI");

            for (i = 0; i < (b.length - 1); i++) {

               shouldSwitch = false;

               if (b[i].innerHTML.toLowerCase() > b[i + 1].innerHTML.toLowerCase()) {

                  shouldSwitch = true;
                  break;
               }
            }
            if (shouldSwitch) {

               b[i].parentNode.insertBefore(b[i + 1], b[i]);
               switching = true;
            }
         }
      });

      let divElement = createElement('div');
      divElement.classList.add('buttons');

      divElement.appendChild(deleteButton);
      divElement.appendChild(archiveButton);

      let categoryP = createElement('p', 'Category:');
      let categoryStrong = createElement('strong', currentPost.category);

      categoryP.appendChild(categoryStrong);

      let creatorP = createElement('p', 'Creator:');
      let creatorStrong = createElement('strong', currentPost.creator);

      creatorP.appendChild(creatorStrong);

      let contentP = createElement('p', currentPost.content);
      let titleHOne = createElement('h1', currentPost.title);

      let articleElement = createElement('article');

      articleElement.appendChild(titleHOne);
      articleElement.appendChild(categoryP);
      articleElement.appendChild(creatorP);
      articleElement.appendChild(contentP);
      articleElement.appendChild(divElement);

      sectionElement.appendChild(articleElement);
   });

   function createElement(type, text, attr) {
      let result = document.createElement(type);

      if (text) {
         result.textContent = text;
      }

      if (attr) {
         result.className = attr;
      }
      return result;
   }
}
