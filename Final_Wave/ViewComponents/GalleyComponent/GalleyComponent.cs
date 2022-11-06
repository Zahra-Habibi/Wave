using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.ViewComponents.GalleyComponent
{
    public class GalleyComponent:ViewComponent
    {
        private readonly IUnitOfWork _context;
        public GalleyComponent(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult((IViewComponentResult)View("Gallery", await _context.galleryUW.GetEntitiesAsync(x => x.ProductId == id)));
        }
    }
}
