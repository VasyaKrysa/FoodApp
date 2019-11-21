using System;
using System.Collections.Generic;
using EatingApp.Core.Abstractions.Services;
using EatingApp.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EatingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {

            var result = _orderService.GetAll();
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetById(int id)
        {
            try
            {
                var result = _orderService.GetById(id);
                return result;
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public ActionResult<OrderDto> Post(OrderDto order)
        {
            try
            {
                var result = _orderService.Insert(order);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(OrderDto order)
        {
            try
            {
                _orderService.Update(order);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _orderService.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
