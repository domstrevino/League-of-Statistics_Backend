using System;
using System.Collections.Generic;

namespace LeagueClient.Models
{
    public partial class Ability
    {
        public int AbilityId { get; set; }
        public int ChampionId { get; set; }
        public string Q { get; set; } = null!;
        public string W { get; set; } = null!;
        public string E { get; set; } = null!;
        public string R { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual Champion Champion { get; set; } = null!;
    }
}
