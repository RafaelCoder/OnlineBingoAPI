using System;

namespace OnlineBingoAPI.Models
{
    public class Player
    {
        public Guid ReferenceId { get; set; }
        public Guid UserReferenceId { get; set; }
        public Card Card { get; set; }
    }
}
