using System;
using System.Threading.Tasks;
using API.Access;
using API.Models;
using API.Services.Interfaces;
using API.Utils;
using KSRepositories.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vostok.Logging.Abstractions;

namespace API.Controllers
{
    [ApiController]
    [Route("/course-status/")]
    [Produces("application/json")]
    public class CourseStatusController : Controller
    {
        
        private readonly ICourseStatusService statusService;
        private readonly ILog log;
        private const string ControllerName = nameof(CourseStatusController);
        private const string GetStatusMethodName = nameof(GetStatus);
        private const string UpdateStatusMethodName = nameof(UpdateStatus);

        /// <summary>
        ///     ProjectsController constructor, that assign projectsService
        /// </summary>
        /// <param name="statusService"></param>
        /// <param name="log"></param>
        public CourseStatusController(ICourseStatusService statusService, ILog log)
        {
            this.statusService = statusService ?? throw new ArgumentNullException(nameof(statusService));
            this.log = log;
        }
        
        /// <summary>
        ///     Returns status
        /// </summary>
        /// <returns>Status</returns>
        /// <response code="200">Returns Status</response>
        // GET: /status/
        [HttpGet]
        public async Task<ActionResult<bool>> GetStatus()
        {
            log.RequestInfo(ControllerName, GetStatusMethodName);
            var courseStatus = await statusService.GetCourseStatus();
            log.ResponseInfo(ControllerName, GetStatusMethodName, courseStatus.IsInProgress);
            return Ok(courseStatus.IsInProgress);
        }
        
        /// <summary>
        ///     Update status
        /// </summary>
        /// <returns>Status</returns>
        /// <response code="200">Status updated</response>
        // PUT: /status/{isInProgress}
        [RoleFilter(Role.Admin)]
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateStatus(bool isInProgress)
        {
            log.RequestInfo(ControllerName, UpdateStatusMethodName, isInProgress);
            var courseStatus = await statusService.UpdateCourseStatus(new CourseStatus{IsInProgress = isInProgress});
            log.ResponseInfo(ControllerName, UpdateStatusMethodName, courseStatus.IsInProgress);
            return Ok(courseStatus.IsInProgress);

        }
    }
}