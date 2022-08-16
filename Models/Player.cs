using System;

namespace OnlineBingoAPI.Models
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Card Card { get; set; } = new Card();
    }
}
