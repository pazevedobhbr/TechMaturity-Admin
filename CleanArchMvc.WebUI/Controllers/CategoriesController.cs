using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMaturity.Application.DTOs;
using TechMaturity.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechMaturity.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {       
        private readonly ICategoryService _categoryservice;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryservice = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryservice.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryservice.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoryDTO = await _categoryservice.GetById(id);

            if (categoryDTO == null) return NotFound();

            return View(categoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryservice.Update(categoryDto);
                }
                catch(Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var categoryDTO = await _categoryservice.GetById(id);

            if (categoryDTO == null) return NotFound();

            return View(categoryDTO);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await _categoryservice.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var categoryDTO = await _categoryservice.GetById(id);

            if (categoryDTO == null) return NotFound();

            return View(categoryDTO);
        }
    }
}