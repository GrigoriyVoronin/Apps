#region using

using System.Collections.Generic;

#endregion

namespace API.Models
{
    public class Mentor
    {
        public string Id { get; set; }
        public List<Project> Projects { get; set; }
    }
}