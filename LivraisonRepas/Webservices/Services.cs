using LivraisonRepas.LivraisonRepasCommandesServiceReference;
using LivraisonRepas.LivraisonRepasUtilisateursServiceReference;

namespace LivraisonRepas.Webservices
{
    public class Services
    {
        private LivraisonRepasUtilisateursServiceClient _clientUtilisateurs;
        private LivraisonRepasCommandesServiceClient _clientCommandes;

        public CommandesCad Commandes{ get; set; }
        public UtilisateursCad Utilisateurs { get; set; }

        public Services()
        {
            InitWebservices();
        }

        public void InitWebservices()
        {
            _clientUtilisateurs = new LivraisonRepasUtilisateursServiceClient();
            _clientCommandes = new LivraisonRepasCommandesServiceClient();

            Utilisateurs = new UtilisateursCad(_clientUtilisateurs);

            Commandes = new CommandesCad(_clientCommandes);
        }
    }
}
