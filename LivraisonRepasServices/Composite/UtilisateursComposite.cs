using System.Runtime.Serialization;

namespace LivraisonRepasServices.Composite
{
    [DataContract]
    public class UtilisateursComposite
    {
        [DataMember]
        public int IdUtilisateursValue { get; set; }

        [DataMember]
        public string PseudoValue { get; set; }

        [DataMember]
        public string PasswordValue { get; set; }

        [DataMember]
        public string AdresseValue { get; set; }

        [DataMember]
        public string TypeValue { get; set; }
    }
}
