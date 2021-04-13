using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDısposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext()) // işlem bitince bellekten silinir
            {
                var addedEntity = context.Entry(entity); //"Entry()"-> Git veritabanındaki nesneye ilişkilendir demek 
                addedEntity.State = EntityState.Added; // "Entry()" ile eşitleneni "Ekleme" "Güncelleme" "Silme" yapar
                context.SaveChanges(); //"SaveChanges()"-> işlemleri gerçekleştir
            }
        }

        public void Delete(Product entity)
        {
            //IDısposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext()) // işlem bitince bellekten silinir
            {
                var deletedEntity = context.Entry(entity); //"Entry()"-> Git veritabanındaki nesneye ilişkilendir demek 
                deletedEntity.State = EntityState.Deleted; // "Entry()" ile eşitleneni "Ekleme" "Güncelleme" "Silme" yapar
                context.SaveChanges(); //"SaveChanges()"-> işlemleri gerçekleştir
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //filter == null ? "null ise" : "nul değilse"
                //context.Set<Product>().ToList() Veritabanındaki "Product" tablosunu liste olarak verir 
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            //IDısposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext()) // işlem bitince bellekten silinir
            {
                var updatedEntity = context.Entry(entity); //"Entry()"-> Git veritabanındaki nesneye ilişkilendir demek 
                updatedEntity.State = EntityState.Modified; // "Entry()" ile eşitleneni "Ekleme" "Güncelleme" "Silme" yapar
                context.SaveChanges(); //"SaveChanges()"-> işlemleri gerçekleştir
            }
        }
    }
}
