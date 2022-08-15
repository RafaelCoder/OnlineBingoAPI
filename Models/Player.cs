using System;

namespace OnlineBingoAPI.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Card Card { get; set; }
    }
}
