using System;
using System.Threading.Tasks;
using Business;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Npgsql;

namespace Api
{
    [Route("/api/user/")]
    [ApiController]
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
            catch (PostgresException e)
            {
                if (e.Message.Contains("23505"))
                    return BadRequest("Já existe um usuário com o messmo email!");
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userBusiness.GetAll());
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser([FromRoute] int userId)
        {
            try
            {
                return Ok(await _userBusiness.GetById(userId));
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (InvalidOperationException)
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            try
            {
                await _userBusiness.DeleteUser(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserDTO userDto)
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
            catch (PostgresException e)
            {
                if (e.Message.Contains("23505"))
                    return BadRequest("Já existe um usuário com o messmo email!");
                return BadRequest(e.Message);
            }
        }
    }
}