using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LivraisonRepasServices.Composite
{
    [DataContract]
    public class RestaurantsComposite
    {  
        [DataMember]
        public int IdRestaurants { get; set; }

        [DataMember]
        public string NomRestaurants { get; set; }       
    }

    [DataContract]
    public class RestaurantsListComposite
    {
        [DataMember]
        public List<RestaurantsComposite> RestaurantsListe { get; set; }
    }
}
