using System.Runtime.Serialization;

namespace LivraisonRepasService.Composite
{
    [DataContract]
    public class CommandesComposite
    {
        int _idCommandes;
        int _idClients;
        int _idLivreurs;
        string _contenu;
        string _etat;

        [DataMember]
        public int IdCommandesValue
        {
            get { return _idCommandes; }
            set { _idCommandes = value; }
        }

        [DataMember]
        public int IdClientsValue
        {
            get { return _idClients; }
            set { _idClients = value; }
        }

        [DataMember]
        public int IdLivreursValue
        {
            get { return _idLivreurs; }
            set { _idLivreurs = value; }
        }

        [DataMember]
        public string ContenuValue
        {
            get { return _contenu; }
            set { _contenu = value; }
        }

        [DataMember]
        public string EtatValue
        {
            get { return _etat; }
            set { _etat = value; }
        }
    }
}