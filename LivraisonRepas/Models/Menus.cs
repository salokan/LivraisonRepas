using System.Runtime.Serialization;
using Windows.Data.Json;

namespace LivraisonRepas.Models
{
    [DataContract]
    public class Menus
    {
        private int _id;
        private string _nom;
        private double _prix;
        private int _stock;
        private int _idRestaurant;

        public Menus(JsonObject jsonObject)
        {
            IdMenus = (int)jsonObject.GetNamedNumber("IdMenus");
            IdRestaurant = (int)jsonObject.GetNamedNumber("IdRestaurant");
            NomMenus = jsonObject.GetNamedString("NomMenus");
            Prix = jsonObject.GetNamedNumber("Prix");
            Stock = (int)jsonObject.GetNamedNumber("Stock"); 
        }

        public Menus(string nom, double prix, int stock, int idRestaurant)
        {
            IdMenus = 0;
            NomMenus = nom;
            Prix = prix;
            Stock = stock;
            IdRestaurant = idRestaurant;
        }

        [DataMember(Name = "IdMenus", IsRequired = true)]
        public int IdMenus
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

        [DataMember(Name = "NomMenus", IsRequired = true)]
        public string NomMenus
        {
            get
            {
                return _nom;
            }
            set
            {
                _nom = value;
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

        [DataMember(Name = "Stock", IsRequired = true)]
        public int Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                _stock = value;
            }
        }

        [DataMember(Name = "IdRestaurant", IsRequired = true)]
        public int IdRestaurant
        {
            get
            {
                return _idRestaurant;
            }
            set
            {
                _idRestaurant = value;
            }
        }
    }
}
