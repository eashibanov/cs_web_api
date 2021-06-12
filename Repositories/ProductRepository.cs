using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;
using ProductsAPI.Models;

namespace ProductsAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext context;
        public ProductRepository(IDataContext context)
        {
            this.context = context;
        }
        public async Task Add(Product product)
        {
            this.context.Products.Add(product);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var item = await this.context.Products.FindAsync(Id);
            if (item == null)
                throw new NullReferenceException();
            this.context.Products.Remove(item);
            await this.context.SaveChangesAsync();
        }

        public async Task<Product> Get(int Id)
        {
            return await this.context.Products.FindAsync(Id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await this.context.Products.ToListAsync();
        }

        public async Task Update(Product product)
        {
            var item = await this.context.Products.FindAsync(product);
            if (item == null)
                throw new NullReferenceException();
            item.Name = product.Name;
            item.Price = product.Price;
            
            await this.context.SaveChangesAsync();
        }
    }
}