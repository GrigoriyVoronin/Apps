#region using

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

#endregion

namespace KSRepositories.DbModels
{
    [PublicAPI]
    public class Technology
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Title { get; set; }

        public byte[] Icon { get; set; }
    }
}