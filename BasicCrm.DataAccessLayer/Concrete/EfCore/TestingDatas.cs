using BasicCrm.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicCrm.DataAccessLayer.Concrete.EfCore
{
    public static class TestingDatas
    {
        public static void Datas()
        {
            var context = new BasicCrmContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Customers.Count() == 0)
                {
                    context.Customers.AddRange(customers);
                }
                context.SaveChanges();
            }

        }
        private static Customer[] customers = {
        new Customer() { Name = "Ahmet", Surname = "Şık", Address="Osman Gazi sok. Turgut caddesi No:2 / 1 Florya/ISTANBUL",Phone = "05488845478" },
        new Customer() { Name = "Berkay", Surname = "Gündüz", Address="Osman Gazi sok. Turgut caddesi No:2 / 1 Florya/ISTANBUL",Phone = "05488355425" },
        new Customer() { Name = "Osman", Surname = "Yıldırım", Address="Osman Gazi sok. Turgut caddesi No:2 / 1 Florya/ISTANBUL",Phone = "05482845448" },
        new Customer() { Name = "Halit", Surname = "Osman", Address="Osman Gazi sok. Turgut caddesi No:2 / 1 Florya/ISTANBUL",Phone = "05488845478" },
        new Customer() { Name = "Ayşe", Surname = "Deneme", Address="Osman Gazi sok. Turgut caddesi No:2 / 1 Florya/ISTANBUL",Phone = "05451555221" },
        new Customer() { Name = "Ali", Surname = "Gün", Address="Osman Gazi sok. Turgut caddesi No:2 / 1 Florya/ISTANBUL",Phone = "05488628478" }
        };
    }
}

    

