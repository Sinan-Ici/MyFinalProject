using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //generic constraint
    //class : referans tip 
    //IEntiyt: IEntity olabilir veya IEntity implemenete eden bir nesne olabilir.
    //new (): newlenebilri olmalı
    //core katmanında mantık istediğimiz katmanı burda ayrı ayrı implemente edebilmektir. farklı porojelerde kullanmak için core katmanı kullanırız. 

    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null);//filtreleme için kullanırız. Linq kullqanırken kullanırız. Ayrı ayrı metod kullanmayalım diye bu şekilde kullanıyoruz. Filter=null filtre vermeyebilrisn demektir. Örneğin  List<T> GetAllByCategory(int categoryID); bu metoda ihtiyacımız kalmayacak hangi türde istiyosak o türde filtreleyebiliriz. 1 kere kullanılır.
        T Get(Expression<Func<T, bool>> filter);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);

        
        
    }
}
