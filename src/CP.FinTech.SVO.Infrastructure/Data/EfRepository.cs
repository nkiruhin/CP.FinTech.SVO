using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using CP.FinTech.SVO.SharedKernel;
using CP.FinTech.SVO.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CP.FinTech.SVO.Infrastructure.Data
{
    // inherit from Ardalis.Specification type
    //public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    //{
    //    public EfRepository(AppDbContext dbContext) : base(dbContext)
    //    {
    //    }
    //}
    public class EfRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(int id) where T : BaseEntity, IAggregateRoot
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public Task<T> GetByIdAsync<T>(int id) where T : BaseEntity, IAggregateRoot
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<T>> ListAsync<T>() where T : BaseEntity, IAggregateRoot
        {
            return _dbContext.Set<T>().ToListAsync();
        }
        

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity, IAggregateRoot
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public Task UpdateAsync<T>(T entity) where T : BaseEntity, IAggregateRoot
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync<T>(T entity) where T : BaseEntity, IAggregateRoot
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : BaseEntity, IAggregateRoot
        {
            var specificationResult = ApplySpecification(spec);
            return specificationResult.ToListAsync();
        }
        public Task<T> GetByIdAsyncInclude<T>(int id, Expression<Func<T, object>> expression ) where T : BaseEntity, IAggregateRoot
        {
            return _dbContext.Set<T>()
                .Include(expression)
                .SingleOrDefaultAsync(e => e.Id == id);
        }
        private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : BaseEntity
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}
