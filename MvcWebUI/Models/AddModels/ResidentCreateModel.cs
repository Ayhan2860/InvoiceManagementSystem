using System.Collections.Generic;
using Entities.ComplexTypes;
using Entities.Concrete;

namespace MvcWebUI.Models.AddModels
{
    public class ResidentCreateModel
    {
        public ResidentForCreateDto ResidentCreateDto { get; set; }
        public List<House> Houses { get; set; }
    }
}