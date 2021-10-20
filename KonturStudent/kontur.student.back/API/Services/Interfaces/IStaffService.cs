using System.Collections.Generic;
using SkbKontur.Staff.Integration;

namespace API.Services.Interfaces
{
    public interface IStaffService
    {
        public StaffUser FindStaffUserById(int id);

        public StaffGroup FindStaffGroupById(int id);

        public IEnumerable<StaffUser> GetAllStaffUsers();

        public IEnumerable<StaffGroup> GetAllStaffProjects();

        public IEnumerable<StaffGroup> GetAllCommunities();

        public IEnumerable<StaffGroup> GetAllDistributionGroups();

        public IEnumerable<StaffGroup> GetAllEvents();
    }
}