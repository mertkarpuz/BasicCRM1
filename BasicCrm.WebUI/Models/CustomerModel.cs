using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCrm.WebUI.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Müşteri adı eksik!")]
        [DisplayName(displayName: "Ad:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Müşteri soyadı eksik!")]
        [DisplayName(displayName: "Soyad:")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Müşteri adresi eksik!")]
        [DisplayName(displayName: "Adres:")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Müşteri telefon numarası eksik!")]
        [DisplayName(displayName: "Telefon:")]
        public string Phone { get; set; }
    }
}
