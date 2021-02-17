using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length<=1)
            {
                Console.WriteLine("\nAraba ismi minimum iki karakterli olmalıdır.");
            }
            else
            {
                Console.WriteLine(brand.BrandName + " isimli araba sisteme eklendi");
                _brandDal.Add(brand);
            }
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetCarsByBrandId(int brandId)
        {
            return _brandDal.GetAll(c => c.BrandId == brandId);
        }
    }
}
