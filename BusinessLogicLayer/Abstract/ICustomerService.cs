using BasicCrm.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Abstract
{
    public interface ICustomerService
    {
        Customer GetById(int id);
        List<Customer> GetAll();
        void Create(Customer entity);
        void Update(Customer entity);
        void Delete(Customer entity);
        public void deleteByIdWithSP(int id);
    }
}
