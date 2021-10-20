#region using

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace KSRepositories.DbModels
{
    public class Mentor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
    }
}