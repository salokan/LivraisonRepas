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
    }
}
