using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LivraisonRepasServices.Composite
{
    [DataContract]
    public class CommandesComposite
    {
        [DataMember]
        public int IdCommandesValue { get; set; }

        [DataMember]
        public int IdClientsValue { get; set; }

        [DataMember]
        public int IdLivreursValue { get; set; }

        [DataMember]
        public string ContenuValue { get; set; }

        [DataMember]
        public string EtatValue { get; set; }
    }

    [DataContract]
    public class CommandesListComposite
    {
        [DataMember]
        public List<CommandesComposite> CommandesListe { get; set; }    
    }
}
