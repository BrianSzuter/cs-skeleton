using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        private static void Main(string[] args)
        {
            RunAsync().Wait(5 * 60 * 1000);

            Console.ReadKey();

            return;
        }

        private static async Task RunAsync()
        {
            if (Debugger.IsAttached)
            {
                // If debugging, give the service time to start up. 
                await Task.Delay(10 * 1000);
            }

            Uri baseUrl = new Uri("http://localhost:10577/");

            HttpClient client = new HttpClient()
            {
                BaseAddress = baseUrl,
                Timeout = TimeSpan.FromSeconds(30),
            };

            var response = await client.GetAsync("api/values");

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
