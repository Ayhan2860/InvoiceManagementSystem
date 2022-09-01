using System.Collections.Generic;
using Entities.Concrete;

namespace MvcWebUI.Models.AddModels
{
    public class HouseAddViewModel
    {
       public House House { get; set; }
       public List<Apartment> Apartments {get; set;}
    }
}