function solve() {
  document.querySelector('#exercise button').addEventListener('click', generate);
  document.querySelectorAll('#exercise button')[1].addEventListener('click', buy);

  function generate(ev) {
    const tableBody = document.querySelector('table.table tbody');
    const products = JSON.parse(document.querySelector('#exercise textarea').value);

    products.forEach(product => {
      const productRow = document.createElement('tr');
      const imgCell = document.createElement('td');
      const nameCell = document.createElement('td');
      const priceCell = document.createElement('td');
      const decFactorCell = document.createElement('td');
      const checkboxCell = document.createElement('td');


      const imgElement = document.createElement('img');
      imgElement.src = product.img;
      const nameElement = document.createElement('p')
      nameElement.textContent = product.name;
      const priceElement = document.createElement('p')
      priceElement.textContent = product.price;
      const decFactorElement = document.createElement('p')
      decFactorElement.textContent = product.decFactor;
      const checkboxElement = document.createElement('input')
      checkboxElement.type = 'checkbox';

      imgCell.appendChild(imgElement);
      nameCell.appendChild(nameElement);
      priceCell.appendChild(priceElement);
      decFactorCell.appendChild(decFactorElement);
      checkboxCell.appendChild(checkboxElement);

      productRow.appendChild(imgCell);
      productRow.appendChild(nameCell);
      productRow.appendChild(priceCell);
      productRow.appendChild(decFactorCell);
      productRow.appendChild(checkboxCell);

      tableBody.appendChild(productRow);
    });

  }

  function buy(ev) {
    const checkedProducts = Array.from(document.querySelectorAll('[type="checkbox"]:checked'));
    const productsNames = [];
    let totalPrice = 0;
    let totalDecFactor = 0;

    checkedProducts.forEach(product => {
      const currentProduct = product.parentElement.parentElement;
      const rowChildren = currentProduct.children;
      productsNames.push(rowChildren[1].textContent);
      totalPrice += Number(rowChildren[2].textContent);
      totalDecFactor += Number(rowChildren[3].textContent);
    })

    const output = document.getElementsByTagName('textarea')[1];
    output.value += `Bought furniture: ${productsNames.join(', ')}\n`;
    output.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    output.value += `Average decoration factor: ${totalDecFactor / checkedProducts.length}`;
  }
}
