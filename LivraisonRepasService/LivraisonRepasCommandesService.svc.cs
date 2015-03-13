using System.Collections.Generic;
using LivraisonRepasService.CAD;
using LivraisonRepasService.Composite;

namespace LivraisonRepasService
{
     public class LivraisonRepasCommandesService : ILivraisonRepasCommandesService
    {
        private readonly CommandesCad _commandes = new CommandesCad();
        public List<CommandesComposite> GetCommandes()
        {
            return _commandes.GetCommandes();
        }

        public CommandesComposite GetCommande(int id)
        {
            return _commandes.GetCommandes(id);
        }

        public void AddCommandes(Commandes c)
        {
            _commandes.AddCommandes(c);
        }

        public void DeleteCommandes(int id)
        {
            _commandes.DeleteCommandes(id);
        }

        public void UpdateCommandes(Commandes c)
        {
            _commandes.UpdateCommandes(c);
        }
    }
}
