using LinearSistemas.CanaisVendas.Application.Persistence;
using LinearSistemas.CanaisVendas.Domain.Models.Base;
using LinearSistemas.CanaisVendas.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LinearSistemas.CanaisVendas.Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        public VendasContext Db { get; protected set; }
        public virtual DbSet<TEntity> DbSet { get; protected set; }

        protected Repository(VendasContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task DeleteAsync(int id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public virtual bool DomainExist(int id)
        {
            return DbSet.Count(b => b.Id.Equals(id)) > 0;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await ReturnIQueryable().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await ReturnIQueryable().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await ReturnIQueryable().Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public virtual IQueryable<TEntity> ReturnIQueryable()
        {
            return Db.Set<TEntity>().AsQueryable().AsNoTracking();
        }
    }
}
