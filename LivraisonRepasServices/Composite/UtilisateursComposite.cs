using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LivraisonRepasServices.Composite
{
    [DataContract]
    public class UtilisateursComposite
    {
        [DataMember]
        public int IdUtilisateurs { get; set; }

        [DataMember]
        public string Pseudo { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Adresse { get; set; }

        [DataMember]
        public string Type { get; set; }
    }

    public class UtilisateursListComposite
    {
        [DataMember]
        public List<UtilisateursComposite> UtilisateursListe { get; set; }
    }
}
