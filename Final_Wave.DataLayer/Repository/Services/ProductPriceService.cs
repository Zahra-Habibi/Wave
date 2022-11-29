using Final_Wave.Core.ViewModels;
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
    public class ProductPriceService:IProductPrice
    {
        private ApplicationContext _context;
        public ProductPriceService(ApplicationContext context)
        {
            _context = context;
        }

        public List<ProductPriceViewModel> ShowAllPriceForProduct(int Productid)
        {
            List<ProductPriceViewModel> price = (from pr in _context.ProductPrice
                                                        join p in _context.products on pr.ProductId equals p.Id
                                                        where (pr.ProductId == Productid)

                                                        select new ProductPriceViewModel
                                                        {
                                                           
                                                            CreatDate = pr.CreatDate,
                                                            EndDateDiscount = pr.EndDateDiscount,
                                                            MainPrice = pr.MainPrice,
                                                            MaxOrderCount = pr.MaxOrderCount,
                                                            ProductId = p.Id,
                                                            ProductPriceId = pr.ProductPriceId,
                                                            SpecialPrice = pr.SpecialPrice,

                                                        }).ToList();
            return price;
        }

        public int AddPriceForProduct(ProductPrice productPrice)
        {
            try
            {
                _context.ProductPrice.Add(productPrice);
                _context.SaveChanges();
                return  productPrice.ProductPriceId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<SpecialProductViewModel> ShowDetailsProduct(int productid)
        {
            List<SpecialProductViewModel> detail = (from pr in _context.ProductPrice
                                                        join p in _context.products on pr.ProductId equals p.Id

                                                        where (pr.ProductId == productid)

                                                        select new SpecialProductViewModel
                                                        {
                                                            EndDiscount = pr.EndDateDiscount,
                                                            MainPrice = pr.MainPrice,
                                                            ProductName = p.Title,
                                                            Productid = p.Id,
                                                            Productimg = p.ProductImage,
                                                            Productsell = p.ProductSell,
                                                            productstar = p.ProductStar,
                                                            sepcialprice = pr.SpecialPrice < pr.MainPrice && pr.EndDateDiscount >= DateTime.Now.Date ? pr.SpecialPrice : pr.MainPrice,
                                                            Productpriceid = pr.ProductPriceId,
                                                        }).ToList();
            return detail;
        }


    }
}
