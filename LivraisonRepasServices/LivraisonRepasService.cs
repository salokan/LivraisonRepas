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

        #region Commandes

        public CommandesListComposite GetCommandes()
        {
            CommandesListComposite commandesList = new CommandesListComposite();

            commandesList.CommandesListe = _commandes.GetCommandes();

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
           return  _utilisateurs.GetUtilisateurs(int.Parse(id));
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
    }
}
