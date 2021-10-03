function create(words) {
   const contentDiv = document.getElementById('content');
   contentDiv.addEventListener('click', (ev) => ev.target.children[0].style.display = 'inline');

   for (const word of words) {
      const divElement = document.createElement('div');
      const pElement = document.createElement('p');
      pElement.textContent = word;
      pElement.style.display = 'none';

      divElement.appendChild(pElement);
      contentDiv.appendChild(divElement);
   }
}