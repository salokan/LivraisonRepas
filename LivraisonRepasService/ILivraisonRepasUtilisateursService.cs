using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LivraisonRepasService.Composite;

namespace LivraisonRepasService
{
    [ServiceContract]
    public interface ILivraisonRepasUtilisateursService
    {
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
        [OperationContract]
        bool ExistePseudo(string pseudo);
    }
}
