using LivraisonRepas.LivraisonRepasCommandesServiceReference;
using LivraisonRepas.LivraisonRepasUtilisateursServiceReference;

namespace LivraisonRepas.Webservices
{
    public class Services
    {
        private LivraisonRepasUtilisateursServiceClient _clientUtilisateurs;
        private LivraisonRepasCommandesServiceClient _clientCommandes;

        public CommandesCad _commandes{ get; set; }
        public UtilisateursCad _utilisateurs { get; set; }

        public Services()
        {
            InitWebservices();
        }

        public void InitWebservices()
        {
            _clientUtilisateurs = new LivraisonRepasUtilisateursServiceClient();
            _clientCommandes = new LivraisonRepasCommandesServiceClient();

            _utilisateurs = new UtilisateursCad(_clientUtilisateurs);

            _commandes = new CommandesCad(_clientCommandes);
        }
    }
}
