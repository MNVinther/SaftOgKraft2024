﻿using System.Linq.Expressions;
using DAL.DAO;
using DAL.Model;    
using Microsoft.AspNetCore.Mvc;
using SaftOgKraft.WebApi.Controllers.DTOs;
using SaftOgKraft.WebApi.Controllers.DTOs.Converters;

namespace SaftOgKraft.WebApi.Controllers;


[Route("api/v1/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductDAO _productsDAO;

    public ProductsController(IProductDAO productsDAO) => _productsDAO = productsDAO;

        // GET: api/ProductsController
        [HttpGet("sorted")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetSortedProducts(string sortOrder = "")
        {
            var products = await _productsDAO.GetAllAsync();

                products = sortOrder.ToLower() switch
                {
                    "asc" => products.OrderBy(p => p.Price),
                    "desc" => products.OrderByDescending(p => p.Price),
                    _ => products
                };
            
            return Ok(products.ToDtos());
        }

        // GET: api/ProductsController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var products = await _productsDAO.GetAllAsync();
            return Ok(products.ToDtos());
        }
        
    // GET: api/ProductsController>
    [HttpGet("ten-latest")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetTenlatestProducts()
    {
        IEnumerable<Product> products;
        products = await _productsDAO.GetTenLatestProductsAsync();
        return Ok(products.ToDtos());
    }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            try
            {
                var product = await _productsDAO.GetProductByIdAsync(id);

                if (product == null)
                {
                    return NotFound($"Product with ID {id} was not found.");
                }
                return Ok(product);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"{ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server Error: {ex.Message}");

            }
        }

    // GET: api/ProductsController
    [HttpGet]
    public ActionResult<IEnumerable<ProductDTO>> Get() => Ok(_productsDAO.GetAllAsync());
    
    // GET api/<ProductsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductByIdAsync(int id) => Ok(await _productsDAO.GetProductByIdAsync(id));

    // POST api/<ProductsController>
    [HttpPost]
    public Task<int> Post([FromBody] Product product) => _productsDAO.InsertAsync(product);


}
