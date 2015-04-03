using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LivraisonRepasServices.Composite
{
    [DataContract]
    public class CommandesComposite
    {
        [DataMember]
        public int IdCommandes { get; set; }

        [DataMember]
        public int IdClients { get; set; }

        [DataMember]
        public int IdLivreurs { get; set; }

        [DataMember]
        public string Contenu { get; set; }

        [DataMember]
        public string Etat { get; set; }
    }

    [DataContract]
    public class CommandesListComposite
    {
        [DataMember]
        public List<CommandesComposite> CommandesListe { get; set; }    
    }
}
