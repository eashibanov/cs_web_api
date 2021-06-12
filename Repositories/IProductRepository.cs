using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsAPI.Models;

namespace ProductsAPI.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(int Id);
        Task<IEnumerable<Product>> GetAll();
        Task Delete(int Id);
        Task Add(Product product);
        Task Update(Product product);
    }
}