using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IInvoiceGenreService
    {
        IDataResult<List<InvoiceGenre>> GetAll();
        IDataResult<InvoiceGenre> GetById(int id);
        IResult Add(InvoiceGenre invoiceGenre);
        IResult Delete(InvoiceGenre invoiceGenre);
        IResult Update(InvoiceGenre invoiceGenre);
    }
}