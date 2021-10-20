#region using

using System.Collections.Generic;

#endregion

namespace API.Models
{
    public class Technology
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public byte[] Icon { get; set; }
    }
}