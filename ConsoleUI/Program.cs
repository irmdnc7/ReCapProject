using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        private static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
        }

            public static void RentalAdd(RentalManager rentalManager) {
                var result = rentalManager.Add(new Entities.Concrete.Rental()
                {
                    CarId = 10,
                    CustomerId = 2,
                    RentDate = DateTime.Now,
                    ReturnDate = new DateTime(2021, 3, 8)
                });
                Console.WriteLine(result.Message);
            }
        private static void CustomerAdd(CustomerManager customerManager)
        {
            customerManager.Add(new Customer()
            {
                CompanyName = "Irem",
                UserId = 3
            });
            customerManager.Add(new Customer()
            {
                CompanyName = "Mert",
                UserId = 5
            });
        }

            //var result = carManager.GetCarDetails();
            //if (result.Success == true)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine(car.BrandName + "/" + car.ColorName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
            }
            
        }
    

