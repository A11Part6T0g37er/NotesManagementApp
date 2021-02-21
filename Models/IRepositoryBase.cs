using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NotesManagementApp.Models
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}