using System.Runtime.Serialization;
using Windows.Data.Json;

namespace LivraisonRepas.Models
{
    public class Restaurants
    {
        private int _id;
        private string _nom;

        public Restaurants(JsonObject jsonObject)
        {
            IdRestaurants = (int) jsonObject.GetNamedNumber("IdRestaurants");
            NomRestaurants = jsonObject.GetNamedString("NomRestaurants");
        }

        public Restaurants(int id, string nom)
        {
            IdRestaurants = id;
            NomRestaurants = nom;
        }

        [DataMember(Name = "IdRestaurants", IsRequired = true)]
        public int IdRestaurants
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

        [DataMember(Name = "NomRestaurants", IsRequired = true)]
        public string NomRestaurants
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
    }
}
