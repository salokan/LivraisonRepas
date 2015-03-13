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
    public interface ILivraisonRepasCommandesService
    {
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
    }
}
