    using Microsoft.AspNetCore.Mvc;

namespace SaftOgKraft.WebApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductDAO _productsDAO;

        public ProductsController(IProductDAO productsDAO) => _productsDAO = productsDAO;

        // GET: api/ProductsController
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get() => Ok(_productsDAO.GetAll());

        // GET: api/ProductsController>
        [HttpGet("latest10")]
        public ActionResult<IEnumerable<Product>> GetTenlatestProducts() => Ok(_productsDAO.GetTenLatestProducts());

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id) => _productsDAO.Get(id);

        // POST api/<ProductsController>
        [HttpPost]
        public int Post([FromBody] Product product) => _productsDAO.Insert(product);


    }


}
