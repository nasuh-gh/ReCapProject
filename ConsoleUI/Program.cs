using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll()) 
            {
                Console.WriteLine(car.Id + " - " + car.BrandId + " - " + car.ColorId + " - "
                    + car.ModelYear + " - " + car.DailyPrice + " - " + car.Description);
            }

            //carManager.Add(new Car { 
            //    BrandId = 2, 
            //    ColorId = 3, 
            //    ModelYear = "2020", 
            //    DailyPrice = 1000, 
            //    Description = "Sıfır Araba" 
            //});

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand
            {
                BrandName = "Nissan"
            });

            Console.WriteLine("\nARABA MARKALARI");

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            foreach (var brand in brandManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("\n\n"+brand.BrandName);
            }

            ColorManager colorManager=new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetCarsByColorId(3))
            {
                Console.WriteLine("\n\n"+color.ColorName);
            }

        }
    }
}
