using System;

namespace OnlineBingoAPI.Contracts
{
    public class UserReadContract
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
