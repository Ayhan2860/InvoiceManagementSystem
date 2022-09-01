
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MvcWebUI.Models;

namespace MvcWebUI.ViewsComponents
{
    public class UserSummaryViewComponent:ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            
            UserSummaryViewModel model = new UserSummaryViewModel
            {
                 UserName = HttpContext.User.Identity.Name,
                 IsAdmin = HttpContext.User.IsInRole("Admin")
                 
            };
            return View(model);
        }
    }
}