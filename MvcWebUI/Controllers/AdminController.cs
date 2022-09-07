using System;
using System.Linq;
using Business.Abstract;
using Core.Extensions;
using Entities.ComplexTypes;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using MvcWebUI.Models.AddModels;
using MvcWebUI.Models.UpdateModels;

namespace MvcWebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    
    public class AdminController:Controller
    {
        private readonly IHouseService _houseService;
        private readonly IApartmentService _apartmentService;
        private readonly IResidentService _residentService;
        private readonly IInvoiceGenreService _invoiceGenreService;

        public AdminController(IHouseService HouseService, IApartmentService apartmentService, IResidentService residentService, IInvoiceGenreService invoiceGenreService)
        {
            _houseService = HouseService;
            _apartmentService = apartmentService;
            _residentService = residentService;
            _invoiceGenreService = invoiceGenreService;
        }



        public ActionResult Index()
        {
            return View();
        }
   

        public ActionResult Houses(int apartment = 0)
        {
             var houses = _houseService.GetByApartmentId(apartment);
            if(houses.Success)
            {
                 HouseViewModel model = new HouseViewModel
                {
                Houses = houses.Data
                };
                 return View(model);
            }
             TempData.Add("message",   String.Format(houses.Message));
            return View();
        }

        public ActionResult AddHouse()
        {
            HouseAddViewModel  model = new HouseAddViewModel
            {
                 House = new House(),
                 Apartments = _apartmentService.GetAll()
            };

            return View(model);
        }
        
        [HttpPost]
        public ActionResult AddHouse(House house)
        {
              
               
               if(ModelState.IsValid)
              {
                var result =  _houseService.Add(house);
               
               if(result.Success){
                TempData.Add("message",   result.Message);
                return RedirectToAction("AddHouse");
                
               }
                TempData.Add("message",   String.Format(result.Message));
                return RedirectToAction("AddHouse");
              }
               return RedirectToAction("AddHouse");
            
        }

        public ActionResult UpdateHouse(int houseId)
        {
            HouseUpdateViewModel  model = new HouseUpdateViewModel
            {
                 House = _houseService.GetById(houseId).Data,
                 Apartments = _apartmentService.GetAll()
            };

            return View(model);
        }
        
        [HttpPost]
        public ActionResult UpdateHouse(House house)
        {
            if(ModelState.IsValid)
            {
               var result =  _houseService.Update(house);
               if(result.Success)
                 return RedirectToAction("UpdateHouse", "Admin", new {houseId = house.Id});
                TempData.Add("message",   String.Format(result.Message));
                return RedirectToAction("UpdateHouse", "Admin", new {houseId = house.Id});
            }
            return View();
        }

          public ActionResult DeleteHouse(int houseId)
        {
            if(ModelState.IsValid)
            {
               
               var result =  _houseService.Delete(_houseService.GetById(houseId).Data);
               if(result.Success)
                 return RedirectToAction("Houses", "Admin");
                TempData.Add("message",   String.Format(result.Message));
                return RedirectToAction("Houses", "Admin");
            }
            return View();
        }

        // Resident operations
    
        public ActionResult ResidentCreate()
        {
            ResidentCreateModel model = new ResidentCreateModel
                  {
                     ResidentCreateDto = new ResidentForCreateDto(),
                    Houses =_houseService.GetAllState(false).Data
                  };
            return View(model);
        }

        [HttpPost]
        public ActionResult ResidentCreate(ResidentCreateModel resident)
        {
             if(ModelState.IsValid)
             {
                  var result = _residentService.CreateResident(resident.ResidentCreateDto);
                  if(result.Success)
                  {
                    return RedirectToAction("Houses", "Admin");
                  }
                  TempData.Add("message",   String.Format(result.Message));
                  return RedirectToAction("ResidentCreate", "Admin");
             }
            return View();
        }
        

       

         
         public ActionResult HouseDetail(int houseId)
         {
            var houseDetail  = _houseService.GetDataResult(houseId);
            
            if(houseDetail.Success)
             {
                var model = new HouseForGetResidentDto();
                model = houseDetail.Data;
                return View(model);
             }

             return RedirectToAction("Houses", "Admin");
            
         }

         public ActionResult AddInvoice()
        {
            var model = new InvoiceAddViewModel
            {
                Invoice = new Invoice(),
                InvoiceGenres = _invoiceGenreService.GetAll().Data,
                Houses = _houseService.GetAllState(true).Data
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddInvoice(Invoice invoice)
        {
          
            return RedirectToAction("Houses", "Admin");
        }
       

    }
}