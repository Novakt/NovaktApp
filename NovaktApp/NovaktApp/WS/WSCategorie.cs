﻿using Newtonsoft.Json;
using NovaktApp.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovaktApp.WS
{
    public class WSCategorie
    {
        public async Task GetCategories(string token, Action<IRestResponse> callback)
        {
            var client = new RestClient(String.Format(@"http://{0}/NovaktWS/web/app_dev.php/api",Constant.Constant.IP));
            var request = new RestRequest("/categorie", Method.GET);
            request.AddParameter("token", token);
            request.Timeout = 3000;
            try
            {
                IRestResponse response = await client.ExecuteTaskAsync(request);
                Console.WriteLine("Récupération des categories....");
                Console.WriteLine(response.Content);
                callback(response);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        public List<Categorie> JSONToCategorie(string json)
        {
            List<Categorie> c = JsonConvert.DeserializeObject<List<Categorie>>(json);
            return c;
        }
    }
}
