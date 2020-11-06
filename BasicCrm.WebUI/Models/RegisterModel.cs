using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCrm.WebUI.Models
{
    public class RegisterModel
    {
        [Display(Name ="Ad:")]
        public string Name { get; set; }
        [Display(Name = "Soyad:")]
        public string Surname { get; set; }
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Display(Name = "Şifre:")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrarı:")]
        public string RePassword { get; set; }
        [Display(Name = "Telefon:")]
        public string Phone { get; set; }
    }
}
