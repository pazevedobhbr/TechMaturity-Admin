using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMaturity.Application.DTOs;
using TechMaturity.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace TechMaturity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CapabilitiesController : ControllerBase
    {
        private readonly ICapabilityService _Capabilityservice;
            public CapabilitiesController(ICapabilityService CapabilityService)
        {
            _Capabilityservice = CapabilityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapabilityDTO>>> Get()
        {
            var Capabilities= await _Capabilityservice.GetCapabilities();
            if (Capabilities== null)
            {
                return NotFound("Capabilities Not Found");
            }
            return Ok(Capabilities);
        }

        [HttpGet("{id:int}", Name = "GetCapability")]
        public async Task<ActionResult<CapabilityDTO>> Get(int id)
        {
            var Capabilities= await _Capabilityservice.GetById(id);
            if (Capabilities== null)
            {
                return NotFound("Capabilities Not Found");
            }
            return Ok(Capabilities);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CapabilityDTO CapabilityDto)
        {
            if (CapabilityDto == null)
            {
                return BadRequest("Invalid Data");
            }

            await _Capabilityservice.Add(CapabilityDto);
            return new CreatedAtRouteResult("GetCapability", new { id = CapabilityDto.Id });
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CapabilityDTO CapabilityDto)
        {
            if (id != CapabilityDto.Id)
                return BadRequest();

            if (CapabilityDto == null)
                return BadRequest();

            await _Capabilityservice.Update(CapabilityDto);

            return Ok(CapabilityDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CapabilityDTO>> Delete(int id)
        {
            var Capability = await _Capabilityservice.GetById(id);

            if (Capability == null)
            {
                return NotFound("Capability not found.");
            }
            await _Capabilityservice.Remove(id);

            return Ok(Capability);
        }
    }
}


