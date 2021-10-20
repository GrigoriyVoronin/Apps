#region using

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kontur.Rest.Filter;
using KSRepositories.Db;
using KSRepositories.DbModels;

#endregion

namespace KSRepositories.Repositories
{
    public class ProjectRepository : AbstractRepository<Project>
    {
        public ProjectRepository(KonturStudentDbContext dbContext)
            : base(dbContext)
        {
        }

        public override async Task RemoveAsync(Project project)
        {
            project.IsDeleted = true;
            await UpdateAsync(project);
        }

        public override async Task<List<Project>> SearchAsync(IFilter filter, string collectionName = "Projects")
        {
            var projects = await base.SearchAsync(filter, collectionName);
            return projects
                .Where(p => !p.IsDeleted)
                .ToList();
        }
    }
}