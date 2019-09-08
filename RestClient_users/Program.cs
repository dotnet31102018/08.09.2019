﻿using System;
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

        public class WebResult
        {
            public WebUser[] results;

        }

        public class WebUser
        {
            public string gender;
            public Name name;
        }
        public class Name
        {
            public string title;
            public string first;
            public string last;
        }

        private const string URL = "https://randomuser.me/api";

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
                WebResult dataObjects = response.Content.ReadAsAsync<WebResult>().Result;
                Console.WriteLine("{0} ", dataObjects.results[0].gender);
                Console.WriteLine("{0} ", dataObjects.results[0].name.title);
                Console.WriteLine("{0} ", dataObjects.results[0].name.first);
                Console.WriteLine("{0} ", dataObjects.results[0].name.last);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
    }
}
