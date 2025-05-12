using CleanArchitecture.Application.Common.Interface;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _IProduct;

        public ProductController(IProduct IProduct)
        {
            _IProduct = IProduct;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _IProduct.GetAllProducts();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["cagegories"] = new SelectList(await _IProduct.Category(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _IProduct.Add(product);
                await _IProduct.Save();
                TempData["success"] = "Product Created successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _IProduct.GetProductById(id);
            ViewData["cagegories"] = new SelectList(await _IProduct.Category(), "Id", "Name");
            return View(product);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
               _IProduct.Update(product);
                await _IProduct.Save();
                TempData["success"] = "Product Edited successfuly";
                return RedirectToAction("Index");
            }
            ViewData["cagegories"] = new SelectList(await _IProduct.Category(), "Id", "Name");
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _IProduct.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            if (ModelState.IsValid)
            {
                _IProduct.Delete(product);
                await _IProduct.Save();
                TempData["success"] = "Product Deleted successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
