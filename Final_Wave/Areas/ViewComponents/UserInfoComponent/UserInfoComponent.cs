using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.ViewComponents.UserInfoComponent
{
    public class UserInfoComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserInfoComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("UserInfo", await _userManager.GetUserAsync(HttpContext.User)));
        }
    }
}
