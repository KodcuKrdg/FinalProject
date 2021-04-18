using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>  where TEntity: class, IEntity, new() where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDısposable pattern implementation of c#
            using (TContext context = new TContext()) // işlem bitince bellekten silinir
            {
                var addedEntity = context.Entry(entity); //"Entry()"-> Git veritabanındaki nesneye ilişkilendir demek 
                addedEntity.State = EntityState.Added; // "Entry()" ile eşitleneni "Ekleme" "Güncelleme" "Silme" yapar
                context.SaveChanges(); //"SaveChanges()"-> işlemleri gerçekleştir
            }
        }

        public void Delete(TEntity entity)
        {
            //IDısposable pattern implementation of c#
            using (TContext context = new TContext()) // işlem bitince bellekten silinir
            {
                var deletedEntity = context.Entry(entity); //"Entry()"-> Git veritabanındaki nesneye ilişkilendir demek 
                deletedEntity.State = EntityState.Deleted; // "Entry()" ile eşitleneni "Ekleme" "Güncelleme" "Silme" yapar
                context.SaveChanges(); //"SaveChanges()"-> işlemleri gerçekleştir
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //filter == null ? "null ise" : "nul değilse"
                //context.Set<TEntity>().ToList() Veritabanındaki "TEntity" tablosunu liste olarak verir 
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            //IDısposable pattern implementation of c#
            using (TContext context = new TContext()) // işlem bitince bellekten silinir
            {
                var updatedEntity = context.Entry(entity); //"Entry()"-> Git veritabanındaki nesneye ilişkilendir demek 
                updatedEntity.State = EntityState.Modified; // "Entry()" ile eşitleneni "Ekleme" "Güncelleme" "Silme" yapar
                context.SaveChanges(); //"SaveChanges()"-> işlemleri gerçekleştir
            }
        }
    }
}
