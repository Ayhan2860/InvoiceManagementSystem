using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IInvoiceService
    {
        IDataResult<List<Invoice>> GetAll();
        IDataResult<Invoice> GetById(int id);
        IResult Add(Invoice invoice);
        IResult Delete(Invoice invoice);
        IResult Update(Invoice invoice);
    }
}