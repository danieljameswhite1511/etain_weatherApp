using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Delete(T entity);
        Task<bool> Save();

        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAllAsync();
        Task<T> SingleAsync(ISpecification<T> spec);
        Task<List<T>> ListAsync(ISpecification<T> spec);

        Task<int> CountAsync(ISpecification<T> spec);


        IQueryable<T> ReturnQueryable();
        IQueryable<T> ReturnQueryableWhere(Expression<Func<T, bool>> queryExpression);
        IQueryable<T> ReturnQueryableInclude(params Expression<Func<T, object>> [] includeExpressions);
    }
}