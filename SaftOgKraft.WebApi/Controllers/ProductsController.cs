using DAL.DAO;
using DAL.Model;    
using Microsoft.AspNetCore.Mvc;

namespace SaftOgKraft.WebApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductDAO _productsDAO;

        public ProductsController(IProductDAO productsDAO) => _productsDAO = productsDAO;

        // GET: api/ProductsController>
        [HttpGet("latest10")]
        public async Task<ActionResult<IEnumerable<Product>>> GetTenlatestProducts() => Ok(await _productsDAO.GetTenLatestProducts());

        // GET: api/ProductsController
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get() => Ok(_productsDAO.GetAll());

        
        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id) => await _productsDAO.Get(id);

        // POST api/<ProductsController>
        [HttpPost]
        public Task<int> Post([FromBody] Product product) => _productsDAO.Insert(product);


    }


}
