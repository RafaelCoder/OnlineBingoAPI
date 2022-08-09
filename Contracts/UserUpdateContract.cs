using System;

namespace OnlineBingoAPI.Contracts
{
    public class UserUpdateContract
    {
        public Guid ReferenceId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
