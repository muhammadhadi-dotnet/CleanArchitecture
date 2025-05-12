using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data.Services
{
    internal class CategoryService:Service<Category>, ICategory
    {
        private readonly MyDbContext _context;
        public CategoryService(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
           var categories =await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
           var category =await _context.Categories.FirstOrDefaultAsync(i => i.Id == id);
            return category;
        }
    }
}
