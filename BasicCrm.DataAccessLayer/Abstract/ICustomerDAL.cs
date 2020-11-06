using BasicCrm.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCrm.DataAccessLayer.Abstract
{
    public interface ICustomerDAL:IRepository<Customer>
    {
        public void deleteByIdWithSP(int id);
    }
}
