// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
async function sortProducts() {
  const sortOrder = document.getElementById("sort").value;

  const response = await fetch(`/api/v1/products/sorted?sortOrder=${sortOrder}`);
  const products = await response.json(); // Ensure this line is unique.

  if (!response.ok) {
    console.error('Error fetching products:', response.statusText);
    return;
  }
  const productsContainer = document.getElementById("products");
  productsContainer.innerHTML = ""; // Clear existing products

  products.forEach(product => {
    const productCard = `
            <div class="product-card">
                <img src="${product.pictureUrl}" alt="${product.name}" />
                <h3>${product.name}</h3>
                <p>${product.description}</p>
                <p>Price: $${product.price}</p>
            </div>
        `;
    productsContainer.innerHTML += productCard;
  });
}

// Optionally load default products on page load.
document.addEventListener("DOMContentLoaded", () => {
  sortProducts();
});