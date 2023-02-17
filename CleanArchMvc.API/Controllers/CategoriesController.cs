using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryservice;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryservice = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryservice.GetCategories();
            if (categories == null)
            {
                return NotFound("Categories Not Found");
            }
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var categories = await _categoryservice.GetById(id);
            if (categories == null)
            {
                return NotFound("Categories Not Found");
            }
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Invalid Data");
            }

            await _categoryservice.Add(categoryDto);
            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.Id });
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id)
                return BadRequest();

            if (categoryDto == null)
                return BadRequest();

            await _categoryservice.Update(categoryDto);

            return Ok(categoryDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryservice.GetById(id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }
            await _categoryservice.Remove(id);

            return Ok(category);
        }
    }
}

