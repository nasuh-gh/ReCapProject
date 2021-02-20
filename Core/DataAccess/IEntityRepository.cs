using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //class   : referans tip
    //IEntity : IEntity olabilir veya IEntity implemente eden nesne olabilir
    //new()   : new'lenebilir olmalı (Yani IEntity(soyut) olamaz)
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//filtre vermeyebilirsin de demek
        T Get(Expression<Func<T, bool>> filter);//filtre vermek gerekiyor
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
