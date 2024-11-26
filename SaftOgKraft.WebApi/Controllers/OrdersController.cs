﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaftOgKraft.WebApi.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderDAO _ordersDAO;

    public OrdersController(IOrderDAO ordersDAO) => -ordersDAO = ordersDAO;

    // GET: api/<OrdersController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<OrdersController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<OrdersController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
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
