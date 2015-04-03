using System.ServiceModel;
using System.ServiceModel.Web;
using LivraisonRepasServices.Composite;

namespace LivraisonRepasServices
{
    [ServiceContract(Name = "LivraisonRepasService")]
    public interface ILivraisonRepasService
    {
        #region Commandes     

        [OperationContract]
        [WebGet(UriTemplate = "Commandes", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommandesListComposite GetCommandes();

        [OperationContract]
        [WebGet(UriTemplate = "CommandesByLivreur/{idLivreur}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommandesListComposite GetCommandesByLivreur(string idLivreur);

        [OperationContract]
        [WebGet(UriTemplate = "Commande/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommandesComposite GetCommande(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Commande/Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void AddCommande(CommandesComposite c);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Commande/Update/{id}", RequestFormat = WebMessageFormat.Json)]
        void UpdateCommande(string id, CommandesComposite c);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Commande/Delete/{id}")]
        void DeleteCommande(string id);

        #endregion

        #region Utilisateurs

        [OperationContract]
        [WebGet(UriTemplate = "Utilisateurs", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        UtilisateursListComposite GetUtilisateurs();

        [OperationContract]
        [WebGet(UriTemplate = "Utilisateur/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        UtilisateursComposite GetUtilisateur(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Utilisateur/Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void AddUtilisateur(UtilisateursComposite u);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Utilisateur/Update/{id}", RequestFormat = WebMessageFormat.Json)]
        void UpdateUtilisateur(string id, UtilisateursComposite u);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Utilisateur/Delete/{id}")]
        void DeleteUtilisateur(string id);

        [OperationContract]
        [WebGet(UriTemplate = "Utilisateur/Authentification/{pseudo}/{password}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        UtilisateursComposite AuthentificationUtilisateur(string pseudo, string password);

        [OperationContract]
        [WebGet(UriTemplate = "Utilisateur/ExistePseudo/{pseudo}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string ExistePseudo(string pseudo);

        #endregion

        #region Restaurants

        [OperationContract]
        [WebGet(UriTemplate = "Restaurants", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        RestaurantsListComposite GetRestaurants();

        [OperationContract]
        [WebGet(UriTemplate = "Restaurant/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        RestaurantsComposite GetRestaurant(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Restaurant/Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void AddRestaurant(RestaurantsComposite r);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Restaurant/Update/{id}", RequestFormat = WebMessageFormat.Json)]
        void UpdateRestaurant(string id, RestaurantsComposite r);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Restaurant/Delete/{id}")]
        void DeleteRestaurant(string id);

        #endregion

        #region Menus

        [OperationContract]
        [WebGet(UriTemplate = "Menus", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        MenusListComposite GetMenus();

        [OperationContract]
        [WebGet(UriTemplate = "Menu/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        MenusComposite GetMenu(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Menu/Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void AddMenu(MenusComposite m);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Menu/Update/{id}", RequestFormat = WebMessageFormat.Json)]
        void UpdateMenu(string id, MenusComposite m);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Menu/Delete/{id}")]
        void DeleteMenu(string id);

        #endregion

        #region MenuRestaurant

        [OperationContract]
        [WebGet(UriTemplate = "MenuRestaurant", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        MenuRestaurantListComposite GetMenusRestaurant();

        [OperationContract]
        [WebGet(UriTemplate = "MenuRestaurantByRestaurant/{idRestaurant}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        MenuRestaurantListComposite GetMenusRestaurantByRestaurant(string idRestaurant);

        [OperationContract]
        [WebGet(UriTemplate = "MenuRestaurant/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        MenuRestaurantComposite GetMenuRestaurant(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "MenuRestaurant/Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void AddMenuRestaurant(MenuRestaurantComposite mr);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "MenuRestaurant/Update/{id}", RequestFormat = WebMessageFormat.Json)]
        void UpdateMenuRestaurant(string id, MenuRestaurantComposite mr);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "MenuRestaurant/Delete/{id}")]
        void DeleteMenuRestaurant(string id);

        #endregion

        #region MenuCommande

        [OperationContract]
        [WebGet(UriTemplate = "MenuCommande", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        MenuCommandeListComposite GetMenusCommande();

        [OperationContract]
        [WebGet(UriTemplate = "MenuCommandeByCommande/{idCommande}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        MenuCommandeListComposite GetMenusCommandeByCommande(string idCommande);

        [OperationContract]
        [WebGet(UriTemplate = "MenuCommande/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        MenuCommandeComposite GetMenuCommande(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "MenuCommande/Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void AddMenuCommande(MenuCommandeComposite mc);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "MenuCommande/Update/{id}", RequestFormat = WebMessageFormat.Json)]
        void UpdateMenuCommande(string id, MenuCommandeComposite mc);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "MenuCommande/Delete/{id}")]
        void DeleteMenuCommande(string id);

        #endregion
    }
}
