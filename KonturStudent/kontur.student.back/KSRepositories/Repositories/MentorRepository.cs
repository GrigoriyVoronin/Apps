#region using

using System.Collections.Generic;
using System.Threading.Tasks;
using Kontur.Rest.Filter;
using KSRepositories.Db;
using KSRepositories.DbModels;

#endregion

namespace KSRepositories.Repositories
{
    public class MentorRepository : AbstractRepository<Mentor>
    {
        public MentorRepository(KonturStudentDbContext dbContext)
            : base(dbContext)
        {
        }

        public override Task<List<Mentor>> SearchAsync(IFilter filter, string collectionName = "Mentors")
        {
            return base.SearchAsync(filter, collectionName);
        }
    }
}