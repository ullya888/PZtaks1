namespace TradingCompany.BL
{
    public interface IUserSession
    {
        string CurrentUser { get; }
        bool IsAdmin { get; }
        void SignIn(string username, bool isAdmin);
        void SignOut();
    }

    public class UserSession : IUserSession
    {
        public string CurrentUser { get; private set; }
        public bool IsAdmin { get; private set; }

        public void SignIn(string username, bool isAdmin)
        {
            CurrentUser = username;
            IsAdmin = isAdmin;
        }

        public void SignOut()
        {
            CurrentUser = null;
            IsAdmin = false;
        }
    }
}