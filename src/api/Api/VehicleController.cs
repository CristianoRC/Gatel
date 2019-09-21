using System;
using System.Threading.Tasks;
using Business;
using Exceptions;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;

namespace Api
{
    [Route("/api/vehicle/")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IVehicleBusiness _vehicleBusiness;

        public VehicleController(IVehicleBusiness vehicleBusiness)
        {
            _vehicleBusiness = vehicleBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleDTO dto)
        {
            try
            {
                await _vehicleBusiness.CreateVehicle(dto);
                return Ok();
            }
            catch (InvalidPlateException)
            {
                return BadRequest("A plca informada não está correta!");
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}