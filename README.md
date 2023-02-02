
## API Reference

#### Get all items

```http
  GET /api/v1
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `requestSession` | `string` | **Required**. Your Session key | 
| `action` | `actionType` | **Required**. Your Action type |

# Action Types
* exampleHTTPRequest
* exampleHTTPLogin
* exampleHTTPRegister

# Example Register API Call using C#

```csharp
        public static void SendRegisterRequest(string username, string password, string email, string sessionToken)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
    {
        { "requestSession", sessionToken },
        { "action", "exampleHTTPRegister" },
        { "username", username },
        { "password", password },
        { "email", email }
    };

            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync("https://v-devs.online/demoHTTPLogin/api/v1/", content).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            dynamic responseJson = JsonConvert.DeserializeObject(responseString);
            Console.WriteLine(responseJson);
        }

```
# ❓ How to generate session token
Here is an example how to generate session token using C#
```csharp
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

```
# ❓ How to destroy session
Here is an example how to destroy session using PHP
```php
                        $destroySession= $conn->prepare("DELETE FROM example_sessions WHERE sessionHash = ?");
                        $destroySession->bind_param("s",$_POST['requestSession']);
                        $destroySession->execute();
```
# ⚠ If you are going to use the sample C# code make sure it is obfuscated otherwise you risk exposing sensitive data from the code 

# ⚠ WARNING : This documentation is not finished yet
