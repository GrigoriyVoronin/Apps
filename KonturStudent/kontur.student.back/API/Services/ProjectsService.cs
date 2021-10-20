using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services.Interfaces;
using API.Utils;
using Kontur.Rest.Filter;
using KSRepositories.Repositories;
using Vostok.Logging.Abstractions;

namespace API.Services
{
    internal sealed class ProjectsService : IProjectsService
    {
        private readonly ProjectRepository projectRepository;
        private readonly ILog log;
        private const string ServiceName = nameof(ProjectsService);
        private const string FindProjectByIdMethodName = nameof(FindProjectByIdAsync);
        private const string SearchMethodName = nameof(SearchAsync);
        private const string GetAllProjectsMethodName = nameof(GetAllProjectsAsync);
        private const string AddNewProjectMethodName = nameof(AddNewProjectAsync);
        private const string UpdateProjectMethodName = nameof(UpdateProjectAsync);
        private const string RemoveProjectMethodName = nameof(RemoveProjectAsync);


        public ProjectsService(ProjectRepository projectRepository, ILog log)
        {
            this.projectRepository = projectRepository;
            this.log = log;
        }

        public async Task<Project> FindProjectByIdAsync(string id)
        {
            log.StartMethodExecution(ServiceName, FindProjectByIdMethodName, (nameof(id), id));
            var project = await projectRepository.FindByIdAsync(id);
            var apiProject = project == null
                ? null
                : ConvertDbProjectToApi(project);
            log.EndMethodExecution(ServiceName, FindProjectByIdMethodName, apiProject);
            return apiProject;
        }

        public async Task<IEnumerable<Project>> SearchAsync(IFilter? filter)
        {
            log.StartMethodExecution(ServiceName, SearchMethodName, (nameof(filter), filter));
            var searchResult = await projectRepository.SearchAsync(filter);
            var convertedProjects = searchResult.Select(ConvertDbProjectToApi);
            log.EndMethodExecution(ServiceName, SearchMethodName, string.Join(", ", searchResult
                .Select(x =>x.Id)));
            return convertedProjects;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            log.StartMethodExecution(ServiceName, GetAllProjectsMethodName);
            var searchResult = await projectRepository.SearchAsync(null);
            var convertedProjects = searchResult.Select(ConvertDbProjectToApi);
            log.EndMethodExecution(ServiceName, GetAllProjectsMethodName, string.Join(", ", searchResult
                .Select(x => x.Id)));
            return convertedProjects;
        }

        public async Task<Project> AddNewProjectAsync(Project project)
        {
            log.StartMethodExecution(ServiceName, AddNewProjectMethodName, (nameof(project), project));
            var dbProject = ConvertApiProjectToDb(project);
            await projectRepository.AddAsync(dbProject);
            var convertedProject = ConvertDbProjectToApi(dbProject);
            log.EndMethodExecution(ServiceName, AddNewProjectMethodName, convertedProject);
            return convertedProject;
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            log.StartMethodExecution(ServiceName, UpdateProjectMethodName, (nameof(project), project));
            var dbProject = await projectRepository.FindByIdAsync(project.Id);
            UpdateDbProjectFromApi(dbProject, project);
            await projectRepository.UpdateAsync(dbProject);
            var convertedProject = ConvertDbProjectToApi(dbProject);
            log.EndMethodExecution(ServiceName, UpdateProjectMethodName, convertedProject);
            return convertedProject;
        }

        public async Task RemoveProjectAsync(Project project)
        {
            log.StartMethodExecution(ServiceName, RemoveProjectMethodName, (nameof(project), project));
            var dbProject = await projectRepository.FindByIdAsync(project.Id);
            await projectRepository.RemoveAsync(dbProject);
            log.EndMethodExecution(ServiceName, RemoveProjectMethodName, "success");
        }

        public KSRepositories.DbModels.Project ConvertApiProjectToDb(Project project)
        {
            return new()
            {
                Id = project.Id,
                LongDescription = project.LongDescription,
                BeginningDate = project.BeginningDate,
                EndDate = project.EndDate,
                ShortDescription = project.ShortDescription,
                Title = project.Title,
                TechnologyIds = project.TechnologyIds,
                MentorIds = project.MentorIds,
                Results = project.Results
            };
        }

        private void UpdateDbProjectFromApi(KSRepositories.DbModels.Project dbProject, Project project)
        {
            dbProject.Title = project.Title;
            dbProject.ShortDescription = project.ShortDescription;
            dbProject.MentorIds = project.MentorIds;
            dbProject.TechnologyIds = project.TechnologyIds;
            dbProject.BeginningDate = project.BeginningDate;
            dbProject.EndDate = project.EndDate;
            dbProject.LongDescription = project.LongDescription;
            dbProject.Results = project.Results;
        }

        public Project ConvertDbProjectToApi(KSRepositories.DbModels.Project project)
        {
            return new()
            {
                LongDescription = project.LongDescription,
                Id = project.Id,
                BeginningDate = project.BeginningDate,
                EndDate = project.EndDate,
                ShortDescription = project.ShortDescription,
                Title = project.Title,
                TechnologyIds = project.TechnologyIds,
                MentorIds = project.MentorIds,
                Results = project.Results
            };
        }
    }
}