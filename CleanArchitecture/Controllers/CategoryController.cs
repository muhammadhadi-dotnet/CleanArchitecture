using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyDbContext _context;
        public CategoryController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categores = await _context.Categories.ToListAsync();

            return View(categores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                TempData["success"] = "Category Created successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category=await _context.Categories.FindAsync(id);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                TempData["success"] = "Category Edited successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Category category)
        {

            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                TempData["success"] = "Category deleted successfuly";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Category Not deleted successfuly";

            return View();
        }

    }
}
