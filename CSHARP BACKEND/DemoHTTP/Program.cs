namespace DemoHTTP
{
    internal class Program
    {
        public static string regUsername { get; set; }
        public static string regEmail { get; set; }
        public static string regPassword { get; set; }
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("[1] Register");
            Console.WriteLine("[2] Login");
            Console.WriteLine("[3] Example HTTP Request");

            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                bool validUsername = false;
                while (!validUsername)
                {
                    Console.Write("> Username : ");
                    var userName = Console.ReadLine();
                    if (userName.Length >= 4)
                    {
                        validUsername = true;
                        regUsername = userName;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Username !");
                    }
                }
                bool validPassword = false;
                while (!validPassword)
                {
                    Console.Write("> Password : ");
                    var password = Console.ReadLine();
                    if (password.Length >= 4)
                    {
                        validPassword = true;
                        regPassword = password;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Password !");
                    }
                }
                Console.WriteLine();
                bool validEmail = false;
                while (!validEmail)
                {
                    Console.Write("> Email : ");
                    var email = Console.ReadLine();
                    if (email.Length > 4 && email.Contains("@"))
                    {
                        validEmail = true;
                        regEmail = email;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Email !");
                    }
                }
                Sessions.Manage.CreateSession();
                HTTPRequests.Engine.SendRegisterRequest(regUsername, regPassword, regEmail, Sessions.Manage.session); // Send the request
            }
            else if(option == 2)
            {
                Console.Write("Username: ");
                var username = Console.ReadLine();
                Console.Clear();
                Console.Write("Password: ");
                var password = Console.ReadLine();
                Sessions.Manage.CreateSession();
                HTTPRequests.Engine.SendLoginRequest(username, password, Sessions.Manage.session); // Send the request
            }
            else if(option == 3)
            {
                HTTPRequests.Engine.SendExampleHTTPRequest(); // Send the request
            }
        }
    }
}
