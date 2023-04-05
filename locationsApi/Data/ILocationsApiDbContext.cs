using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data
{
    public interface ILocationsApiDbContext
    {
        DbSet<Location>? Locations { get; set; }
        DbSet<Schedule>? Schedules { get; set; }

        bool Equals(object obj);
        int GetHashCode();
        string ToString();

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
        ValueTask DisposeAsync();

        EntityEntry Add(object entity);

        ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken);

        EntityEntry Update(object entity);

        EntityEntry Remove(object entity);
        void AddRange(params object[] entities);
        void AddRange(IEnumerable<object> entities);
        Task AddRangeAsync(params object[] entities);
        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
