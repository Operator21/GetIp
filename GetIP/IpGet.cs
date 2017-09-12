using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIP
{
    class IpGet
    {
        public async Task<List<IP>> GetCurrentIP()
        {
            string url = "https://stackoverflow.com/questions/15683858/restsharp-print-raw-request-and-response-headers";
            var client = new RestClient(url);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("resource/{id}", Method.POST);
            // request.AddParameter("error", "1"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            request.AddHeader("header", "value");

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            IParser parser = new JsonParser();
            await parser.ParseString<List<IP>>(response.Content);
            return null;

        }
    }
}
