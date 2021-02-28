using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, ReCapDBContext>, IBrandDal
    {
        public List<Brand> GetAll()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from b in context.Brands
                             select new Brand
                             {
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName
                             };
                return result.ToList();
            }
        }
    }
}
