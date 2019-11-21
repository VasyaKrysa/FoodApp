using System;
using System.Collections.Generic;
using EatingApp.Core.Abstractions.Services;
using EatingApp.Core.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EatingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            var result = _userService.GetAll();
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(int id)
        {

            var result = _userService.GetById(id);
            return result;

        }

        [HttpPost]
        public ActionResult<UserDto> Post([FromBody]UserDto user)
        {
            try
            {
                var result = _userService.Insert(user);
                return result;
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(UserDto user)
        {
            try
            {
                _userService.Update(user);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery] int id)
        {
            _userService.Delete(id);
            return NoContent();
        }
    }
}
