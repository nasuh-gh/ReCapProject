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
            //CarTestGetAllandAdd();

            //BrandTestGetAllandAdd();

            //ColorTestByColorId();

            CarTestDetails();

        }

        private static void CarTestDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + " - " + car.CarName + " - " + car.BrandName + " - "
                        + car.ColorName + " - " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }

        private static void ColorTestByColorId()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetCarsByColorId(3).Data)
            {
                Console.WriteLine("\n\n" + color.ColorName);
            }
        }

        private static void BrandTestGetAllandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand
            {
                BrandName = "Murat 131"
            });

            Console.WriteLine("\nARABA MARKALARI");

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            foreach (var brand in brandManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine("\n\n" + brand.BrandName);
            }
        }

        private static void CarTestGetAllandAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + " - " + car.BrandId + " - " + car.ColorId + " - "
                    + car.ModelYear + " - " + car.DailyPrice + " - " + car.Description);
            }

            carManager.Add(new Car
            {
                BrandId = 2,
                ColorId = 3,
                ModelYear = "2020",
                DailyPrice = 1000,
                Description = "Sıfır Araba"
            });
        }
    }
}
