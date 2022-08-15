using System;

namespace OnlineBingoAPI.Contracts
{
    public class PlayerUpdateContract
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public CardUpdateContract Card { get; set; }
    }
}
