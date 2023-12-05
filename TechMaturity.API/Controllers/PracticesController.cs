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
    public class PracticesController : ControllerBase
    {
        private readonly IPracticeService _Practiceservice;
        public PracticesController(IPracticeService PracticeService)
        {
            _Practiceservice = PracticeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PracticeDTO>>> Get()
        {
            var Practices = await _Practiceservice.GetPractices();
            if (Practices == null)
            {
                return NotFound("Practices Not Found");
            }
            return Ok(Practices);
        }

        [HttpGet("{id:int}", Name = "GetPractice")]
        public async Task<ActionResult<PracticeDTO>> Get(int id)
        {
            var Practices = await _Practiceservice.GetById(id);
            if (Practices == null)
            {
                return NotFound("Practices Not Found");
            }
            return Ok(Practices);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PracticeDTO PracticeDto)
        {
            if (PracticeDto == null)
            {
                return BadRequest("Invalid Data");
            }

            await _Practiceservice.Add(PracticeDto);
            return new CreatedAtRouteResult("GetPractice", new { id = PracticeDto.Id });
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] PracticeDTO PracticeDto)
        {
            if (id != PracticeDto.Id)
                return BadRequest();

            if (PracticeDto == null)
                return BadRequest();

            await _Practiceservice.Update(PracticeDto);

            return Ok(PracticeDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PracticeDTO>> Delete(int id)
        {
            var Practice = await _Practiceservice.GetById(id);

            if (Practice == null)
            {
                return NotFound("Practice not found.");
            }
            await _Practiceservice.Remove(id);

            return Ok(Practice);
        }
    }
}

