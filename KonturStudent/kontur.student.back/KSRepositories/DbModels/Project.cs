#region using

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

#endregion

namespace KSRepositories.DbModels
{
    [PublicAPI]
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required] 
        public string Title { get; set; }

        [Required] 
        public string ShortDescription { get; set; }

        [Required] 
        public DateTimeOffset? BeginningDate { get; set; }

        [Required] 
        public DateTimeOffset? EndDate { get; set; }

        public string LongDescription { get; set; }

        public bool IsDeleted { get; set; }

        public List<string> MentorIds { get; set; }

        public List<string> TechnologyIds { get; set; }
        
        public string Results { get; set; }
    }
}