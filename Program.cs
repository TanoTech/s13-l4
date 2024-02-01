namespace _Exercise04
{
    static class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Logout");
                Console.WriteLine("3: Check last login");
                Console.WriteLine("4: Exit");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        LoginManager.LoginUser();
                        break;

                    case "2":
                        LoginManager.Logout();
                        break;

                    case "3":
                        LoginManager.PrintLogin();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }

    static class LoginManager
    {
        static User currentUser = null;
        static string Username = "Gaetano";
        static string Password = "ciao123";

        public static void LoginUser()
        {
            if (currentUser != null)
            {
                Console.WriteLine("User already logged in.");
                return;
            }

            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.Write("Confirm password: ");
            string confirmPassword = Console.ReadLine();

            if (password != confirmPassword)
            {
                Console.WriteLine("Passwords incorrect");
                return;
            }

            if (username == Username && password == Password)
            {
                currentUser = new User(username);
                Console.WriteLine($"Logged in. Hello {username}.");
            }
            else
            {
                Console.WriteLine("Error, please try again.");
            }
        }

        public static void Logout()
        {
            if (currentUser == null)
            {
                Console.WriteLine("No user logged in.");
                return;
            }

            currentUser = null;
            Console.WriteLine("Logged out successfully.");
        }

        public static void PrintLogin()
        {
            if (currentUser == null)
            {
                Console.WriteLine("No user logged in.");
                return;
            }

            Console.WriteLine($"Last login: {currentUser.LastLogin}");
        }
    }

    public class User
    {
        public string Username { get; private set; }
        private List<string> Logins { get; set; }

        public User(string username)
        {
            Username = username;
            Logins = new List<string> { DateTime.Now.ToString() };
        }

        public string LastLogin
        {
            get
            {
                return Logins.Last();
            }
        }
    }
}
