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
        private string _contenu;
        private string _etat;

        public Commandes(JsonObject jsonObject)
        {
            Contenu = jsonObject.GetNamedString("Contenu");
            Etat = jsonObject.GetNamedString("Etat");
            IdClients = (int)jsonObject.GetNamedNumber("IdClients");
            IdCommandes = (int)jsonObject.GetNamedNumber("IdCommandes");
            IdLivreurs = (int)jsonObject.GetNamedNumber("IdLivreurs");    
        }

        public Commandes(string contenu, string etat, int idClients, int idLivreurs)
        {
            Contenu = contenu;
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

        [DataMember(Name = "Contenu", IsRequired = true)]
        public string Contenu
        {
            get
            {
                return _contenu;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _contenu = value;
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
