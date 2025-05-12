using CleanArchitecture.Application.Common.Interface;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _UnitofWork;

        public ProductController(IUnitOfWork UnitofWork)
        {
            _UnitofWork = UnitofWork;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _UnitofWork.product.GetAllProducts();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["cagegories"] = new SelectList(await _UnitofWork.product.Category(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _UnitofWork.product.Add(product);
                await _UnitofWork.Save();
                TempData["success"] = "Product Created successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _UnitofWork.product.GetProductById(id);
            ViewData["cagegories"] = new SelectList(await _UnitofWork.product.Category(), "Id", "Name");
            return View(product);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _UnitofWork.product.Update(product);
                await _UnitofWork.Save();
                TempData["success"] = "Product Edited successfuly";
                return RedirectToAction("Index");
            }
            ViewData["cagegories"] = new SelectList(await _UnitofWork.product.Category(), "Id", "Name");
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _UnitofWork.product.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            if (ModelState.IsValid)
            {
                _UnitofWork.product.Delete(product);
                await _UnitofWork.Save();
                TempData["success"] = "Product Deleted successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
