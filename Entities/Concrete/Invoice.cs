using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Invoice : IEntity
    {
        public int Id { get; set; }
        public int InvoiceGenreId { get; set; }
        public int HouseId { get; set; }
        public DateTime InvocingDateTime { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}