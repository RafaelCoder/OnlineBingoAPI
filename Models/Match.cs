using System;
using System.Collections.Generic;
using OnlineBingoAPI.Types;

namespace OnlineBingoAPI.Models
{
    public class Match
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OwnerUserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public MatchStatus Status { get; set; } = MatchStatus.Created;
        public IList<Player> Players { get; set; } = new List<Player>();
        public IList<int> SelectedNumbers { get; set; } = new List<int>();

    }
}
