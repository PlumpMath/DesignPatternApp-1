using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;


namespace DesignPatternApp
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> DbSet;

        public Repository(DbContext dataContext)
        {
            DbSet = dataContext.Set<T>();
        }

        #region IRepository<T> Members

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        #endregion
    }

    public class PartDBContext : DbContext
    {
        public DbSet<PartModels> Parts { get; set; }
    }

    public class PartModels
    {
        public int ID { get; set; }
        public string PartNumber { get; set; }      
        public string Description { get; set; }     
        public string AcquisitionType { get; set; }
        public string UnitOfMeasure { get; set; }
    }
}
