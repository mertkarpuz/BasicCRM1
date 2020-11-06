using BasicCrm.DataAccessLayer.Abstract;
using BasicCrm.DataAccessLayer.Concrete.EfCore;
using BasicCrm.Entities;
using BusinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDAL _customerDal;
        public CustomerManager(ICustomerDAL customerDal)
        {
            _customerDal = customerDal;
        }
        public void Create(Customer entity)
        {
           _customerDal.Create(entity);
        }

        public void Delete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void Update(Customer entity)
        {
            _customerDal.Update(entity);
        }
    }
}
