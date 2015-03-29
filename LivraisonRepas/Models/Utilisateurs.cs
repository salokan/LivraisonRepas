using System;
using System.Runtime.Serialization;
using Windows.Data.Json;

namespace LivraisonRepas.Models
{
    [DataContract]
    public class Utilisateurs
    {
        private int _id;
        private string _pseudo;
        private string _password;
        private string _adresse;
        private string _type;

        public Utilisateurs(JsonObject jsonObject)
        {
            Adresse = jsonObject.GetNamedString("Adresse");
            IdUtilisateurs = (int) jsonObject.GetNamedNumber("IdUtilisateurs");
            Password = jsonObject.GetNamedString("Password");
            Pseudo = jsonObject.GetNamedString("Pseudo");  
            Type = jsonObject.GetNamedString("Type");
        }

        public Utilisateurs(string pseudo, string password, string adresse, string type)
        {
            IdUtilisateurs = 0;
            Pseudo = pseudo;
            Password = password;
            Adresse = adresse;
            Type = type;
        }

        [DataMember(Name = "IdUtilisateurs", IsRequired = true)]
        public int IdUtilisateurs
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

        [DataMember(Name = "Pseudo", IsRequired = true)]
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

        [DataMember(Name = "Password", IsRequired = true)]
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

        [DataMember(Name = "Adresse", IsRequired = true)]
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

        [DataMember(Name = "Type", IsRequired = true)]
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
