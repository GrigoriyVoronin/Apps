using System;

namespace API.Models
{
    public static class CreateProjectRequestExtension
    {
        public static Project ToProject(this CreateProjectRequest createProjectRequest, string id)
        {
            return new()
            {
                Id = id,
                Title = createProjectRequest.Title,
                ShortDescription = createProjectRequest.ShortDescription,
                MentorIds = createProjectRequest.MentorIds,
                TechnologyIds = createProjectRequest.TechnologyIds,
                BeginningDate = createProjectRequest.BeginningDate,
                EndDate = createProjectRequest.EndDate,
                LongDescription = createProjectRequest.LongDescription,
                Results = createProjectRequest.Results
            };
        }
    }
}