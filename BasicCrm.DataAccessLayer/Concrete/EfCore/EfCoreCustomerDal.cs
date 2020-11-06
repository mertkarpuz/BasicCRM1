using BasicCrm.DataAccessLayer.Abstract;
using BasicCrm.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BasicCrm.DataAccessLayer.Concrete.EfCore
{
    public class EfCoreCustomerDal : EfCoreGenericRepository<Customer, BasicCrmContext>, ICustomerDAL
    {
        public void deleteByIdWithSP(int id)
        {
            using (var context = new BasicCrmContext())
            {
                context.Database.ExecuteSqlInterpolatedAsync($"sp_customerDelete {id}");
                context.SaveChanges();
            }
        }
    }
}
