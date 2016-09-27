using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookARoom.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:60416/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            GetValue(client).Wait();

            Console.ReadKey();
        }

        private static async Task GetValue(HttpClient client)
        {
            try
            {
                // TODO: call real api when it exists
                var response = await client.GetAsync("api/values/2");
                if (response.IsSuccessStatusCode)
                {
                    var stuff = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(stuff);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
