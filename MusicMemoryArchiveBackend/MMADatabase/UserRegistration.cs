using MMADatabase;

namespace MusicMemoryArchiveBackend
{
    public class UserRegistration : UserClass
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
