namespace LivraisonRepas.Webservices
{
    public class Services
    {
        public CommandesCad Commandes{ get; set; }
        public UtilisateursCad Utilisateurs { get; set; }

        public Services()
        {
            InitWebservices();
        }

        public void InitWebservices()
        {
            Utilisateurs = new UtilisateursCad();
            Commandes = new CommandesCad();
        }
    }
}
