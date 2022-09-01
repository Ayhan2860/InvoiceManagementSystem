using System;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MvcWebUI.Models;

namespace MvcWebUI.ViewsComponents
{
    public class ApartmentListViewComponent:ViewComponent
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentListViewComponent(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        public ViewViewComponentResult Invoke()
        {
            ApartmentViewModel model = new ApartmentViewModel
            {
                Apartments = _apartmentService.GetAll(),
                CurrentApartment = Convert.ToInt32(HttpContext.Request.Query["apartment"])
            };
             return View(model);
        }
    }
}