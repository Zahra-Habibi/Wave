using Final_Wave.DataLayer.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.ViewComponents.UserInfoComponent
{
    public class UserInformationComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserInformationComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("UserInformation", await _userManager.GetUserAsync(HttpContext.User)));

        }
    }
}
