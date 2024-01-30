namespace ForgetMeNot.Api.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string HashedPassword { get; set; } = null!;
        public bool IsEmailConfirmed { get; set; }
        public string Role { get; set; } = null!;
        public List<UserPreference> Preferences { get; set; } = null!;
    }
}
