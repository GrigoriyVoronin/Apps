using KSRepositories.Db;
using KSRepositories.DbModels;

namespace KSRepositories.Repositories
{
    public class UserRepository : AbstractRepository<User>
    {
        public UserRepository(KonturStudentDbContext dbContext) : base(dbContext)
        {
        }
    }
}