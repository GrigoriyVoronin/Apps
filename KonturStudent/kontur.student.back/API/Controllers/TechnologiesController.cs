using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Access;
using API.Services.Interfaces;
using API.Utils;
using KSRepositories.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vostok.Logging.Abstractions;
using Technology = API.Models.Technology;

namespace API.Controllers
{
    [ApiController]
    [Route("technologies")]
    [Produces("application/json")]
    public sealed class TechnologiesController: Controller
    {
        private readonly ITechnologiesService technologiesService;
        private readonly ILog log;
        private const string ControllerName = nameof(TechnologiesController);
        private const string GetMethodName = nameof(GetAsync);
        private const string CreateMethodName = nameof(CreateAsync);

        public TechnologiesController(ITechnologiesService technologiesService, ILog log)
        {
            this.technologiesService = technologiesService ?? throw new ArgumentNullException(nameof(technologiesService));
            this.log = log;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Technology>>> GetAsync()
        {
            log.RequestInfo(ControllerName, GetMethodName);
            var technologies = await technologiesService.GetAllAsync();
            log.ResponseInfo(ControllerName, GetMethodName, string.Join(", ", technologies.Select(x => x.Id)));
            return Ok(technologies);
        }

        [RoleFilter(Role.Mentor, Role.Admin)]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Technology>> CreateAsync(CreateTechnologyRequest request)
        {
            log.RequestInfo(ControllerName, CreateMethodName, request);
            var technology = await technologiesService.SaveAsync(new Technology
            {
                Id = request.Id,
                Title = request.Title,
                Icon = request.Icon
            });
            log.ResponseInfo(ControllerName, CreateMethodName, technology);
            return Ok(technology);
        }
    }
}
