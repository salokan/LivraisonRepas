using System.Runtime.Serialization;
using Windows.Data.Json;

namespace LivraisonRepas.Models
{
    public class MenuRestaurant
    {
        private int _id;
        private int _idRestaurant;
        private int _idMenu;

        public MenuRestaurant(JsonObject jsonObject)
        {
            IdMenuRestaurant = (int)jsonObject.GetNamedNumber("IdMenuRestaurant");
            IdRestaurant = (int) jsonObject.GetNamedNumber("IdRestaurant");
            IdMenu = (int)jsonObject.GetNamedNumber("IdMenu");
        }

        public MenuRestaurant(int id, int idRestaurant, int idMenu)
        {
            IdMenuRestaurant = id;
            IdRestaurant = idRestaurant;
            IdMenu = idMenu;
        }

        [DataMember(Name = "IdMenuRestaurant", IsRequired = true)]
        public int IdMenuRestaurant
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

        [DataMember(Name = "IdMenu", IsRequired = true)]
        public int IdMenu
        {
            get
            {
                return _idMenu;
            }
            set
            {
                _idMenu = value;
            }
        }
    }
}
