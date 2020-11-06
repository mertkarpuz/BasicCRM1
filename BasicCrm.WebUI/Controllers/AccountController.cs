using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCrm.WebUI.AlertToastr;
using BasicCrm.WebUI.Identity;
using BasicCrm.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static BasicCrm.WebUI.AlertToastr.Toastr;

namespace BasicCrm.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new ApplicationUser
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.UserName,
                PhoneNumber = model.Phone

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                TempData["notification"] = Toastr.Alert("Başarı ile kayıt oldunuz!", "Hesabınız oluşturuldu", NotificationType.info);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }


        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["notification"] = Toastr.Alert("Bu kullanıcı ile daha önce hesap oluşturulmamış!", "HATA", NotificationType.error);
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                TempData["notification"] = Toastr.Alert("Giriş Başarılı!", "Kullanıcı İşlemi", NotificationType.success);
                return Redirect(model.ReturnUrl ?? "~/");
            }
            TempData["notification"] = Toastr.Alert("Kullanıcı adı veya şifre hatalı!", "HATA", NotificationType.error);
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["notification"] = Toastr.Alert("Oturum Kapatıldı", "Kullanıcı işlemi", NotificationType.info);
            return Redirect("~/");
        }


    }
}
