using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //"where T:class,IEntity,new()" ile T yi kısıtlıyoruz T sadece class referans tipi olabilir ve IEntity veya IEntity implement olan bir class
    //new() : new'lenebilir olmalı IEntity new lenemez böylelikle IEntity nini implement olanları alır
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //"Expression<Func<T,bool>> filter=null" ile listelerde linq ile filtrelemeye yardıcı olurr "filter=null" filtre vermeye bilrisin
        T Get(Expression<Func<T, bool>> filter); // Tek bir bilginin detajına gitme
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
