function solve() {
   document.getElementsByClassName('shopping-cart')[0].addEventListener('click', onClick);
   document.getElementsByClassName('checkout')[0].addEventListener('click', checkout);
   const output = document.getElementsByTagName('textarea')[0];

   const cart = [];

   function onClick(ev) {
      if (ev.target.tagName == 'BUTTON' && ev.target.classList.contains('add-product')) {
         const currentProduct = ev.target.parentElement.parentElement;
         const productName = currentProduct.querySelector('.product-title').textContent;
         const productPrice = Number(currentProduct.querySelector('.product-line-price').textContent);

         cart.push({
            productName,
            productPrice
         });

         output.value += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
      }
   }

   function checkout(ev) {
      const products = new Set();

      cart.forEach(product => {
         products.add(product.productName);
      });

      const totalPrice = cart.reduce((total, currentProduct) => total += currentProduct.productPrice, 0);

      output.value += `You bought ${[...products].join(', ')} for ${totalPrice.toFixed(2)}.`;

      Array.from(document.getElementsByTagName('button')).map(c => c.setAttribute("disabled", false));
   }
}