using System;
using System.Collections.Generic;
using EatingApp.Core.Abstractions.Services;
using EatingApp.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EatingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public ActionResult<List<OrderItemDto>> GetAll()
        {
            var result = _orderItemService.GetAll();
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<OrderItemDto> GetById(int id)
        {
            try
            {
                var result = _orderItemService.GetById(id);
               
                return result;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<OrderItemDto> Post(OrderItemDto orderItem)
        {
            try
            {
                var result = _orderItemService.Insert(orderItem);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(OrderItemDto orderItem)
        {
            try
            {
                _orderItemService.Update(orderItem);
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
                _orderItemService.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
