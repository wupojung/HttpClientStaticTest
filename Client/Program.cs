using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {

        static string token1 = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI5NTQ0IiwianRpIjoiNjRiMDQzNzctODRjZS00MDg0LTg3ZTctYmUwNWYyYjJhZmExIiwibmFtZWlkIjoiOTU0NCIsInJvbGVzIjpbIkFkbWluIiwiVXNlcnMiXSwibmJmIjoxNTg0NDc0Mjk4LCJleHAiOjE1ODQ0NzYwOTgsImlhdCI6MTU4NDQ3NDI5OCwiaXNzIjoiSHR0cENsaWVudERlbW8ifQ.-Jke33IL3n95I7Co7rhWXpi7sP-tyrrZdhT0ujTuwUs";
        static string token2 = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzNjcxIiwianRpIjoiOTVkMWY4YmEtYzY1ZS00MDQxLWJiZTUtMmViOWRmNTFlNTNhIiwibmFtZWlkIjoiMzY3MSIsInJvbGVzIjpbIkFkbWluIiwiVXNlcnMiXSwibmJmIjoxNTg0NDc1NDcxLCJleHAiOjE1ODQ0NzcyNzEsImlhdCI6MTU4NDQ3NTQ3MSwiaXNzIjoiSHR0cENsaWVudERlbW8ifQ.u6vquJRNbPOXIW50X60LogCE-i8VMRGAfCgaCgq_Oac";
        private static HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5000")
        };
        static async Task Main(string[] args)
        {




            await CallByToken(token1);
            await CallByToken(token2);
            await CallByToken(token1);


            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        public static async Task CallByToken(string token)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage response = await httpClient.GetAsync("/api/token/check");
            var msg = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"t1=>:{msg}");
          
        }
    }
}
