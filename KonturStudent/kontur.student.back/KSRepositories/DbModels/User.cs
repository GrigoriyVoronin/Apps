namespace KSRepositories.DbModels
{
    public class User
    {
        public string Id { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}