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
    public class PillarsController : ControllerBase
    {
        private readonly IPillarService _Pillarservice;
        public PillarsController(IPillarService PillarService)
        {
            _Pillarservice = PillarService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PillarDTO>>> Get()
        {
            var Pillars = await _Pillarservice.GetPillars();
            if (Pillars == null)
            {
                return NotFound("Pillars Not Found");
            }
            return Ok(Pillars);
        }

        [HttpGet("{id:int}", Name = "GetPillar")]
        public async Task<ActionResult<PillarDTO>> Get(int id)
        {
            var Pillars = await _Pillarservice.GetById(id);
            if (Pillars == null)
            {
                return NotFound("Pillars Not Found");
            }
            return Ok(Pillars);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PillarDTO PillarDto)
        {
            if (PillarDto == null)
            {
                return BadRequest("Invalid Data");
            }

            await _Pillarservice.Add(PillarDto);
            return new CreatedAtRouteResult("GetPillar", new { id = PillarDto.Id });
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] PillarDTO PillarDto)
        {
            if (id != PillarDto.Id)
                return BadRequest();

            if (PillarDto == null)
                return BadRequest();

            await _Pillarservice.Update(PillarDto);

            return Ok(PillarDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PillarDTO>> Delete(int id)
        {
            var Pillar = await _Pillarservice.GetById(id);

            if (Pillar == null)
            {
                return NotFound("Pillar not found.");
            }
            await _Pillarservice.Remove(id);

            return Ok(Pillar);
        }
    }
}

