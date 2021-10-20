#region using

using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Kontur.Rest.Filter;
using KSRepositories.Db;
using Microsoft.EntityFrameworkCore;

#endregion

namespace KSRepositories.Repositories
{
    public abstract class AbstractRepository<T>
        where T : class
    {
        protected readonly KonturStudentDbContext DbContext;

        protected AbstractRepository(KonturStudentDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [ItemNotNull]
        public virtual async Task<T> AddAsync([NotNull] T entity)
        {
            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        [ItemCanBeNull]
        public virtual async Task<T> FindByIdAsync([NotNull] string id)
        {
            return await DbContext.FindAsync<T>(id);
        }

        public virtual async Task RemoveAsync([NotNull] T entity)
        {
            DbContext.Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task<List<T>> SearchAsync([CanBeNull] IFilter filter, [CanBeNull] string collectionName)
        {
            if (filter == null || collectionName == null)
                return await DbContext
                    .Set<T>()
                    .ToListAsync();


            var sql = $"select * from \"{collectionName}\" \n" +
                      $"where {filter.ToNpgSqlString()}";
            return await DbContext
                .Set<T>()
                .FromSqlRaw(sql)
                .ToListAsync();
        }

        [ItemNotNull]
        public virtual async Task<T> UpdateAsync([NotNull] T entity)
        {
            DbContext.Update(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
    }
}