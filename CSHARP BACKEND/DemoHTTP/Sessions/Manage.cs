using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoHTTP.Sessions
{
    internal class Manage
    {
        public static MySqlConnection connection { get; set; }
        public static string server { get; set; }
        public static string database { get; set; }
        public static string user { get; set; }
        public static string password { get; set; }
        public static string port { get; set; }
        public static string connectionString { get; set; }
        public static string sslM { get; set; }
        public static string conString { get; set; }
        public static string session { get; set; }
        public static bool connected { get; set; }
        public static void CreateSession()
        {
            server = "";
            database = "";
            user = "";
            password = "";
            port = "3306";
            sslM = "none";
            connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4};", server, port, user, password, database, sslM);
            conString = connectionString;
            connection = new MySqlConnection(conString);
            try
            {
                connection.Open(); // Open connection
                connected = true;
                var bytes = new byte[32]; // Create new byte
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(bytes);
                    session =Convert.ToBase64String(bytes).Substring(0, 32); // Assign the generated session
                }
                MySqlCommand createSession = new MySqlCommand("INSERT INTO example_sessions(sessionHash) VALUES(@session)", connection); // Prepare the SQL Statement
                createSession.Parameters.AddWithValue("@session", session); // Add session parameter
                createSession.ExecuteScalar(); // Execute command

            }
            catch (MySqlException error)
            {
                Console.WriteLine("There was an error while trying to connect the database ! \r\n Message: " + error.Message);
            }
        }
        public static void DeleteSession(string sessionId)
        {
            if (connected)
            {
                MySqlCommand deleteSession = new MySqlCommand("DELETE FROM example_sessions WHERE sessionHash = @session", connection); // Prepare the SQL Statement
                deleteSession.Parameters.AddWithValue("@session", sessionId); // Add session parameter
                deleteSession.ExecuteScalar(); // Execute command
            }
            else
            {
                Console.WriteLine("You are not connected to the database !");
                Console.WriteLine("Trying to re-connect ...");
                connection.Open();
            }
        }
    }
}
