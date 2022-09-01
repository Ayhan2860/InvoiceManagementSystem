using System.Collections.Generic;
using Entities.Concrete;

namespace MvcWebUI.Models.AddModels
{
    public class InvoiceAddViewModel
    {
        public Invoice Invoice { get; set; }
        public List<InvoiceGenre> InvoiceGenres { get; set; }
        public List<House> Houses  { get; set; }
    }
}