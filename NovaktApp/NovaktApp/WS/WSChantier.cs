﻿using Newtonsoft.Json;
using NovaktApp.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovaktApp.WS
{
    public class WSChantier
    {
        public async Task GetChantiers(string token, Action<IRestResponse> callback)
        {
            var client = new RestClient(String.Format(@"http://{0}/NovaktWS/web/app_dev.php/api", Constant.Constant.IP));
            var request = new RestRequest("/chantier", Method.GET);
            request.AddParameter("token", token);
            request.Timeout = 3000;
            try
            {
                IRestResponse response = await client.ExecuteTaskAsync(request);
                Console.WriteLine("Récupération des chantiers....");
                Console.WriteLine(response.Content);
                callback(response);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        public List<Chantier> JSONToChantier(string json)
        {
            List<Chantier> c = JsonConvert.DeserializeObject<List<Chantier>>(json);
            return c;
        }
    }
}
