using System;
using Windows.Data.Json;

namespace LivraisonRepas.Models
{
    public class Utilisateurs
    {
        private string _id;
        private string _pseudo;
        private string _password;
        private string _adresse;
        private string _type;

        public Utilisateurs(JsonObject jsonObject)
        {
            Id = jsonObject.GetNamedString("Id");
            Pseudo = jsonObject.GetNamedString("Pseudo");
            Password = jsonObject.GetNamedString("Password");
            Adresse = jsonObject.GetNamedString("Adresse");
            Type = jsonObject.GetNamedString("Type");
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

        public string Pseudo
        {
            get
            {
                return _pseudo;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _pseudo = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _password = value;
            }
        }

        public string Adresse
        {
            get
            {
                return _adresse;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _adresse = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _type = value;
            }
        }
    }
}
