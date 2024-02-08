namespace Domain.Entities
{
    public class Profile : BaseEntity
    {
        public Profile(string profileName, string description, string email)
        {
            ProfileName = profileName;
            Description = description;
            Email = email;
        }
        public string ProfileName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
