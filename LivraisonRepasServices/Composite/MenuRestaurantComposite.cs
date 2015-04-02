using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LivraisonRepasServices.Composite
{
    [DataContract]
    public class MenuRestaurantComposite
    {
        [DataMember]
        public int IdMenuRestaurant { get; set; }

        [DataMember]
        public int IdRestaurant { get; set; }

        [DataMember]
        public int IdMenu { get; set; }
    }

    [DataContract]
    public class MenuRestaurantListComposite
    {
        [DataMember]
        public List<MenuRestaurantComposite> MenuRestaurantListe { get; set; }
    }
}
