﻿using Newtonsoft.Json;
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
            var client = new RestClient(String.Format(@"http://{0}/NovaktWS/web/app_dev.php/api", Constant.Constant.IP));
            var request = new RestRequest("/clients", Method.POST);
            request.AddParameter("token", token);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            string json = JsonConvert.SerializeObject(clients,settings);
            request.AddParameter("clients", json);
            request.AddHeader("Content-type", "application/json");
            request.Timeout = 3000;
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
