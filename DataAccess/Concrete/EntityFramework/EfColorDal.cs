using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, ReCapDBContext>, IColorDal
    {
        public List<Color> GetAll()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from c in context.Colors
                             select new Color
                             {
                                 ColorId = c.ColorId,
                                 ColorName = c.ColorName
                             };
                return result.ToList();
            }
        }
    }
}
