using OnlineBingoAPI.Types;
using System;
using System.Collections.Generic;

namespace OnlineBingoAPI.Contracts
{
    public class MatchReadContract
    {
        public Guid Id { get; set; }
        public Guid OwnerUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public MatchStatus Status { get; set; }
        public IList<PlayerReadContract> Players { get; set; }
        public IList<int> SelectedNumbers { get; set; }
    }
}
