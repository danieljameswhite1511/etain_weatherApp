using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using Core.Specifications;

namespace Infrastructure.Data
{
    public class GenericRepsository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        public GenericRepsository(DataContext context)
        {
            _context = context;

        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);

        }

        public void Delete(T entity){

            _context.Set<T>().Remove(entity);

        }


        //ISpecifications
         public async Task<T> SingleAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec){

               return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }


        //IQueryables
        public IQueryable<T> ReturnQueryable()
        {
            IQueryable<T> query = _context.Set<T>();

            return query;
        }
        public IQueryable<T> ReturnQueryableWhere(Expression<Func<T, bool>> query)
        {
            IQueryable<T> queryResult = _context.Set<T>().Where(query); 

            return queryResult;
        }
        
        public IQueryable<T> ReturnQueryableInclude(params Expression<Func<T, object>> [] includeExpressions)
        {
            IQueryable<T> set = _context.Set<T>();

                foreach (var includeExpression in includeExpressions)
                {
                  set = set.Include(includeExpression);
                }
            return set;

        }     

       
        //Standard async from _context using generics

           public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> QueryListAsync(Expression<Func<T, bool>> query)
        {
            return await _context.Set<T>().Where(query).ToListAsync();
        }


    }
}