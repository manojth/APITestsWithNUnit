using RestSharp;
using System;

namespace ReqResApiTests_NUnit.Clients
{
    public class BaseApiClient
    {
        protected RestClient Client;

        public BaseApiClient()
        {
            var options = new RestClientOptions("https://reqres.in/")
            {
                ThrowOnAnyError = false,
                MaxTimeout = 5000 // Set timeout here instead of on RestClient
            };
            Client = new RestClient(options);
        }

        protected RestRequest CreateRequest(string endpoint, Method method)
        {
            var request = new RestRequest(endpoint, method);
            request.AddHeader("Content-Type", "application/json");
            return request;
        }
    }
}
