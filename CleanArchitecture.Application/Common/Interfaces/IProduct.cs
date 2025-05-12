using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Application.Common.Interface
{
    public interface IProduct: IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
 
        Task<IEnumerable<Category>> Category();
        Task Save();
             
    }
}
