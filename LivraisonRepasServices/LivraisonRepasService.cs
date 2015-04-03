using System.ServiceModel;
using System.ServiceModel.Activation;
using LivraisonRepasServices.CAD;
using LivraisonRepasServices.Composite;

namespace LivraisonRepasServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LivraisonRepasService : ILivraisonRepasService
    {
        private readonly CommandesCad _commandes = new CommandesCad();
        private readonly UtilisateursCad _utilisateurs = new UtilisateursCad();
        private readonly RestaurantsCad _restaurants = new RestaurantsCad();
        private readonly MenusCad _menus = new MenusCad();
        private readonly MenuRestaurantCad _menuRestaurant = new MenuRestaurantCad();
        private readonly MenuCommandeCad _menuCommande = new MenuCommandeCad();

        #region Commandes

        public CommandesListComposite GetCommandes()
        {
            CommandesListComposite commandesList = new CommandesListComposite();

            commandesList.CommandesListe = _commandes.GetCommandes();

            return commandesList;
        }

        public CommandesListComposite GetCommandesByLivreur(int idLivreur)
        {
            CommandesListComposite commandesList = new CommandesListComposite();

            commandesList.CommandesListe = _commandes.GetCommandesByLivreur(idLivreur);

            return commandesList;
        }

        public CommandesComposite GetCommande(string id)
        {
            return _commandes.GetCommandes(int.Parse(id));
        }

        public void AddCommande(CommandesComposite c)
        {
            _commandes.AddCommandes(c);
        }

        public void UpdateCommande(string id, CommandesComposite c)
        {
            _commandes.UpdateCommandes(c);
        }

        public void DeleteCommande(string id)
        {
            _commandes.DeleteCommandes(int.Parse(id));
        }

        #endregion

        #region Utilisateurs

        public UtilisateursListComposite GetUtilisateurs()
        {
            UtilisateursListComposite utilisateursList = new UtilisateursListComposite();

            utilisateursList.UtilisateursListe = _utilisateurs.GetUtilisateurs();

            return utilisateursList;
        }

        public UtilisateursComposite GetUtilisateur(string id)
        {
           return _utilisateurs.GetUtilisateurs(int.Parse(id));
        }

        public void AddUtilisateur(UtilisateursComposite u)
        {
            _utilisateurs.AddUtilisateurs(u);
        }

        public void UpdateUtilisateur(string id, UtilisateursComposite u)
        {
            _utilisateurs.UpdateUtilisateurs(u);
        }

        public void DeleteUtilisateur(string id)
        {
            _utilisateurs.DeleteUtilisateurs(int.Parse(id));
        }

        public UtilisateursComposite AuthentificationUtilisateur(string pseudo, string password)
        {
            return _utilisateurs.AuthentificationUtilisateur(pseudo, password);
        }

        public string ExistePseudo(string pseudo)
        {
            if (_utilisateurs.ExistePseudo(pseudo))
                return "true";
            return "false";
        }

        #endregion

        #region Restaurants

        public RestaurantsListComposite GetRestaurants()
        {
            RestaurantsListComposite restaurantsList = new RestaurantsListComposite();

            restaurantsList.RestaurantsListe = _restaurants.GetRestaurants();

            return restaurantsList;
        }

        public RestaurantsComposite GetRestaurant(string id)
        {
            return _restaurants.GetRestaurants(int.Parse(id));
        }

        public void AddRestaurant(RestaurantsComposite r)
        {
            _restaurants.AddRestaurants(r);
        }

        public void UpdateRestaurant(string id, RestaurantsComposite r)
        {
            _restaurants.UpdateRestaurants(r);
        }

        public void DeleteRestaurant(string id)
        {
            _restaurants.DeleteRestaurants(int.Parse(id));
        }

        #endregion

        #region Menus

        public MenusListComposite GetMenus()
        {
            MenusListComposite menusList = new MenusListComposite();

            menusList.MenusListe = _menus.GetMenus();

            return menusList;
        }

        public MenusComposite GetMenu(string id)
        {
            return _menus.GetMenus(int.Parse(id));
        }

        public void AddMenu(MenusComposite m)
        {
            _menus.AddMenus(m);
        }

        public void UpdateMenu(string id, MenusComposite m)
        {
            _menus.UpdateMenus(m);
        }

        public void DeleteMenu(string id)
        {
            _menus.DeleteMenus(int.Parse(id));
        }

        #endregion

        #region MenuRestaurant

        public MenuRestaurantListComposite GetMenusRestaurant()
        {
            MenuRestaurantListComposite menuRestaurantList = new MenuRestaurantListComposite();

            menuRestaurantList.MenuRestaurantListe = _menuRestaurant.GetMenuRestaurant();

            return menuRestaurantList;
        }

        public MenuRestaurantListComposite GetMenusRestaurantByRestaurant(int idRestaurant)
        {
            MenuRestaurantListComposite menuRestaurantList = new MenuRestaurantListComposite();

            menuRestaurantList.MenuRestaurantListe = _menuRestaurant.GetMenuRestaurantByRestaurant(idRestaurant);

            return menuRestaurantList;
        }

        public MenuRestaurantComposite GetMenuRestaurant(string id)
        {
            return _menuRestaurant.GetMenuRestaurant(int.Parse(id));
        }

        public void AddMenuRestaurant(MenuRestaurantComposite mr)
        {
            _menuRestaurant.AddMenuRestaurant(mr);
        }

        public void UpdateMenuRestaurant(string id, MenuRestaurantComposite mr)
        {
            _menuRestaurant.UpdateMenuRestaurant(mr);
        }

        public void DeleteMenuRestaurant(string id)
        {
            _menuRestaurant.DeleteMenuRestaurant(int.Parse(id));
        }

        #endregion

        #region MenuCommande

        public MenuCommandeListComposite GetMenusCommande()
        {
            MenuCommandeListComposite menuCommandeList = new MenuCommandeListComposite();

            menuCommandeList.MenuCommandeListe = _menuCommande.GetMenuCommande();

            return menuCommandeList;
        }

        public MenuCommandeListComposite GetMenusCommandeByCommande(int idCommande)
        {
            MenuCommandeListComposite menuCommandeList = new MenuCommandeListComposite();

            menuCommandeList.MenuCommandeListe = _menuCommande.GetMenuCommandeByCommande(idCommande);

            return menuCommandeList;
        }

        public MenuCommandeComposite GetMenuCommande(string id)
        {
            return _menuCommande.GetMenuCommande(int.Parse(id));
        }

        public void AddMenuCommande(MenuCommandeComposite mc)
        {
            _menuCommande.AddMenuCommande(mc);
        }

        public void UpdateMenuCommande(string id, MenuCommandeComposite mc)
        {
            _menuCommande.UpdateMenuCommande(mc);
        }

        public void DeleteMenuCommande(string id)
        {
            _menuCommande.DeleteMenuCommande(int.Parse(id));
        }

        #endregion 
    }
}
