using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        /*Generic yapıda ifade etme sebebimiz, farklı tipte class'ları dikkare almak
        T özellikle ref tipli olmak zorunda değil onu somut sınıfında belirticez
        o yüzden where ile bir kısıtlama getirmiyoruz*/

        //temeldeki işlemler
        IQueryable<T> GetAll(bool trackChanges); //listeleme -generic
        IQueryable<T> GetFilteredAll(Expression<Func<T, bool>> expression, bool trackChange); //filtreleme ile listeleme
        T GetById(Expression<Func<T, bool>> expression); //id ile getirme
        T GetByFilter(Expression<Func<T, bool>> expression); //filtremelme ile bir kişi getirir
        void Add(T entity); //ekleme
        void Update(T entity); //güncelleme
        void Delete(T entity); //silme
 
    }
}
