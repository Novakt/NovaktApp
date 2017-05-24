using System;
using System.Collections.Generic;
using System.Text;

namespace NovaktApp.Entity
{
    public class Produit
    {
        private int _ID;
        private string _Reference;
        private string _Nom;
        private string _Type;
        private string _Description;
        private string _LienImage;
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

        public string Reference
        {
            get
            {
                return _Reference;
            }

            set
            {
                _Reference = value;
            }
        }

        public string Nom
        {
            get
            {
                return _Nom;
            }

            set
            {
                _Nom = value;
            }
        }

        public string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = value;
            }
        }

        public string LienImage
        {
            get
            {
                return _LienImage;
            }

            set
            {
                _LienImage = value;
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
