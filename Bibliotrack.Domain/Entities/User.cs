namespace Bibliotrack.Domain.Entities
{
    public class User : BaseEntity
    {
        protected User() { }
        public User(string email, string password)
            : base()
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }

        public void Update(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
