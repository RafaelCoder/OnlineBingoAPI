using System;

namespace OnlineBingoAPI.Contracts
{
    public class PlayerReadContract
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public CardReadContract Card { get; set; }
    }
}
