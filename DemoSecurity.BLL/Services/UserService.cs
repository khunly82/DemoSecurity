using DemoSecurity.BLL.Utils;
using DemoSecurity.DAL.Repositories;
using DemoSecurity.Domain.Entities;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace DemoSecurity.BLL.Services
{
    public class UserService(
        UserRepository userRepository, 
        TokenManager tokenManager
    )
    {
        public string Login(string email, string password)
        {
            User? user = userRepository.GetByEmail(email);
            if(user is null)
            {
                throw new AuthenticationException();
            }
            byte[] hashPassword = SHA512.HashData(Encoding.UTF8.GetBytes(password + user.Email));

            if(!hashPassword.SequenceEqual(user.HashPassword))
            {
                throw new AuthenticationException();
            }
            return tokenManager.CreateToken(user.Id, user.Email, user.Role);
        }

        public int Register(User user, string password)
        {
            byte[] hashPassword = SHA512.HashData(Encoding.UTF8.GetBytes(password + user.Email));
            user.HashPassword = hashPassword;
            return userRepository.Add(user);
        }
    }
}
