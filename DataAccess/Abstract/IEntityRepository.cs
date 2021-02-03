using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic kısıt -generic constraint
    // where de yazan class referans tip olabilir demek
    //where ile kısıt vererek sadece istediğimiz nesnelerın gelmesını saglayabılrz
    //IEntity  : IEntity olabilir olabılır yada IEntity implemente eden bir nesne olabılır IEntityGonderımını engelledık ancak IEntity implemente eden nesnelere halen acık bu sekılde IEntity den impelemede olmus Product Category gibi nesneler gonderılebılır
    //new() :new'lenebilir olmalı. IEntity Newlenemedıgı için 
   public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Expression<Func<T,bool>> filter=null ile linq ile istegiğimiz filtreleri verebiliriz
        //filter = null   filtre vermeyebilirsin demek vermeyınce tum verıyı getırır 
        // T Get(Expression<Func<T, bool>> filter); kodu sadece tek veriyi cagırmamızı saglar 
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       
    }
}
