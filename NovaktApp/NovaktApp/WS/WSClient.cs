using Newtonsoft.Json;
using NovaktApp.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovaktApp.WS
{
    public class WSClient
    {
        public async Task PostClients(string token,List<Client> clients, Action<IRestResponse> callback)
        {
            var client = new RestClient("http://192.168.1.39/NovaktWS/web/app_dev.php/api");
            var request = new RestRequest("/clients", Method.POST);
            request.AddParameter("token", token);
            string json = JsonConvert.SerializeObject(clients);
            request.AddParameter("clients", json);
            request.AddHeader("Content-type", "application/json");
            try
            {
                IRestResponse response = await client.ExecuteTaskAsync(request);
                Console.WriteLine("Synchronisation des clients....");
                Console.WriteLine(response.Content);
                callback(response);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }
        public List<Client> JSONToListClients(string json)
        {
            List<Client> c = JsonConvert.DeserializeObject<List<Client>>(json);
            return c;
        }
    }
}
