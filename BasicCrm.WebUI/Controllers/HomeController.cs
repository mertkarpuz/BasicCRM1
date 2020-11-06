using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCrm.WebUI.Models;
using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrm.WebUI.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
            
        }
    }
}
