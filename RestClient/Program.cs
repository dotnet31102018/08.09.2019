using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    class Program
    {
        // NUGET -- Microsoft.AspNet.WebApi.Client

        public class Todo
        {
            public int userId;
            public int id;
            public string title;
            public bool completed;
        }

        private const string URL = "https://jsonplaceholder.typicode.com/todos/1";

         static void Main(string[] args)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            // -------------------------- One item
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<Todo>().Result;
                Console.Write("{0} ", dataObjects.id);
                Console.Write("{0} ", dataObjects.userId);
                Console.Write("{0} ", dataObjects.title);
                Console.WriteLine("{0}", dataObjects.completed);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
               /*

            // --------------------------- List
            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Todo>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    Console.Write("{0} ", d.id);
                    Console.Write("{0} ", d.userId);
                    Console.Write("{0} ", d.title);
                    Console.WriteLine("{0}", d.completed);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            */
            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
    }
}
