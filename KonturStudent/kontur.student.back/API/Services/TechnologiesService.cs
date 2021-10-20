using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services.Interfaces;
using API.Utils;
using KSRepositories.Repositories;
using Vostok.Logging.Abstractions;

namespace API.Services
{
    public sealed class TechnologiesService: ITechnologiesService
    {
        private readonly TechnologyRepository repository;
        private readonly ILog log;
        private const string ServiceName = nameof(TechnologiesService);
        private const string SaveMethodName = nameof(SaveAsync);
        private const string GetByIdMethodName = nameof(GetByIdAsync);
        private const string GetAllMethodName = nameof(GetAllMethodName);

        public TechnologiesService(TechnologyRepository repository, ILog log)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.log = log;
        }

        public async Task<Technology> SaveAsync(Technology technology)
        {
            log.StartMethodExecution(ServiceName, SaveMethodName, (nameof(technology), technology));
            if (await repository.FindByIdAsync(technology.Id) == null)
            {
                var addedTechnology = await repository.AddAsync(new KSRepositories.DbModels.Technology
                {
                    Id = technology.Id,
                    Title = technology.Title,
                    Icon = technology.Icon
                });
                log.EndMethodExecution(ServiceName, SaveMethodName, $"Add technology: {addedTechnology}");
                return technology;
            }

            var updateTechnology = await repository.UpdateAsync(new KSRepositories.DbModels.Technology
            {
                Id = technology.Id,
                Icon = technology.Icon,
                Title = technology.Title
            });

            log.EndMethodExecution(ServiceName, SaveMethodName, $"Update technology: {updateTechnology}");
            return technology;
        }

        public async Task<Technology> GetByIdAsync(string id)
        {
            log.StartMethodExecution(ServiceName, GetByIdMethodName, (nameof(id), id));
            var dbTechnology = await repository.FindByIdAsync(id);

            if (dbTechnology == null)
            {
                log.EndMethodExecution(ServiceName, GetByIdMethodName, $"Id = {id} Not Found");
                throw new KeyNotFoundException($"Technology with id '{id}' not found");
            }

            var technology = new Technology
            {
                Id = dbTechnology.Id,
                Icon = dbTechnology.Icon,
                Title = dbTechnology.Title
            };
            log.EndMethodExecution(ServiceName, GetByIdMethodName, technology);
            return technology;
        }

        public async Task<IReadOnlyCollection<Technology>> GetAllAsync()
        {
            log.StartMethodExecution(ServiceName, GetAllMethodName);
            var technologies = await repository.SearchAsync();

            var convertedTechnologies = technologies
                .Select(t => new Technology
                {
                    Id = t.Id,
                    Title = t.Title,
                    Icon = t.Icon

                })
                .ToList()
                .AsReadOnly();
            log.EndMethodExecution(ServiceName, GetAllMethodName, string.Join(", ", convertedTechnologies.Select(x => x.Id)));
            return convertedTechnologies;
        }
    }
}
