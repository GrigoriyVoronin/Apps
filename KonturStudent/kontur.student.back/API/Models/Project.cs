﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Project
    {

        [Required]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public List<string> MentorIds { get; set; }

        public List<string> TechnologyIds { get; set; }

        [Required]
        public DateTimeOffset? BeginningDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string LongDescription { get; set; }

        public string Results { get; set; }
    }
}