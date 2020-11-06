using BasicCrm.DataAccessLayer.Abstract;
using BasicCrm.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BasicCrm.DataAccessLayer.Concrete.EfCore
{
    public class EfCoreCustomerDal : EfCoreGenericRepository<Customer, BasicCrmContext>, ICustomerDAL
    {
       
        
    }
}
