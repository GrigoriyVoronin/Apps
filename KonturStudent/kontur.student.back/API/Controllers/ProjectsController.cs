using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Access;
using API.Models;
using API.Services.Interfaces;
using API.Utils;
using Kontur.Rest.Filter;
using KSRepositories.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vostok.Logging.Abstractions;
using Project = API.Models.Project;

namespace API.Controllers
{
    [ApiController]
    [Route("/projects/")]
    [Produces("application/json")]
    public class ProjectsController : Controller
    {
        private readonly IProjectsService projectsService;
        private readonly ILog log;
        private const string ControllerName = nameof(ProjectsController);
        private const string GetProjectMethodName = nameof(GetProject);
        private const string CreateProjectMethodName = nameof(CreateProject);
        private const string UpdateProjectMethodName = nameof(UpdateProject);
        private const string GetProjectsMethodName = nameof(GetProjects);
        private const string DeleteProjectMethodName = nameof(DeleteProject);


        /// <summary>
        ///     ProjectsController constructor, that assign projectsService
        /// </summary>
        /// <param name="projectsService">IProjectsService</param>
        /// <param name="log"></param>
        public ProjectsController(IProjectsService projectsService, ILog log)
        {
            this.projectsService = projectsService ?? throw new ArgumentNullException(nameof(projectsService));
            this.log = log;
        }

        /// <summary>
        ///     Returns project by id
        /// </summary>
        /// <returns>Found project</returns>
        /// <response code="200">Returns project with id</response>
        /// <response code="404">If no project in db</response>
        // GET: /projects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(string id)
        {
            log.RequestInfo(ControllerName, GetProjectMethodName, $"id: {id}");
            var project = await projectsService.FindProjectByIdAsync(id);
            log.ResponseInfo(ControllerName, GetProjectMethodName, project);
            return project != null ? Ok(project) : NotFound();
        }


        // GET: /project-titles?filter=""
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects(string? filter)
        {
            log.RequestInfo(ControllerName, GetProjectsMethodName, $"filter: {filter}");
            var filterParser = new FilterParser();
            var iFilter = string.IsNullOrWhiteSpace(filter) ? null : filterParser.Parse(filter);
            var projects = (await projectsService
                    .SearchAsync(iFilter))
                .ToList();
            log.ResponseInfo(ControllerName, GetProjectsMethodName, string.Join(", ", projects.Select(x => x.Id)));
            return Ok(projects);
        }

        /// <summary>
        ///     Create project
        /// </summary>
        /// <returns>Created project</returns>
        /// <response code="200">Returns created project</response>
        /// <response code="400">if the project ProjectId already exists</response>
        // POST: /projects
        [RoleFilter(Role.Admin)]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(CreateProjectRequest createProjectRequest)
        {
            log.RequestInfo(ControllerName, CreateProjectMethodName, createProjectRequest);
            var newProject = await projectsService.AddNewProjectAsync(createProjectRequest.ToProject(Guid.NewGuid().ToString()));
            log.ResponseInfo(ControllerName, CreateProjectMethodName, newProject);
            return Ok(newProject);
        }

        /// <summary>
        ///     Update project in db
        /// </summary>
        /// <returns>Updated project</returns>
        /// <response code="200">Returns updated project</response>
        /// <response code="404">If project not found in db</response>
        // PUT: /projects/{id}
        [RoleFilter(Role.Admin, Role.Mentor)]
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(string id, UpdateProjectRequest updateProjectRequest)
        {
            log.RequestInfo(ControllerName, UpdateProjectMethodName, $"id: {id}. New value: {updateProjectRequest}");
            var oldProject = await projectsService.FindProjectByIdAsync(id);

            if (oldProject == null)
            {
                log.ResponseInfo(ControllerName, UpdateProjectMethodName, $"id: {id} Not Found");
                return NotFound();
            }

            var updatedProject = await projectsService.UpdateProjectAsync(updateProjectRequest.ToProject(id));
            log.ResponseInfo(ControllerName, UpdateProjectMethodName, updatedProject);
            return Ok(updatedProject);
        }

        /// <summary>
        ///     Delete project from db
        /// </summary>
        /// <returns>Deleted project</returns>
        /// <response code="204">Returns deleted project</response>
        /// <response code="404">If project not found in db</response>
        // DELETE: /project/{id}
        [RoleFilter(Role.Admin)]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            log.RequestInfo(ControllerName, DeleteProjectMethodName, $"id: {id}");
            var project = await projectsService.FindProjectByIdAsync(id);

            if (project == null)
            {
                log.ResponseInfo(ControllerName, DeleteProjectMethodName, $"id: {id} Not Found");
                return NotFound();
            }

            await projectsService.RemoveProjectAsync(project);
            log.ResponseInfo(ControllerName, DeleteProjectMethodName, "success");
            return Ok();
        }
    }
}