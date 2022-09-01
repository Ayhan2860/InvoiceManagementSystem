using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    [Authorize(Roles ="User,Admin")]
    public class UserController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}