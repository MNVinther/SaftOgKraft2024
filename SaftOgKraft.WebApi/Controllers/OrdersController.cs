using DAL.DAO;
using Microsoft.AspNetCore.Mvc;
using SaftOgKraft.WebApi.Controllers.DTOs;
using SaftOgKraft.WebApi.Controllers.DTOs.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaftOgKraft.WebApi.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderDAO _orderDAO;

    public OrdersController(IOrderDAO orderDAO) => _orderDAO = orderDAO;

    // GET: api/<OrdersController>
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrdersAsync()
    {
        try
        {
            var orders = await _orderDAO.GetAllOrdersAsync();
            return Ok(orders.ToDtos());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error fetching orders: {ex.Message}");
        }
    }

    // GET api/<OrdersController>/5/lines
    [HttpGet("{orderId}/lines")]
    public async Task<ActionResult<IEnumerable<OrderLineDTO>>> GetOrderLinesAsync(int orderId)
    {
        try
        {
            var orderLines = await _orderDAO.GetOrderLinesAsync(orderId);
            return Ok(orderLines.ToDtos());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error fetching order lines for Order ID {orderId}: {ex.Message}");
        }
    }


// POST api/<OrdersController>
[HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] OrderDTO orderDTO)
    {
        return Ok(await _orderDAO.InsertOrderAsync(orderDTO.FromDto()));
    }

    // PUT api/<OrdersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<OrdersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
