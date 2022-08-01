using System;
using System.Collections.Generic;

namespace OnlineBingoAPI.Models
{
    public enum MatchStatus
    {
        Created = 1,
        InProgress = 2,
        Finished = 3,
        Cancelled = 4
    }

    public class Match
    {
        public Guid ReferenceId { get; set; }
        public Guid OwnerReferenceId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public MatchStatus Status { get; set; }
        public IList<Player> Players { get; set; } = new List<Player>();
        public IList<int> SelectedNumbers { get; set; }

    }
}
