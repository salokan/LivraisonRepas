using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LivraisonRepasService.Composite;

namespace LivraisonRepasService
{
    [ServiceContract]
    public interface ILivraisonRepasService
    {
        #region Utilisateurs
        [OperationContract]
        List<UtilisateursComposite> GetUtilisateurs();
        [OperationContract]
        UtilisateursComposite GetUtilisateur(int id);
        [OperationContract]
        void AddUtilisateurs(Utilisateurs u);
        [OperationContract]
        void DeleteUtilisateurs(int id);
        [OperationContract]
        void UpdateUtilisateurs(Utilisateurs u);
        [OperationContract]
        UtilisateursComposite AuthentificationUtilisateur(string pseudo, string password);
        #endregion

        #region Commandes
        [OperationContract]
        List<CommandesComposite> GetCommandes();
        [OperationContract]
        CommandesComposite GetCommande(int id);
        [OperationContract]
        void AddCommandes(Commandes c);
        [OperationContract]
        void DeleteCommandes(int id);
        [OperationContract]
        void UpdateCommandes(Commandes c);
        #endregion
    }
}
