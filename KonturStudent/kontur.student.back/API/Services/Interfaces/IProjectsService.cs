using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Kontur.Rest.Filter;

namespace API.Services.Interfaces
{
    public interface IProjectsService
    {
        public Task<Project> FindProjectByIdAsync(string id);

        public Task<IEnumerable<Project>> SearchAsync(IFilter? filter);

        public Task<IEnumerable<Project>> GetAllProjectsAsync();

        public Task<Project> AddNewProjectAsync(Project project);

        public Task<Project> UpdateProjectAsync(Project project);

        public Task RemoveProjectAsync(Project project);
    }
}