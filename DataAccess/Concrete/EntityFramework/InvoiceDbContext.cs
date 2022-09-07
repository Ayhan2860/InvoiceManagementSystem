using System.Linq;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class InvoiceDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=invoiceManagementSystemDb; Username=<Your_UserName>; Password=<Your_Password>");
        }
        public DbSet<House> Houses { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceGenre> InvoiceGenres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<OperationClaim>().ToTable("OperationClaims");
            modelBuilder.Entity<UserOperationClaim>().ToTable("UserOperationClaims");
            modelBuilder.Entity<Apartment>().ToTable("Apartments");

           
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash("12345", out passwordHash, out passwordSalt);
            User userEntitySeed = new User{
              Id=1,  FirstName = "Admin", LastName = "manager", Email = "admin@admin.com", PhoneNumber= "02122323232",
                PasswordHash = passwordHash, PasswordSalt = passwordSalt, NationalyId = "00000000000"
            }; 
            modelBuilder.Entity<User>().HasData(userEntitySeed);
            
            OperationClaim[] operationClaimEntitySeeds =  {
                new OperationClaim {Id = 1, Name= "Admin"},
                new OperationClaim {Id = 2, Name = "User"},
                new OperationClaim {Id = 3, Name = "Manager"}
            };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimEntitySeeds);

            UserOperationClaim userOperationClaimEntitySeed = new UserOperationClaim{
                Id = 1,
                UserId = userEntitySeed.Id,
                OperationClaimId = operationClaimEntitySeeds.Where(x => x.Name == "Admin").First().Id
            };

            modelBuilder.Entity<UserOperationClaim>().HasData(userOperationClaimEntitySeed);

            Apartment[] apartmentEntitySeeds = {
                new Apartment {Id = 1, NumberOfFloors = 10, NumberOfHousesOnTheFloors = 3, BlockName = "A Block"},
                new Apartment {Id = 2, NumberOfFloors = 10, NumberOfHousesOnTheFloors = 3, BlockName = "B Block"},
                new Apartment {Id = 3, NumberOfFloors = 10, NumberOfHousesOnTheFloors = 3, BlockName = "C Block"},
                new Apartment {Id = 4, NumberOfFloors = 10, NumberOfHousesOnTheFloors = 3, BlockName = "D Block"},
                new Apartment {Id = 5, NumberOfFloors = 10, NumberOfHousesOnTheFloors = 3, BlockName = "E Block"}
            };
            
            modelBuilder.Entity<Apartment>().HasData(apartmentEntitySeeds);
        }

    }
}