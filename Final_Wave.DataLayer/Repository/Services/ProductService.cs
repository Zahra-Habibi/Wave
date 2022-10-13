using Final_Wave.DataLayer.Contexxt;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Repository.Services
{
    
    public class ProductService:IProductRepasitory
    {
        private readonly ApplicationContext _context;
        public ProductService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> GetProductByProductNameAsync(string productName, int id)
        {
            var product = await _context.products.FirstOrDefaultAsync(x => x.ProductName == productName);
            if (product != null && product.Id != id) return true;
            return false;
        }


        public List<Product> Search(string text, List<int> categoryid, int sort = 1)
        {
            IQueryable<Product> products = _context.products.Where(x => x.ProductName.Contains(text));

        

            if (categoryid.Count() > 0)
            {
                products = products.Where(c => categoryid.Contains(c.CategoryId));
            }

            var query = (from p in products
                         select new
                         {
                             id = p.Id,
                             name = p.ProductName,
                             image = p.ProductImage
                         });

            List<Product> listProducts = new List<Product>();
            foreach (var product in products)
            {
                listProducts.Add(new Product
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductImage = product.ProductImage
                });
            }

            return listProducts;
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _context.products.Where(x => x.Id == productId)
                   .SingleOrDefaultAsync();
        }
        public async Task<List<Skills>> GetJobs()
        {
            return await _context.skills.ToListAsync();
        }


    }
}
