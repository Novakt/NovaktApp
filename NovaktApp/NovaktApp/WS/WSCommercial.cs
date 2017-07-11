using Newtonsoft.Json;
using NovaktApp.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovaktApp.WS
{
    public class WSCommercial
    {
        public async Task Login(string username,string password, Action<IRestResponse> callback)
        {
            var client = new RestClient(String.Format(@"http://{0}/NovaktWS/web/app_dev.php/api", Constant.Constant.IP));
            var request = new RestRequest("/logins", Method.POST);
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.Timeout = 3000;
            try
            {
                IRestResponse response = await client.ExecuteTaskAsync(request);
                Console.WriteLine("Login....");
                Console.WriteLine(response.Content);
                callback(response);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        public Commercial JSONToCommercial(string json)
        {
            Commercial c = JsonConvert.DeserializeObject<Commercial>(json);
            return c;
        }
    }
}
