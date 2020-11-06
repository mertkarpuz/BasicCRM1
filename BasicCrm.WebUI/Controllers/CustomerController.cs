using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCrm.Entities;
using BasicCrm.WebUI.AlertToastr;
using BasicCrm.WebUI.Models;
using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BasicCrm.WebUI.AlertToastr.Toastr;

namespace BasicCrm.WebUI.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult GetAllCustomers()
        {
            return View(new CustomerListModel()
            {
                customers = _customerService.GetAll()
            });
        }


        public IActionResult AddCustomer()
        {
            return View(new CustomerModel());
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerModel _customer)
        {
            if (ModelState.IsValid)
            {
                var entity = new Customer();
                entity.Name = _customer.Name;
                entity.Surname = _customer.Surname;
                entity.Address = _customer.Address;
                entity.Phone = _customer.Phone;
                _customerService.Create(entity);
                TempData["notification"] = Toastr.Alert("Müşteri başarı ile eklendi.", "Başarılı!", NotificationType.success);
            }
            return View();
        }


       
        public IActionResult DeleteCustomer(int id)
        {
            var returnedValue = _customerService.GetById((int)id);
            if (returnedValue != null)
            {
                _customerService.deleteByIdWithSP(returnedValue.Id);
                TempData["notification"] = Toastr.Alert("Müşteri Silindi!", "Başarılı!", NotificationType.warning);
            }
            else
            {
                TempData["notification"] = Toastr.Alert("Müşteri silinirken sorun oluştu!", "Sorun!!!", NotificationType.info);
            }
            return RedirectToAction("GetAllCustomers");
        }



        public IActionResult UpdateCustomer(int id)
        {
            var returnedValue = _customerService.GetById(id);
            if (returnedValue != null)
            {
                var model = new CustomerModel()
                {
                    Id = returnedValue.Id,
                    Name = returnedValue.Name,
                    Surname = returnedValue.Surname,
                    Address = returnedValue.Address,
                    Phone = returnedValue.Phone
                };
            
            return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult UpdateCustomer(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _customerService.GetById(model.Id);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Surname = model.Surname;
                entity.Address = model.Address;
                entity.Phone = model.Phone;
                _customerService.Update(entity);
                TempData["notification"] = Toastr.Alert("Müşteri Güncellendi!", "Başarılı!", NotificationType.success);
                return RedirectToAction("GetAllCustomers");
            }
            return View();
        }

    }
}
