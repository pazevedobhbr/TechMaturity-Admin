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
    public class CriteriasController : ControllerBase
    {
        private readonly ICriteriaService _Criteriaservice;
            public CriteriasController(ICriteriaService CriteriaService)
        {
            _Criteriaservice = CriteriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CriteriaDTO>>> Get()
        {
            var Criterias= await _Criteriaservice.GetCriterias();
            if (Criterias== null)
            {
                return NotFound("Criterias Not Found");
            }
            return Ok(Criterias);
        }

        [HttpGet("{id:int}", Name = "GetCriteria")]
        public async Task<ActionResult<CriteriaDTO>> Get(int id)
        {
            var Criterias= await _Criteriaservice.GetById(id);
            if (Criterias== null)
            {
                return NotFound("Criterias Not Found");
            }
            return Ok(Criterias);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CriteriaDTO CriteriaDto)
        {
            if (CriteriaDto == null)
            {
                return BadRequest("Invalid Data");
            }

            await _Criteriaservice.Add(CriteriaDto);
            return new CreatedAtRouteResult("GetCriteria", new { id = CriteriaDto.Id });
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CriteriaDTO CriteriaDto)
        {
            if (id != CriteriaDto.Id)
                return BadRequest();

            if (CriteriaDto == null)
                return BadRequest();

            await _Criteriaservice.Update(CriteriaDto);

            return Ok(CriteriaDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CriteriaDTO>> Delete(int id)
        {
            var Criteria = await _Criteriaservice.GetById(id);

            if (Criteria == null)
            {
                return NotFound("Criteria not found.");
            }
            await _Criteriaservice.Remove(id);

            return Ok(Criteria);
        }
    }
}


