using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceDal _invoiceDal;

        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }

        public IResult Add(Invoice invoice)
        {

            _invoiceDal.Add(invoice);
            return new SuccessResult();
        }

        public IResult Delete(Invoice invoice)
        {
             _invoiceDal.Delete(invoice);
            return new SuccessResult();
        }

        public IDataResult<List<Invoice>> GetAll()
        {
            return new SuccessDataResult<List<Invoice>>(_invoiceDal.GetList());
        }

        public IDataResult<Invoice> GetById(int id)
        {
           return new SuccessDataResult<Invoice>(_invoiceDal.Get(x=> x.Id == id));
        }

        public IResult Update(Invoice invoice)
        {
             _invoiceDal.Update(invoice);
            return new SuccessResult();
        }
    }
}