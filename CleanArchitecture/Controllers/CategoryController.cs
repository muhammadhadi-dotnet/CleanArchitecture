using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entity;
using Microsoft.AspNetCore.Mvc;


namespace CleanArchitecture.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _UnitofWork;

        public CategoryController(IUnitOfWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }
        public async Task<IActionResult> Index()
        {
            var categores = await _UnitofWork.category.GetAllCategories();

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
                _UnitofWork.category.Add(category);
               await _UnitofWork.Save();
                TempData["success"] = "Category Created successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category= await _UnitofWork.category.GetCategoryById(id);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                _UnitofWork.category.Update(category);
                await _UnitofWork.Save();
                TempData["success"] = "Category Edited successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _UnitofWork.category.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Category category)
        {

            if (category != null)
            {
                _UnitofWork.category.Delete(category);
                await _UnitofWork.Save();
                TempData["success"] = "Category deleted successfuly";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Category Not deleted successfuly";

            return View();
        }

    }
}
