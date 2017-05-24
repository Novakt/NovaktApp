using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NovaktApp.Entity
{
    public class Commercial
    {
        private int _ID;
        private int _Login;
        private string _Password;
        private string _Token;
        private ObservableCollection<Client> _Clients;
        private int _IDServeur;

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

        public int Login
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
