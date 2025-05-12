using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface ICategory:IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
   
    }
}
