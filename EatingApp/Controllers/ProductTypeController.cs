using System;
using System.Collections.Generic;
using EatingApp.Core.Abstractions.Services;
using EatingApp.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EatingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public ActionResult<List<ProductTypeDto>> GetAll()
        {
            var result = _productTypeService.GetAll();
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductTypeDto> GetById(int id)
        {
            try
            {
                var result = _productTypeService.GetById(id);
                return result;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<ProductTypeDto> Post(ProductTypeDto product)
        {
            try
            {
                var result = _productTypeService.Insert(product);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(ProductTypeDto product)
        {
            try
            {
                _productTypeService.Update(product);
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
                _productTypeService.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NoContent();
            }
        }
    }
}