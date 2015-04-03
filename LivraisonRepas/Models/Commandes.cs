using System;
using System.Runtime.Serialization;
using Windows.Data.Json;

namespace LivraisonRepas.Models
{
    [DataContract]
    public class Commandes
    {
        private int _id;
        private int _idClient;
        private int _idLivreur;
        private double _prix;
        private string _etat;

        public Commandes(JsonObject jsonObject)
        {
            Prix = jsonObject.GetNamedNumber("Prix");
            Etat = jsonObject.GetNamedString("Etat");
            IdClients = (int)jsonObject.GetNamedNumber("IdClients");
            IdCommandes = (int)jsonObject.GetNamedNumber("IdCommandes");
            IdLivreurs = (int)jsonObject.GetNamedNumber("IdLivreurs");    
        }

        public Commandes(double prix, string etat, int idClients, int idLivreurs)
        {
            Prix = prix;
            Etat = etat;
            IdClients = idClients;
            IdCommandes = 0;
            IdLivreurs = idLivreurs;
        }

        [DataMember(Name = "IdCommandes", IsRequired = true)]
        public int IdCommandes
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember(Name = "IdClients", IsRequired = true)]
        public int IdClients
        {
            get
            {
                return _idClient;
            }
            set
            {
                _idClient = value;
            }
        }

        [DataMember(Name = "IdLivreurs", IsRequired = true)]
        public int IdLivreurs
        {
            get { return _idLivreur; }
            set
            {
                _idLivreur = value;
            }
        }

        [DataMember(Name = "Prix", IsRequired = true)]
        public double Prix
        {
            get
            {
                return _prix;
            }
            set
            {
                _prix = value;
            }
        }

        [DataMember(Name = "Etat", IsRequired = true)]
        public string Etat
        {
            get
            {
                return _etat;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _etat = value;
            }
        }
    }
}
