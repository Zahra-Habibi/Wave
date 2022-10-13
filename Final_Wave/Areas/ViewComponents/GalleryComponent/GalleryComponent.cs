using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Multipisus.Areas.ViewComponents.GalleryComponent
{
    public class GalleryComponent: ViewComponent
    {
        private readonly IUnitOfWork _context;
        public GalleryComponent(IUnitOfWork unit)
        {
            _context= unit;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return await Task.FromResult((IViewComponentResult)View("GalleryAdmin", await _context.galleryUW.GetEntitiesAsync(x => x.ProductId == id)));
        }
    }
}
