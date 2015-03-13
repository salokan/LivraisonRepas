using System.Collections.Generic;
using LivraisonRepasService.CAD;
using LivraisonRepasService.Composite;

namespace LivraisonRepasService
{
    public class LivraisonRepasAuthentificationService : ILivraisonRepasUtilisateursService
    {
        private readonly UtilisateursCad _utilisateurs = new UtilisateursCad();

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

        public bool ExistePseudo(string pseudo)
        {
            return _utilisateurs.ExistePseudo(pseudo);
        }
    }
}
