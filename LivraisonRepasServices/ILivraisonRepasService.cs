using System.ServiceModel;
using System.ServiceModel.Web;
using LivraisonRepasServices.Composite;

namespace LivraisonRepasServices
{
    [ServiceContract(Name = "LivraisonRepasService")]
    public interface ILivraisonRepasService
    {
        #region Test

        [OperationContract]
        [WebGet(UriTemplate = "Test/{test}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommandesComposite TestGet(string test);

        [OperationContract]
        [WebGet(UriTemplate = "Test/{test}/{test2}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommandesComposite TestGet2(string test, string test2);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Test/Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void TestPOST(CommandesComposite test);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Test/Update/{test}", RequestFormat = WebMessageFormat.Json)]
        void TestPUT(string test, CommandesComposite test2);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Test/Delete/{test}")]
        void TestDelete(string test);

        #endregion

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
        CommandesComposite GetUtilisateur();

        [OperationContract]
        [WebGet(UriTemplate = "Utilisateur/{id}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CommandesComposite GetUtilisateurs(string id);

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
