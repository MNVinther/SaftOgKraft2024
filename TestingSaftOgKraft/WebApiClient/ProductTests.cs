using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using SaftOgKraft.WebSite.ApiClient;
using SaftOgKraft.WebSite.ApiClient.DTO;
using Moq;
using RestSharp;
using FluentAssertions;

namespace TestingSaftOgKraft.WebApiClient
{
    //public class ProductTests
    //{
    //    private ProductDto _newProduct;
    //    private List<int> _createdProductIds = new();
    //    private RestApiClient _apiClient;
    //    private Mock<RestClient> _mockRestClient;

    //    [SetUp]
    //    public async Task Setup()
    //    {
    //        // Initialize the mock RestClient and RestApiClient
    //        _mockRestClient = new Mock<RestClient>("http://mockapi.com");
    //        _apiClient = new RestApiClient(_mockRestClient.Object);  // Pass mock client to the api client

    //        // Initialize a new product
    //        _newProduct = new ProductDto
    //        {
    //            Id = 0, // ID is set to 0 before creation, assuming this is how it's done in your API
    //            Name = "Product Name",
    //            Price = 10,
    //            Description = "Very good saft"
    //        };

    //        // Now create the product asynchronously
    //        var createdProduct = await CreateProductAsync(_newProduct);
    //        _newProduct = createdProduct; // Update _newProduct with the created one
    //    }

    //    [TearDown]
    //    public async Task CleanUp()
    //    {
    //        foreach (var id in _createdProductIds)
    //        {
    //            await _apiClient.DeleteProductAsync(id);  // Async call to delete the product
    //        }
    //    }

    //    [Test]
    //    public async Task GetAllProductsAsync()
    //    {
    //        // Arrange & Act done in setup
    //        // Assert
    //        var products = await _apiClient.GetAllProductsAsync();

    //        Assert.That(products.Count() > 0, "No products returned");
    //    }

    //    [Test]
    //    public async Task DeleteProductAsync()
    //    {
    //        bool deleted = await _apiClient.DeleteProductAsync(_newProduct.Id);
    //        // Assert
    //        Assert.That(deleted, "Product not deleted");
    //    }

    //    private async Task<ProductDto> CreateProductAsync(ProductDto product)
    //    {
    //        // Simulating the creation of the product via the mocked client
    //        var createdProductId = await _apiClient.CreateProductAsync(product);
    //        product.Id = createdProductId;
    //        _createdProductIds.Add(product.Id);  // Keep track of created product IDs for cleanup
    //        return product;
    //    }
    //}
}
