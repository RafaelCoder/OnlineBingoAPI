using System;

namespace OnlineBingoAPI.Models
{
    public class User
    {
        public Guid ReferenceId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User()
        {
            ReferenceId = Guid.NewGuid();
            Username = "";
            Email = "";
            Password = "";
        }

    }
}
