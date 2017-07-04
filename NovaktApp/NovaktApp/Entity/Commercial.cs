using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NovaktApp.Entity
{
    public class Commercial
    {
        private int _ID;
        [JsonProperty("login")]
        private string _Login;
        [JsonProperty("password")]
        private string _Password;
        [JsonProperty("token")]
        private string _Token;
        [JsonProperty("clients")]
        private ObservableCollection<Client> _Clients;
        [JsonProperty("id")]
        private int _IDServeur;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public string Login
        {
            get
            {
                return _Login;
            }

            set
            {
                _Login = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        public string Token
        {
            get
            {
                return _Token;
            }

            set
            {
                _Token = value;
            }
        }
        [Ignore]
        public ObservableCollection<Client> Clients
        {
            get
            {
                return _Clients;
            }

            set
            {
                _Clients = value;
            }
        }

        public int IDServeur
        {
            get
            {
                return _IDServeur;
            }

            set
            {
                _IDServeur = value;
            }
        }
    }
}
