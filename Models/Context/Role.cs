using System;
using System.Collections.Generic;

namespace LeagueClient.Models.Context
{
    public partial class Role
    {
        public Role()
        {
            Champions = new HashSet<Champion>();
        }

        public int RoleId { get; set; }
        public string Position { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; } = null!;

        public virtual ICollection<Champion> Champions { get; set; }
    }
}
