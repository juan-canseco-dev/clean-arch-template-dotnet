
using CleanArchTemplate.Domain.Common;

namespace CleanArchTemplate.Application.Common.Interfaces;

public interface IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    // Comment Get By Specification ME
    /*
    Task<TEntity?> GetBySpecificationAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllBySpecificationAsync(ISpecification<TEntity>? specification = null, CancellationToken cancellationToken = default);
    Task<int> CountBySepecificationAsync(ISpecification<TEntity>? specifcation = null, CancellationToken cancellationToken = default);
    Task<bool> ExistsBySpecificationAsync(ISpecification<TEntity> specifcation, CancellationToken cancellationToken = default);*/ 
    void Add(TEntity entity, CancellationToken cancellationToken = default);
    void Edit(TEntity entity);
    void Remove(TEntity entity);
}
