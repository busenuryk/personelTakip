using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;


namespace Repositories.EfCore
{
    //t refereans tipli bir ifade o yüzden where ile sadece ref tipli ifadelerin kullanılmasını
    public abstract class RepositoryBase<T>(RepositoryContext _context) : IRepositoryBase<T> where T : class
    {
        public void Add(T entity) => _context.Set<T>().Add(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);
        public IQueryable<T> GetAll(bool trackChanges) => !trackChanges
             ? _context.Set<T>().AsNoTracking()
             : _context.Set<T>();

        public T GetById(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Find(expression);
        }
        public T GetByFilter(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).FirstOrDefault();

        }

        public IQueryable<T> GetFilteredAll(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges
        ? _context.Set<T>().Where(expression).AsNoTracking()
        : _context.Set<T>().Where(expression);

    }

}
