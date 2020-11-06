using BasicCrm.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCrm.DataAccessLayer.Concrete.EfCore
{
    public class BasicCrmContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =basicCrm.mssql.somee.com; User Id = mkomert2_SQLLogin_1; Password = ap1tvdo7yr; Database = basicCrm; ");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
