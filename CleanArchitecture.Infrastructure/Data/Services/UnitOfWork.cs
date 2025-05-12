using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interface;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Infrastructure.Data.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProduct product { get; private set; }
        public ICategory category { get; private set; }
        private readonly MyDbContext _context;
        public UnitOfWork(MyDbContext context)
        {
            _context = context;

            product = new ProductServies(_context);
            category = new CategoryService(_context);
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }
    }

}
