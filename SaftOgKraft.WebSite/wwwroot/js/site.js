// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
async function sortProducts() {
  const sortOrder = document.getElementById("sort").value;

  /*const response = await fetch(`Product/GetSortedProducts?sortOrder=${sortOrder}`);*/
  const url = sortOrder
    ? `Product/GetSortedProducts?sortOrder=${sortOrder}`
    : `Product`; // Fetch unsorted products (default)

  const response = await fetch(url);
  const products = await response.json(); 

  if (!response.ok) {
    console.error('Error fetching products:', response.statusText);
    return;
  }
  const productsContainer = document.getElementById("products");
  productsContainer.innerHTML = ""; // Clear existing products


  products.forEach(product => {
    const productCard = `
            <div class="product-item">
                    <img src="${product.pictureUrl}" alt="${product.name}" class="product-image" />
                    <h3>${product.name}</h3>
                    <br />
                    <p>${product.description}</p>
                    <br />
                    <p>Price: $ ${product.price}</p>
                    <br />
                    <div class="cart-btn">
                    <a class="btn btn-primary" href="/Cart/Add?id=${product.id}&quantity=1">Add To Cart</a>
                    </div>
                </div>
                
        `;
       
    productsContainer.innerHTML += productCard;
  });
  
}



document.addEventListener("DOMContentLoaded", async () => {
  await sortProducts();
  
});

/* Notification when adding products to cart */
function showNotification(message) {
  const notification = document.getElementById('cart-notification');
  notification.querySelector('p').textContent = message; // Set the message
  notification.classList.remove('hidden');
  notification.classList.add('show');

  // Hide the notification after 3 seconds
  setTimeout(() => {
    notification.classList.remove('show');
    setTimeout(() => {
      notification.classList.add('hidden');
    }, 300); // Match the CSS transition duration
  }, 3000);
}

async function addToCart(productId, quantity) {
  try {
    const response = await fetch(`/Cart/Add?id=${productId}&quantity=${quantity}`, {
      method: 'POST'
    });

    if (response.ok) {
      showNotification('Product added to the cart!');
    } else {
      showNotification('Failed to add the product. Please try again.');
    }
  } catch (error) {
    showNotification('An error occurred while adding the product.');
  }
}