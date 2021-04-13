using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını Bağlamak
    //DbContext :  Microsoft.EntityFrameworkCore ile geldi
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Hangi Veritabanı ile ilişkindirilecek onu seçiyoruz
        {
            //Trusted_Connection=true kullanıcı adı paralo istemeden
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; } // "DbSet<Product>"-> hangi Class "Products"-> hangi tabloya karşılık geliyor
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
