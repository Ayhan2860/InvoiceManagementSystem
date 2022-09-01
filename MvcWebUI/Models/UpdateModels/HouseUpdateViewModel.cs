using System.Collections.Generic;
using Entities.Concrete;

namespace MvcWebUI.Models.UpdateModels
{
    public class HouseUpdateViewModel
    {
       public House House { get; set; }
       public List<Apartment> Apartments {get; set;}
    }
}