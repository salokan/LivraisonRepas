using System;
using Windows.Data.Json;

namespace LivraisonRepas.Models
{
    public class Commandes
    {
        private string _id;
        private string _idClient;
        private string _idLivreur;
        private string _contenu;
        private string _etat;

        public Commandes(JsonObject jsonObject)
        {
            Id = jsonObject.GetNamedString("Id");
            IdClient = jsonObject.GetNamedString("_idClient");
            IdLivreur = jsonObject.GetNamedString("_idLivreur");
            Contenu = jsonObject.GetNamedString("_contenu");
            Etat = jsonObject.GetNamedString("_etat");
        }
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _id = value;
            }
        }

        public string IdClient
        {
            get
            {
                return _idClient;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _idClient = value;
            }
        }

        public string IdLivreur
        {
            get { return _idLivreur; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _idLivreur = value;
            }
        }

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
