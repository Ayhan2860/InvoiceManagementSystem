using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class InvoiceGenreManager : IInvoiceGenreService
    {
        private readonly IInvoiceGenreDal _invoiceGenreDal;

        public InvoiceGenreManager(IInvoiceGenreDal invoiceGenreDal)
        {
            _invoiceGenreDal = invoiceGenreDal;
        }

        public IResult Add(InvoiceGenre invoiceGenre)
        {
            _invoiceGenreDal.Add(invoiceGenre);
            return new SuccessResult();
        }

        public IResult Delete(InvoiceGenre invoiceGenre)
        {
            _invoiceGenreDal.Delete(invoiceGenre);
            return new SuccessResult();
        }

        public IDataResult<List<InvoiceGenre>> GetAll()
        {
           return new SuccessDataResult<List<InvoiceGenre>>(_invoiceGenreDal.GetList());
        }

        public IDataResult<InvoiceGenre> GetById(int id)
        {
            return new SuccessDataResult<InvoiceGenre>(_invoiceGenreDal.Get(x => x.Id == id));
        }

        public IResult Update(InvoiceGenre invoiceGenre)
        {
            _invoiceGenreDal.Update(invoiceGenre);
            return new SuccessResult();
        }
    }
}