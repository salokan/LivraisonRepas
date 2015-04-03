namespace LivraisonRepas.Webservices
{
    public class Services
    {
        public CommandesCad Commandes{ get; set; }
        public UtilisateursCad Utilisateurs { get; set; }
        public RestaurantsCad Restaurants { get; set; }
        public MenusCad Menus { get; set; }
        public MenuRestaurantCad MenusRestaurant { get; set; }
        public MenuCommandeCad MenusCommande { get; set; }

        public Services()
        {
            InitWebservices();
        }

        public void InitWebservices()
        {
            Utilisateurs = new UtilisateursCad();
            Commandes = new CommandesCad();
            Restaurants = new RestaurantsCad();
            Menus = new MenusCad();
            MenusRestaurant = new MenuRestaurantCad();
            MenusCommande = new MenuCommandeCad();
        }
    }
}
