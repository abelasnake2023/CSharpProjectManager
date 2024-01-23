using CSharpProjectManager.BusinessLogic;
using CSharpProjectManager.BusinessLogic.BMain;



namespace CSharpProjectManager.UI;



public class ULogIn
{
    public ULogIn()
    {
        
    }

    public static bool AcceptDetail()
    {
        string username = "";
        string password = "";
        bool valid = false;

        while (!valid)
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.Write("Username: ");
            username = Console.ReadLine();

            Console.Write("\n\nPassword: ");
            password = Console.ReadLine();

            string reason;
            valid = BLogIn.ValidUser(username, password, out reason);

            if(!valid)
            {
                Console.WriteLine($"\n{reason}");
                Console.WriteLine("1. Enter again");
                Console.WriteLine("2. Exit");
                char choice = Console.ReadLine().ElementAt(0);

                switch(choice)
                {
                    case '1':
                        break;
                    case '2':
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                ManagerCmd.Username = username; 
                ManagerCmd.Password = password;
                return true;
            }
            Console.Clear();
        }

        return false;
    }
}