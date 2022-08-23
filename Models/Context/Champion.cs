using System;
using System.Collections.Generic;

namespace LeagueClient.Models.Context
{
    public partial class Champion
    {
        public Champion()
        {
            Abilities = new HashSet<Ability>();
        }

        public int ChampionId { get; set; }
        public int RoleId { get; set; }
        public string ChampionName { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Ability> Abilities { get; set; }
    }
}
