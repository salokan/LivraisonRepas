using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using LivraisonRepasServices.Composite;

namespace LivraisonRepasServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LivraisonRepasService : ILivraisonRepasService
    {
        #region Test

        public CommandesComposite TestGet(string test)
        {
            CommandesComposite cc = new CommandesComposite
                                    {
                                        ContenuValue = "contenu",
                                        EtatValue = "etat",
                                        IdClientsValue = 1,
                                        IdCommandesValue = 2,
                                        IdLivreursValue = 3
                                    };

            return cc;
        }

        public CommandesComposite TestGet2(string test, string test2)
        {
            CommandesComposite cc = new CommandesComposite
            {
                ContenuValue = "contenu",
                EtatValue = "etat",
                IdClientsValue = 1,
                IdCommandesValue = 2,
                IdLivreursValue = 3
            };

            return cc;
        }


        public void TestPOST(CommandesComposite test)
        {
            string post;
        }

        public void TestPUT(string test, CommandesComposite test2)
        {
            string put;
        }

        public void TestDelete(string test)
        {
            string delete;
        }

        #endregion

        #region Commandes

        public CommandesListComposite GetCommandes()
        {
            CommandesListComposite c = new CommandesListComposite();

            List<CommandesComposite> l = new List<CommandesComposite>();
            CommandesComposite cc = new CommandesComposite
            {
                ContenuValue = "contenu",
                EtatValue = "etat",
                IdClientsValue = 1,
                IdCommandesValue = 2,
                IdLivreursValue = 3
            };

            CommandesComposite cc2 = new CommandesComposite
            {
                ContenuValue = "contenu2",
                EtatValue = "etat2",
                IdClientsValue = 12,
                IdCommandesValue = 22,
                IdLivreursValue = 32
            };

            l.Add(cc);
            l.Add(cc2);

            c.CommandesListe = l;

            return c;
        }

        public CommandesComposite GetCommande(string id)
        {
            throw new System.NotImplementedException();
        }

        public void AddCommande(CommandesComposite c)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommande(string id, CommandesComposite c)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommande(string id)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Utilisateurs

        public CommandesComposite GetUtilisateur()
        {
            throw new System.NotImplementedException();
        }

        public CommandesComposite GetUtilisateurs(string id)
        {
            throw new System.NotImplementedException();
        }

        public void AddUtilisateur(UtilisateursComposite u)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUtilisateur(string id, UtilisateursComposite u)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUtilisateur(string id)
        {
            throw new System.NotImplementedException();
        }

        public UtilisateursComposite AuthentificationUtilisateur(string pseudo, string password)
        {
            throw new System.NotImplementedException();
        }

        public string ExistePseudo(string pseudo)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
