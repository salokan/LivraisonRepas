using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LivraisonRepasServices.Composite
{
    [DataContract]
    public class MenusComposite
    {
        [DataMember]
        public int IdMenus{ get; set; }

        [DataMember]
        public string NomMenus { get; set; }

        [DataMember]
        public double Prix { get; set; }

        [DataMember]
        public int Stock { get; set; }

        [DataMember]
        public int IdRestaurant { get; set; }
    }

    [DataContract]
    public class MenusListComposite
    {
        [DataMember]
        public List<MenusComposite> MenusListe { get; set; }
    }
}
