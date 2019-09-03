using System;
using System.Threading.Tasks;
using Business;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;

namespace Api
{
    [Route("/api/user/")]
    public class UserController : Controller
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            try
            {
                await _userBusiness.Create(userDto);

                return Ok();
            }
            catch (InvalidEmailException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userBusiness.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int userId)
        {
            await _userBusiness.GetById(userId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _userBusiness.DeleteUser(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] CreateUserDto userDto)
        {
            try
            {
                await _userBusiness.UpdateData(userDto, id);

                return Ok();
            }
            catch (InvalidEmailException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}