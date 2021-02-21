using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<=1)
            {
                //Console.WriteLine("\nAraba ismi minimum iki karakterli olmalıdır.");
                return new ErrorResult(Messages.CarBrandNameInValid);
            }
            else
            {
                //Console.WriteLine(brand.BrandName + " isimli araba sisteme eklendi");
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<List<Brand>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(c => c.BrandId == brandId));
        }
    }
}
