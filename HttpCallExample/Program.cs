using Newtonsoft.Json;
using System.Text;

namespace HttpCallExample
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            #region HttpGet

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://fakestoreapi.com/users");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(json);
                foreach (User user in users)
                {
                    Console.WriteLine($"User ID: {user.Id}");
                    Console.WriteLine($"Username: {user.Username}");
                    Console.WriteLine($"Email: {user.Email}");
                    Console.WriteLine($"Name: {user.Name.Firstname} {user.Name.Lastname}");
                    Console.WriteLine($"Phone: {user.Phone}");
                    Console.WriteLine($"Address: {user.Address.Street}, {user.Address.City}, {user.Address.Zipcode}");
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("Failed to fetch data. Status code: " + response.StatusCode);
            }
            #endregion

            #region Post
            // Create a new user object
            User newUser = new User
            {
                Id = 11,
                Email = "newuser@example.com",
                Username = "newuser123",
                Password = "password123",
                Name = new Name { Firstname = "New", Lastname = "User" },
                Phone = "123-456-7890",
                Address = new Address
                {
                    Geolocation = new Geolocation { Lat = "0", Long = "0" },
                    City = "New City",
                    Street = "New Street",
                    Number = 123,
                    Zipcode = "12345"
                },
                __v = 0
            };


            // Serialize the user object to JSON
            string json2 = JsonConvert.SerializeObject(newUser);
            HttpResponseMessage response2 = await client.PostAsync(
                "https://fakestoreapi.com/users",
                new StringContent(json2, Encoding.UTF8,
                "application/json"));

            if (response2.IsSuccessStatusCode)
            {
                Console.WriteLine("User created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create user. Status code: " + response.StatusCode);
            }
            #endregion
        }
    }


    class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Name Name { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public int __v { get; set; }
    }

    class Name
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    class Address
    {
        public Geolocation Geolocation { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Zipcode { get; set; }
    }

    class Geolocation
    {
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}

