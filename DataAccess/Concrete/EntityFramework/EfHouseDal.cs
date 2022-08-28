using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.ComplexTypes;
using Entities.Concrete;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfHouseDal : EfEntityRepositoryBase<House, InvoiceDbContext>, IHouseDal
    {
        public HouseForGetResidentDto GetHouseForGetResidentDto(int id)
        {
            using (var context = new InvoiceDbContext())
            {
                 var result = from h in context.Houses
                              join r in context.Users
                              on h.UserId equals r.Id
                              join a in context.Apartments
                              on h.ApartmentId equals a.Id
                              where h.Id == id
                              select new HouseForGetResidentDto
                              {
                                FirstName = r.FirstName,
                                LastName = r.LastName,
                                BlockName = a.BlockName,
                                HouseType = h.TypeInfo  
                              };
                    return result.FirstOrDefault();
            }
        }
    }
}