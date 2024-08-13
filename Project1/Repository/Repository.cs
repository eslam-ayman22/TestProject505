using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Project1.Data;
using Project1.Repository.IRepository;
using System.Linq.Expressions;

namespace Project1.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> dbset;
        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            dbset = context.Set<T>();

        }

        public void commit()
        {
            context.SaveChanges();
        }
        public void create(T entity)
        {
            dbset.Add(entity);
           
        }

        public void delete(T entity)
        {
            dbset.Remove(entity);
            
        }

        public void Edit(T entity)
        {
            dbset.Update(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T,bool>> expression, string include = null)
        {
            if (include != null)
                return dbset.Include(include).Where(expression);
            else
                return dbset.Where(expression);

        }
    }
}
