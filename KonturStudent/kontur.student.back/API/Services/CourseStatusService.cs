using System;
using System.Threading.Tasks;
using API.Models;
using API.Services.Interfaces;
using API.Utils;
using KSRepositories.Db;
using Vostok.Logging.Abstractions;

namespace API.Services
{
    internal sealed class CourseStatusService : ICourseStatusService
    {
        private readonly KonturStudentDbContext dbContext;
        private readonly ILog log;
        private const string ServiceName = nameof(CourseStatusService);
        private const string GetCourseStatusMethodName = nameof(GetCourseStatus);
        private const string UpdateCourseStatusMethodName = nameof(UpdateCourseStatus);


        public CourseStatusService(KonturStudentDbContext dbContext, ILog log)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.log = log;
        }

        public Task<CourseStatus> GetCourseStatus()
        {
            log.StartMethodExecution(ServiceName, GetCourseStatusMethodName);
            throw new NotImplementedException();
        }

        public Task<CourseStatus> UpdateCourseStatus(CourseStatus courseStatus)
        {
            log.StartMethodExecution(ServiceName, UpdateCourseStatusMethodName, (nameof(courseStatus), courseStatus));
            throw new NotImplementedException();
        }
    }
}