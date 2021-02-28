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
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,ReCapDBContext>,ICustomerDal
    {
        public List<Customer> GetAll()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from c in context.Customers
                             select new Customer
                             {
                                 CustomerId = c.CustomerId,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
