using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.ComplexTypes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
       private readonly IAuthService _authService;

        public HomeController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Login(UserForLoginDto userForLoginDto)
        {
            
            if(!ModelState.IsValid)
            {
                  return View();
            }
            var result = _authService.Login(userForLoginDto);
            var claimsPrincipal = _authService.GetClaimsPrincipal(CookieAuthenticationDefaults.AuthenticationScheme, result.Data);
            if(result.Success)
            {
                   HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal.Data);
                
                 if(claimsPrincipal.Data.IsInRole("Admin"))
                 {
                   
                    return RedirectToAction("Index", "Admin");
                 }
                    return RedirectToAction("Index", "User");
                 
            }
            return View();
        }
         
         public  async Task<ActionResult> Logout()
         {


             await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
         }
     

    
    }
}
