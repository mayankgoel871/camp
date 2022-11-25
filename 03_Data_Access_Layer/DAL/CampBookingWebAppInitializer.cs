using _03_Data_Access_Layer.Data_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_Layer.DAL
{
  public class CampBookingWebAppInitializer : System.Data.Entity.CreateDatabaseIfNotExists<CampBookingDbContext>
  {
    protected override void Seed(CampBookingDbContext context) 
    {
      var camps = new List<CampDataEntity>
            {
                new CampDataEntity{Name = "ABC" , Capacity = 2 , Description = "abcdefghijkl" , Price = 1500 , ImageURL = "abc.jpg"},



                new CampDataEntity{Name = "pqr" , Capacity = 8 , Description = "mnopqrstuvwxyz" , Price = 2000 , ImageURL = "camp1.jpg"},

               
            };
       camps.ForEach(s => context.Camps.Add(s));
      context.SaveChanges();

      var bookings = new List<BookingDataEntity>
      {
        new BookingDataEntity{CampId = 1, BillingAddress = "Saket Nagar" , State = "UP" , Country = "India", ZipCode = 221005, CellPhone = 8090277329, ReferenceId = "abcd1234", StartDate = DateTime.Parse("29-08-2022 00:00:00"), EndDate = DateTime.Parse("30-08-2022 00:00:00"), TotalAmount = 3000 },
        new BookingDataEntity{CampId = 1, BillingAddress = "BHU" , State = "UP" , Country = "India", ZipCode = 221001, CellPhone = 1234567890, ReferenceId = "efgh5678", StartDate = DateTime.Parse("01-09-2022 00:00:00"), EndDate = DateTime.Parse("03-09-2022 00:00:00"), TotalAmount = 3400 },
      };
      bookings.ForEach(s => context.Bookings.Add(s));
      context.SaveChanges();

      var rating = new List<CampRatingDataEntity>
      {
        new CampRatingDataEntity{CampId = 1, Rating = 4 },
        new CampRatingDataEntity{CampId = 2, Rating = 5 },
        new CampRatingDataEntity{CampId = 3, Rating = 3 },
        new CampRatingDataEntity{CampId = 4, Rating = 2 },
        new CampRatingDataEntity{CampId = 5, Rating = 1 }
      };
      rating.ForEach(s => context.CampRatings.Add(s));
      context.SaveChanges();

      var users = new UserDataEntity
      {
        Username = "admin123",
        Password = "admin123",
        IsAdmin = true
      };


      context.Users.Add(users);
      context.SaveChanges();
    }
  } 
}
