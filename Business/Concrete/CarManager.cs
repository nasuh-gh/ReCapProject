using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                Console.WriteLine("\nAraba günlük fiyatı 0 TL'den büyük olmalıdır.");
            }
            else
            {
                Console.WriteLine(car.BrandId + " nolu marka araba sisteme eklendi");
                _carDal.Add(car);
            }
            
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

    }
}
