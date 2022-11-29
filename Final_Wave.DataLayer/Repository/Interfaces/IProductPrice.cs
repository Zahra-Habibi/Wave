using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.DataLayer.Repository.Interfaces
{
    public interface IProductPrice
    {
        List<ProductPriceViewModel> ShowAllPriceForProduct(int Productid);
        int AddPriceForProduct(ProductPrice productPrice);
        List<SpecialProductViewModel> ShowDetailsProduct(int productid);
    }
}
