using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovaktApp.Entity
{
    public class Produit
    {
        private int _ID;
        [JsonProperty("reference")]
        private string _Reference;
        [JsonProperty("nom")]
        private string _Nom;
        [JsonProperty("type")]
        private string _Type;
        [JsonProperty("description")]
        private string _Description;
        [JsonProperty("puissance_calorifique_chaud")]
        private int _PuissanceCalorifiqueChaud;
        [JsonProperty("puissance_calorifique_froid")]
        private int _PuissanceCalorifiqueFroid;
        [JsonProperty("puissance_electrique_chaud")]
        private int _PuissanceElectriqueChaud;
        [JsonProperty("puissance_electrique_froid")]
        private int _PuissanceElectriqueFroid; 
        [JsonProperty("lien_image")]
        private string _LienImage;
        [JsonProperty("id")]
        private int _IDServeur;
        private int _IDCategorie;

        public Produit()
        {

        }
        [PrimaryKey,AutoIncrement]
        public int ID
        {
            get{return _ID; }
            set{_ID = value;}
        }

        public string Reference
        {
            get { return _Reference; }
            set{_Reference = value;}
        }

        public string Nom
        {
            get{return _Nom;}
            set{_Nom = value;}
        }

        public string Type
        {
            get{ return _Type;}
            set{_Type = value;}
        }

        public string Description
        {
            get{return _Description; }
            set{_Description = value;}
        }

        public int PuissanceCalorifiqueChaud
        {
            get { return _PuissanceCalorifiqueChaud; }
            set { _PuissanceCalorifiqueChaud = value; }
        }

        public int PuissanceCalorifiqueFroid
        {
            get { return _PuissanceCalorifiqueFroid; }
            set { _PuissanceCalorifiqueFroid = value; }
        }

        public int PuissanceElectriqueChaud
        {
            get { return _PuissanceElectriqueChaud; }
            set { _PuissanceElectriqueChaud = value; }
        }

        public int PuissanceElectriqueFroid
        {
            get { return _PuissanceElectriqueFroid; }
            set { _PuissanceElectriqueFroid = value; }
        }

        public string LienImage
        {
            get{return _LienImage;}
            set{_LienImage = value;}
        }

        public int IDServeur
        {
            get{ return _IDServeur;}
            set{_IDServeur = value;}
        }

        public int IDCategorie
        {
            get{return _IDCategorie;}
            set{_IDCategorie = value;}
        }
    }
}
