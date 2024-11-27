// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
async function sortProducts() {
  const sortOrder = document.getElementById("sort").value;

  const response = await fetch(`Product/GetSortedProducts?sortOrder=${sortOrder}`);
  const products = await response.json(); // Ensure this line is unique.

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
                    <a class="btn btn-primary" href="/Cart/Add?id=${product.id}&quantity=1">Add To Cart</a>
                </div>
        `;
    productsContainer.innerHTML += productCard;
  });
}

// Optionally load default products on page load.
document.addEventListener("DOMContentLoaded", async () => {
  await sortProducts();
  
});