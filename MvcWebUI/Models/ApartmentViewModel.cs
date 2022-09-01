using System.Collections.Generic;
using Entities.Concrete;

namespace MvcWebUI.Models
{
    public class ApartmentViewModel
    {
        public List<Apartment> Apartments { get; set; }
        public int CurrentApartment { get;  set; }
    }
}