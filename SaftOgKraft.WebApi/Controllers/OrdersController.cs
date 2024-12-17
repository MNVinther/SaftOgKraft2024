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
    [HttpGet]
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

    // GET api/<OrdersController>/5/
    [HttpGet("{orderId}")]
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
    public async Task<IActionResult> Create([FromBody] OrderDTO orderDTO)
    {
        if (orderDTO == null || orderDTO.OrderLines == null || !orderDTO.OrderLines.Any())
        {
            return BadRequest("OrderDTO is invalid or contains no order lines.");
        }

        try
        {
            var order = DTOConverter.FromDto(orderDTO);
            var createdOrder = await _orderDAO.CreateOrderAsync(order);
            return Ok(DTOConverter.ToDto(createdOrder));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    // DELETE api/<OrdersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }


    [HttpPut("{orderId}")]
    public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] OrderDTO orderDTO)
    {
        try
        {
            //bool isUpdated = await _orderDAO.UpdateOrderStatusAsync(orderId, statusUpdate.Status);

            bool isUpdated = await _orderDAO.UpdateOrderStatusAsync(orderId, "Packed");

            if (isUpdated)
            {
                return Ok(new { Message = "Order status updated successfully." });

            }

            return NotFound(new { Message = "Order not found or status update failed." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error updating order status: {ex.Message}");
        }
    }
}



