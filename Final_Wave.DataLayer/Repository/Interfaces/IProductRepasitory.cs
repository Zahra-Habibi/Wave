using Final_Wave.DataLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Repository.Interfaces
{
    public interface IProductRepasitory
    {
        Task<bool> GetProductByProductNameAsync(string productName, int id);

        List<Product> Search(string text, List<int> categoryid, int sort = 1);

        Task<Product> GetProductById(int productId);
        Task<List<Skills>> GetJobs();

    }
}
