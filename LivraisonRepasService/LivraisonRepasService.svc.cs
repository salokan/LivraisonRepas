using System.Collections.Generic;
using LivraisonRepasService.CAD;
using LivraisonRepasService.Composite;

namespace LivraisonRepasService
{
    public class LivraisonRepasService : ILivraisonRepasService
    {
        private readonly UtilisateursCad _utilisateurs = new UtilisateursCad();
        private readonly CommandesCad _commandes = new CommandesCad();

        #region Utilisateurs
        public List<UtilisateursComposite> GetUtilisateurs()
        {
            return _utilisateurs.GetUtilisateurs();
        }

        public UtilisateursComposite GetUtilisateur(int id)
        {
            return _utilisateurs.GetUtilisateurs(id);
        }

        public void AddUtilisateurs(Utilisateurs u)
        {
            _utilisateurs.AddUtilisateurs(u);
        }

        public void DeleteUtilisateurs(int id)
        {
            _utilisateurs.DeleteUtilisateurs(id);
        }

        public void UpdateUtilisateurs(Utilisateurs u)
        {
            _utilisateurs.UpdateUtilisateurs(u);
        }


        public UtilisateursComposite AuthentificationUtilisateur(string pseudo, string password)
        {
            return _utilisateurs.AuthentificationUtilisateur(pseudo, password);
        }
        #endregion

        #region Commandes
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
        #endregion
    }
}
