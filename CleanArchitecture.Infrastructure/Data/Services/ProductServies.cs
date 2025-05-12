using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interface;
using CleanArchitecture.Domain.Entity;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.Infrastructure.Data.Services
{
    public class ProductServies :Service<Product>,IProduct
    {
        private readonly MyDbContext _context;
        public ProductServies(MyDbContext context):base(context)
        {
            _context = context;
        }
        //public async Task AddProduct(Product product)
        //{
        //    _context.Products.Add(product);
        //   await _context.SaveChangesAsync();
        //}

        //public void DeleteProduct(Product product)
        //{
        //    _context.Products.Remove(product);
        //}

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products =await _context.Products.Include(c => c.Category).ToListAsync();
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product =await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
            return product;
        } 

        public async Task Save()
        {
          await _context.SaveChangesAsync();
        }

        //public void UpdateProduct(Product product)
        //{
        //    _context.Products.Update(product);

        //}

        public async Task<IEnumerable<Category>> Category()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }


    }

}
  