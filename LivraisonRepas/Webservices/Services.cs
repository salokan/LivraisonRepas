using LivraisonRepas.LivraisonRepasServiceReference;

namespace LivraisonRepas.Webservices
{
    public class Services
    {
        private LivraisonRepasServiceClient _client;

        public CommandesCad _commandes{ get; set; }
        public UtilisateursCad _utilisateurs { get; set; }

        public Services()
        {
            InitWebservices();
        }

        public void InitWebservices()
        {
            _client = new LivraisonRepasServiceClient();

            _commandes = new CommandesCad(_client);

            _utilisateurs = new UtilisateursCad(_client);
        }
    }
}
