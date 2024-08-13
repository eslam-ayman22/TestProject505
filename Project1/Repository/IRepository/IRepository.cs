using Project1.Models;
using System.Linq.Expressions;

namespace Project1.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void create(T entity);

        void Edit(T entity);


        void delete(T entity);


        IEnumerable<T> GetAll();


        IEnumerable<T> Get(Expression<Func<T,bool>> expression , string include= null);

        void commit();
    }
}
