using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Services.Interfaces
{
    public interface ITechnologiesService
    {
        Task<Technology> SaveAsync(Technology technology);

        Task<Technology> GetByIdAsync(string id);

        Task<IReadOnlyCollection<Technology>> GetAllAsync();
    }
}
