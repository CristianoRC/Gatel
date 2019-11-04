using System;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;

namespace Api
{
    [Route("/api/Access")]
    [ApiController]
    public class AccessController : Controller
    {
        private readonly IAccessBusiness _accessBusiness;

        public AccessController(IAccessBusiness accessBusiness)
        {
            _accessBusiness = accessBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> VerifyAccess([FromBody] ImageBase64DTO dto)
        {
            
            if (string.IsNullOrEmpty(dto.Image))
                return Unauthorized();

            if (await _accessBusiness.CarCanAccess(dto.Image))
                return Ok();

            return Unauthorized();
        }
    }
}