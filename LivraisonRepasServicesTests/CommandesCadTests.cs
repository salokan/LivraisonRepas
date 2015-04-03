using System.Collections.Generic;
using LivraisonRepasServices.CAD;
using LivraisonRepasServices.Composite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LivraisonRepasServicesTests
{
    [TestClass]
    public class CommandesCadTests
    {
        [TestMethod]
        public void GetCommandesTest()
        {
            // Arrange 
            //Ajoute deux utilisateurs pour les associer à une commande dans la base
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite livreur = new UtilisateursComposite { Pseudo = "livreurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur"};
            UtilisateursComposite client = new UtilisateursComposite { Pseudo = "clientTest", Password = "passwordTest", Adresse = "adresseTest", Type = "client" };

            utilisateursCad.AddUtilisateurs(livreur);
            utilisateursCad.AddUtilisateurs(client);

            int idClient = 0;
            int idLivreur = 0;
            int idCommande = 0;

            List<UtilisateursComposite> utilisateursList = utilisateursCad.GetUtilisateurs();

            //On récupère les id des utilisateurs créés précédemment
            foreach (UtilisateursComposite u in utilisateursList)
            {
                if (u.Pseudo.Equals("livreurTest"))
                    idLivreur = u.IdUtilisateurs;

                if (u.Pseudo.Equals("clientTest"))
                    idClient = u.IdUtilisateurs;
            }

            //Ajoute la commande avec les utilisateurs précédemment ajoutés
            CommandesCad commandesCad = new CommandesCad();
            CommandesComposite commande = new CommandesComposite { IdClients = idClient, IdLivreurs = idLivreur };
            commandesCad.AddCommandes(commande);

            //Act
            List<CommandesComposite> commandesList;
            commandesList = commandesCad.GetCommandes();

            foreach (CommandesComposite c in commandesList)
            {
                if (c.IdClients == idClient && c.IdLivreurs == idLivreur)
                    idCommande = c.IdCommandes;
            }

            // Assert
            Assert.IsNotNull(commandesList);

            //Suppression des éléments dans base
            commandesCad.DeleteCommandes(idCommande);
            utilisateursCad.DeleteUtilisateurs(idClient);
            utilisateursCad.DeleteUtilisateurs(idLivreur);
        }

        [TestMethod]
        public void GetCommandeTest()
        {
            // Arrange 
            //Ajoute deux utilisateurs dans la base et les ajoutent dans la base
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite livreur = new UtilisateursComposite { Pseudo = "livreurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };
            UtilisateursComposite client = new UtilisateursComposite { Pseudo = "clientTest", Password = "passwordTest", Adresse = "adresseTest", Type = "client" };

            utilisateursCad.AddUtilisateurs(livreur);
            utilisateursCad.AddUtilisateurs(client);

            int idClient = 0;
            int idLivreur = 0;
            int idCommande = 0;

            List<UtilisateursComposite> utilisateursList = utilisateursCad.GetUtilisateurs();

            foreach (UtilisateursComposite u in utilisateursList)
            {
                if (u.Pseudo.Equals("livreurTest"))
                    idLivreur = u.IdUtilisateurs;

                if (u.Pseudo.Equals("clientTest"))
                    idClient = u.IdUtilisateurs;
            }

            //Ajoute la commande avec les utilisateurs précédemment ajoutés
            CommandesCad commandesCad = new CommandesCad();
            CommandesComposite commande = new CommandesComposite { IdClients = idClient, IdLivreurs = idLivreur };
            commandesCad.AddCommandes(commande);

            //Act
            List<CommandesComposite> commandesList;
            commandesList = commandesCad.GetCommandes();

            foreach (CommandesComposite c in commandesList)
            {
                if (c.IdClients == idClient && c.IdLivreurs == idLivreur)
                    idCommande = c.IdCommandes;
            }

            CommandesComposite commandeTest = commandesCad.GetCommandes(idCommande);

            // Assert
            Assert.IsNotNull(commandeTest);

            //Suppression des éléments dans base
            commandesCad.DeleteCommandes(idCommande);
            utilisateursCad.DeleteUtilisateurs(idClient);
            utilisateursCad.DeleteUtilisateurs(idLivreur);
        }

        [TestMethod]
        public void AddCommandeTest()
        {
            // Arrange 
            //Ajoute deux utilisateurs dans la base et les ajoutent dans la base
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite livreur = new UtilisateursComposite { Pseudo = "livreurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };
            UtilisateursComposite client = new UtilisateursComposite { Pseudo = "clientTest", Password = "passwordTest", Adresse = "adresseTest", Type = "client" };

            utilisateursCad.AddUtilisateurs(livreur);
            utilisateursCad.AddUtilisateurs(client);

            int idClient = 0;
            int idLivreur = 0;
            int idCommande = 0;

            List<UtilisateursComposite> utilisateursList = utilisateursCad.GetUtilisateurs();

            foreach (UtilisateursComposite u in utilisateursList)
            {
                if (u.Pseudo.Equals("livreurTest"))
                    idLivreur = u.IdUtilisateurs;

                if (u.Pseudo.Equals("clientTest"))
                    idClient = u.IdUtilisateurs;
            }

            //Ajoute la commande avec les utilisateurs précédemment ajoutés
            CommandesCad commandesCad = new CommandesCad();
            CommandesComposite commande = new CommandesComposite { IdClients = idClient, IdLivreurs = idLivreur, Etat =  "etatTest", Prix = 10.10};
            commandesCad.AddCommandes(commande);

            //Act
            List<CommandesComposite> commandesList;
            commandesList = commandesCad.GetCommandes();

            foreach (CommandesComposite c in commandesList)
            {
                if (c.IdClients == idClient && c.IdLivreurs == idLivreur)
                    idCommande = c.IdCommandes;
            }

            CommandesComposite commandeTest = commandesCad.GetCommandes(idCommande);

            commande.IdCommandes = idCommande;

            // Assert
            //Assert.AreSame(commandeTest,commande);
            Assert.IsNotNull(commandeTest);

            //Suppression des éléments dans base
            commandesCad.DeleteCommandes(idCommande);
            utilisateursCad.DeleteUtilisateurs(idClient);
            utilisateursCad.DeleteUtilisateurs(idLivreur);
        }

        [TestMethod]
        public void UpdateCommandeTest()
        {
            // Arrange 
            //Ajoute deux utilisateurs dans la base et les ajoutent dans la base
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite livreur = new UtilisateursComposite { Pseudo = "livreurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };
            UtilisateursComposite client = new UtilisateursComposite { Pseudo = "clientTest", Password = "passwordTest", Adresse = "adresseTest", Type = "client" };

            utilisateursCad.AddUtilisateurs(livreur);
            utilisateursCad.AddUtilisateurs(client);

            int idClient = 0;
            int idLivreur = 0;
            int idCommande = 0;

            List<UtilisateursComposite> utilisateursList = utilisateursCad.GetUtilisateurs();

            foreach (UtilisateursComposite u in utilisateursList)
            {
                if (u.Pseudo.Equals("livreurTest"))
                    idLivreur = u.IdUtilisateurs;

                if (u.Pseudo.Equals("clientTest"))
                    idClient = u.IdUtilisateurs;
            }

            //Ajoute la commande avec les utilisateurs précédemment ajoutés
            CommandesCad commandesCad = new CommandesCad();
            CommandesComposite commande = new CommandesComposite { IdClients = idClient, IdLivreurs = idLivreur, Etat = "etatTest", Prix = 10.10 };
            commandesCad.AddCommandes(commande);

            //Act
            List<CommandesComposite> commandesList;
            commandesList = commandesCad.GetCommandes();

            foreach (CommandesComposite c in commandesList)
            {
                if (c.IdClients == idClient && c.IdLivreurs == idLivreur)
                    idCommande = c.IdCommandes;
            }

            commande.IdCommandes = idCommande;
            commande.Etat = "etatTestUpdate";

            commandesCad.UpdateCommandes(commande);
            CommandesComposite commandeTest = commandesCad.GetCommandes(idCommande);

            string etatUpdate = commandeTest.Etat;

            // Assert
            Assert.AreEqual(etatUpdate, "etatTestUpdate");

            //Suppression des éléments dans base
            commandesCad.DeleteCommandes(idCommande);
            utilisateursCad.DeleteUtilisateurs(idClient);
            utilisateursCad.DeleteUtilisateurs(idLivreur);
        }

        [TestMethod]
        public void DeleteCommandeTest()
        {
            // Arrange 
            //Ajoute deux utilisateurs dans la base et les ajoutent dans la base
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite livreur = new UtilisateursComposite { Pseudo = "livreurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };
            UtilisateursComposite client = new UtilisateursComposite { Pseudo = "clientTest", Password = "passwordTest", Adresse = "adresseTest", Type = "client" };

            utilisateursCad.AddUtilisateurs(livreur);
            utilisateursCad.AddUtilisateurs(client);

            int idClient = 0;
            int idLivreur = 0;
            int idCommande = 0;

            List<UtilisateursComposite> utilisateursList = utilisateursCad.GetUtilisateurs();

            foreach (UtilisateursComposite u in utilisateursList)
            {
                if (u.Pseudo.Equals("livreurTest"))
                    idLivreur = u.IdUtilisateurs;

                if (u.Pseudo.Equals("clientTest"))
                    idClient = u.IdUtilisateurs;
            }

            //Ajoute la commande avec les utilisateurs précédemment ajoutés
            CommandesCad commandesCad = new CommandesCad();
            CommandesComposite commande = new CommandesComposite { IdClients = idClient, IdLivreurs = idLivreur };
            commandesCad.AddCommandes(commande);

            //Act
            List<CommandesComposite> commandesList;
            commandesList = commandesCad.GetCommandes();

            foreach (CommandesComposite c in commandesList)
            {
                if (c.IdClients == idClient && c.IdLivreurs == idLivreur)
                    idCommande = c.IdCommandes;
            }

            commandesCad.DeleteCommandes(idCommande);

            commandesList = commandesCad.GetCommandes();

            bool supprime = commandesList.Contains(commande);

            // Assert
            Assert.IsTrue(!supprime);

            //Suppression des éléments dans base
            utilisateursCad.DeleteUtilisateurs(idClient);
            utilisateursCad.DeleteUtilisateurs(idLivreur);
        }
    }
}
