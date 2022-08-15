using System;
using OnlineBingoAPI.Types;
using System.Collections.Generic;

namespace OnlineBingoAPI.Contracts
{
    public class MatchUpdateContract
    {
        public Guid Id { get; set; }
        public Guid OwnerUserId { get; set; }
        public MatchStatus Status { get; set; }
        public IList<PlayerUpdateContract> Players { get; set; }
        public IList<int> SelectedNumbers { get; set; }
    }
}
