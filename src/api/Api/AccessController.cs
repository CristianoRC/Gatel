using System;
using System.Diagnostics;
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
        private readonly IGateControl _gateControl;

        public AccessController(IAccessBusiness accessBusiness, IGateControl gateControl)
        {
            _accessBusiness = accessBusiness;
            _gateControl = gateControl;
        }

        [HttpPost]
        public async Task<IActionResult> VerifyAccess([FromBody] ImageBase64DTO dto)
        {
            if (string.IsNullOrEmpty(dto.Image))
                return Unauthorized();

            var userCanAccess = await _accessBusiness.CarCanAccess(dto.Image);

            if (userCanAccess)
            {
                _gateControl.Open();
            }

            return Ok(new {userCanAccess});
        }
    }
}