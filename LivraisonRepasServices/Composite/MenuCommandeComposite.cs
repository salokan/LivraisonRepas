using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LivraisonRepasServices.Composite
{
    [DataContract]
    public class MenuCommandeComposite
    {
        [DataMember]
        public int IdMenuCommande{ get; set; }

        [DataMember]
        public int IdCommande { get; set; }

        [DataMember]
        public int IdMenu { get; set; }
    }

    [DataContract]
    public class MenuCommandeListComposite
    {
        [DataMember]
        public List<MenuCommandeComposite> MenuCommandeListe { get; set; }
    }
}
