using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Webshop2021.Logic
{
    public static class ApiHelper
    {
        public static HttpClient Client = new HttpClient();
        public static void init()
        {
            Client.BaseAddress = new Uri("https://localhost:44301/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
