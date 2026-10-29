using TradingCompany.DAL.Interfaces;

namespace TradingCompany.BL
{
    public interface IAuthService
    {
        bool Login(string login, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Login(string login, string password)
        {
           
            var user = _userRepository.GetByLogin(login);

            
            if (user == null || user.PasswordHash != password)
            {
                return false;
            }

            return true;
        }
    }
}