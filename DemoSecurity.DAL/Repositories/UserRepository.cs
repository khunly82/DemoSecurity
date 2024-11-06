using DemoSecurity.Domain.Entities;

namespace DemoSecurity.DAL.Repositories
{
    public class UserRepository(DemoSecurityContext context)
    {
        public User? GetByEmail(string email)
        {
            return context.Users.FirstOrDefault(u => email.ToLower() == u.Email.ToLower());
        }

        public int Add(User user)
        {
            User u = context.Users.Add(user).Entity;
            context.SaveChanges();
            return u.Id;
        }
    }
}
