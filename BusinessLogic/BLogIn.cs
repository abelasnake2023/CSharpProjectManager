using CSharpProjectManager.Database;

namespace CSharpProjectManager.BusinessLogic
{
    public class BLogIn
    {
        public BLogIn()
        {

        }

        public static bool ValidUser(string username, string password, out string reason)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                reason = "Enter your username and password first!";
                return false;
            }
            else if (string.IsNullOrEmpty(username))
            {
                reason = "Enter Your username, username is must!";
                return false;
            }
            else if (string.IsNullOrEmpty(password))
            {
                reason = "Enter your password, password is must!";
                return false;
            }

            bool valid = DLogIn.ValidUser(username, password, out reason);

            return valid;
        }
    }
}