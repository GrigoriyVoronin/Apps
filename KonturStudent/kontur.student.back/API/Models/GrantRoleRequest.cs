using KSRepositories.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class GrantRoleRequest
    {
        public string Id { get; set; }
        public Role Role { get; set; }
    }
}
