using System.Threading.Tasks;
using API.Models;

namespace API.Services.Interfaces
{
    public interface ICourseStatusService
    {
        public Task<CourseStatus> GetCourseStatus();
        public Task<CourseStatus> UpdateCourseStatus(CourseStatus courseStatus);
    }
}