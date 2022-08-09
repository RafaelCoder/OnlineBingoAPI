using System;

namespace OnlineBingoAPI.Contracts
{
    public class UserReadContract
    {
        public Guid ReferenceId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
