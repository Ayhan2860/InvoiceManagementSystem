using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    public class ErrorController:Controller
    {
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}