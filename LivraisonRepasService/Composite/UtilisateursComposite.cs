using System.Runtime.Serialization;

namespace LivraisonRepasService.Composite
{
    [DataContract]
    public class UtilisateursComposite
    {
        int _idUtilisateurs;
        string _pseudo;
        string _password;
        string _adresse;
        string _type;

        [DataMember]
        public int IdUtilisateursValue
        {
            get { return _idUtilisateurs; }
            set { _idUtilisateurs = value; }
        }

        [DataMember]
        public string PseudoValue
        {
            get { return _pseudo; }
            set { _pseudo = value; }
        }
        
        [DataMember]
        public string PasswordValue
        {
            get { return _password; }
            set { _password = value; }
        }

        [DataMember]
        public string AdresseValue
        {
            get { return _adresse; }
            set { _adresse = value; }
        }

        [DataMember]
        public string TypeValue
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}