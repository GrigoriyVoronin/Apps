using System;
using System.Collections.Generic;
using API.Services.Interfaces;
using API.Utils;
using SkbKontur.Staff.Integration;
using SkbKontur.Staff.Integration.Client;
using Vostok.Logging.Abstractions;

namespace API.Services
{
    internal sealed class StaffService : IStaffService, IDisposable
    {
        private readonly IStaffClientContext staffClient;
        private readonly ILog log;
        private const string ServiceName = nameof(StaffService);
        private const string FindStaffUserByIdMethodName = nameof(FindStaffUserById);
        private const string FindStaffGroupByIdMethodName = nameof(FindStaffGroupById);
        private const string GetAllStaffUsersMethodName = nameof(GetAllStaffUsers);
        private const string GetAllStaffProjectsMethodName = nameof(GetAllStaffProjects);
        private const string GetAllCommunitiesMethodName = nameof(GetAllCommunities);
        private const string GetAllDistributionGroupsMethodName = nameof(GetAllDistributionGroups);
        private const string GetAllEventsMethodName = nameof(GetAllEvents);

        public StaffService(IStaffClientContext staffClient, ILog log)
        {
            this.staffClient = staffClient;
            this.log = log;
        }

        public void Dispose()
        {
            staffClient?.Dispose();
        }

        public StaffUser FindStaffUserById(int id)
        {
            log.StartMethodExecution(ServiceName, FindStaffUserByIdMethodName, (nameof(id), id));
            var user = GetFromStaff(() => staffClient.Users.GetById(id));
            log.EndMethodExecution(ServiceName, FindStaffUserByIdMethodName, user);
            return user;
        }

        public StaffGroup FindStaffGroupById(int id)
        {
            log.StartMethodExecution(ServiceName, FindStaffGroupByIdMethodName, (nameof(id), id));
            var group = GetFromStaff(() => staffClient.Groups.GetById(id));
            log.EndMethodExecution(ServiceName, FindStaffGroupByIdMethodName, group);
            return group;
        }

        public IEnumerable<StaffUser> GetAllStaffUsers()
        {
            log.StartMethodExecution(ServiceName, GetAllStaffUsersMethodName);
            var users = GetFromStaff(() => staffClient.Users.GetAll());
            log.EndMethodExecution(ServiceName, GetAllStaffUsersMethodName, "success");
            return users;
        }

        public IEnumerable<StaffGroup> GetAllStaffProjects()
        {
            log.StartMethodExecution(ServiceName, GetAllStaffProjectsMethodName);
            var groups = GetFromStaff(() => staffClient.Groups.GetAll(StaffGroupTypes.Project));
            log.EndMethodExecution(ServiceName, GetAllStaffProjectsMethodName, "success");
            return groups;
        }

        public IEnumerable<StaffGroup> GetAllCommunities()
        {
            log.StartMethodExecution(ServiceName, GetAllCommunitiesMethodName);
            var groups = GetFromStaff(() => staffClient.Groups.GetAll(StaffGroupTypes.Community));
            log.EndMethodExecution(ServiceName, GetAllCommunitiesMethodName, "success");
            return groups;
        }

        public IEnumerable<StaffGroup> GetAllDistributionGroups()
        {
            log.StartMethodExecution(ServiceName, GetAllDistributionGroupsMethodName);
            var groups = GetFromStaff(() => staffClient.Groups.GetAll(StaffGroupTypes.DistributionGroup));
            log.EndMethodExecution(ServiceName, GetAllDistributionGroupsMethodName, "success");
            return groups;
        }

        public IEnumerable<StaffGroup> GetAllEvents()
        {
            log.StartMethodExecution(ServiceName, GetAllEventsMethodName);
            var groups = GetFromStaff(() => staffClient.Groups.GetAll(StaffGroupTypes.Event));
            log.EndMethodExecution(ServiceName, GetAllEventsMethodName, "success");
            return groups;
        }

        private T GetFromStaff<T>(Func<T> func)
        {
            try
            {
                return func.Invoke();
            }
            catch (InvalidStaffResponseException ex)
            {
                log.Error(ex);
            }
            catch (AggregateException ex)
            {
                log.Error(ex);
            }

            return default;
        }
    }
}