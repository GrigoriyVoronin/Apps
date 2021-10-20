#region using

using System.Collections.Generic;
using System.Threading.Tasks;
using Kontur.Rest.Filter;
using KSRepositories.Db;
using KSRepositories.DbModels;

#endregion

namespace KSRepositories.Repositories
{
    public class TechnologyRepository : AbstractRepository<Technology>
    {
        public TechnologyRepository(KonturStudentDbContext dbContext)
            : base(dbContext)
        {
        }

        public override Task<List<Technology>> SearchAsync(IFilter filter = null, string collectionName = "Technologies")
        {
            return base.SearchAsync(filter, collectionName);
        }
    }
}