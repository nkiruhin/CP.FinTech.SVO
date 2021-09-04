using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CP.FinTech.SVO.SharedKernel.Interfaces
{
    //// from Ardalis.Specification
    //public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    //{
    //}

    // generic methods approach option
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity, IAggregateRoot;
        Task<T> GetByIdAsyncInclude<T>(int id, Expression<Func<T, object>> expression) where T : BaseEntity, IAggregateRoot;
        Task<List<T>> ListAsync<T>() where T : BaseEntity, IAggregateRoot;
        Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : BaseEntity, IAggregateRoot;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task UpdateAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task DeleteAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
    }
}