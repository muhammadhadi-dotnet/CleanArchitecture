using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Application.Common.Interface
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        void DeleteProduct(Product product);

        Task<IEnumerable<Category>> Category();
        Task Save();
             
    }
}
