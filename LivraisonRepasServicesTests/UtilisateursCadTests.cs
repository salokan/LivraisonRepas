using System.Collections.Generic;
using LivraisonRepasServices.CAD;
using LivraisonRepasServices.Composite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LivraisonRepasServicesTests
{
    [TestClass]
    public class UtilisateursCadTests
    {
        [TestMethod]
        public void GetUtilisateursTest()
        {
            // Arrange 
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite utilisateur = new UtilisateursComposite { Pseudo = "utilisateurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };

            utilisateursCad.AddUtilisateurs(utilisateur);

            //Act
            int idUtilisateur = 0;

            List<UtilisateursComposite> utilisateursList = utilisateursCad.GetUtilisateurs();

            foreach (UtilisateursComposite u in utilisateursList)
            {
                if (u.Pseudo.Equals("utilisateurTest"))
                    idUtilisateur = u.IdUtilisateurs;
            }

            // Assert
            Assert.IsNotNull(utilisateursList);

            //Suppression des éléments dans base
            utilisateursCad.DeleteUtilisateurs(idUtilisateur);
        }

        [TestMethod]
        public void GetUtilisateurTest()
        {
            // Arrange 
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite utilisateur = new UtilisateursComposite { Pseudo = "utilisateurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };

            utilisateursCad.AddUtilisateurs(utilisateur);

            //Act
            int idUtilisateur = 0;

            List<UtilisateursComposite> utilisateursList = utilisateursCad.GetUtilisateurs();

            foreach (UtilisateursComposite u in utilisateursList)
            {
                if (u.Pseudo.Equals("utilisateurTest"))
                    idUtilisateur = u.IdUtilisateurs;
            }

            utilisateur = utilisateursCad.GetUtilisateurs(idUtilisateur);

            // Assert
            Assert.IsNotNull(utilisateur);

            //Suppression des éléments dans base
            utilisateursCad.DeleteUtilisateurs(idUtilisateur);
        }

        [TestMethod]
        public void AddUtilisateurTest()
        {
            // Arrange 
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite utilisateur = new UtilisateursComposite { Pseudo = "utilisateurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };

            utilisateursCad.AddUtilisateurs(utilisateur);

            //Act
            int idUtilisateur = 0;

            List<UtilisateursComposite> utilisateursList = utilisateursCad.GetUtilisateurs();

            foreach (UtilisateursComposite u in utilisateursList)
            {
                if (u.Pseudo.Equals("utilisateurTest"))
                    idUtilisateur = u.IdUtilisateurs;
            }

            utilisateur = utilisateursCad.GetUtilisateurs(idUtilisateur);

            // Assert
            Assert.IsNotNull(utilisateur);

            //Suppression des éléments dans base
            utilisateursCad.DeleteUtilisateurs(idUtilisateur);
        }

        [TestMethod]
        public void UpdateUtilisateurTest()
        {
            // Arrange 
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite utilisateur = new UtilisateursComposite { Pseudo = "utilisateurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };

            utilisateursCad.AddUtilisateurs(utilisateur);

            //Act
            int idUtilisateur = 0;

            List<UtilisateursComposite> utilisateursList = utilisateursCad.GetUtilisateurs();

            foreach (UtilisateursComposite u in utilisateursList)
            {
                if (u.Pseudo.Equals("utilisateurTest"))
                    idUtilisateur = u.IdUtilisateurs;
            }

            utilisateur.IdUtilisateurs = idUtilisateur;
            utilisateur.Pseudo = "utilisateurTestUpdate";
            
            utilisateursCad.UpdateUtilisateurs(utilisateur);
            UtilisateursComposite utilisateurUpdate = utilisateursCad.GetUtilisateurs(idUtilisateur);

            string pseudoUpdate = utilisateurUpdate.Pseudo;

            // Assert
            Assert.AreEqual(pseudoUpdate, "utilisateurTestUpdate");

            //Suppression des éléments dans base
            utilisateursCad.DeleteUtilisateurs(idUtilisateur);
        }

        [TestMethod]
        public void DeleteUtilisateurTest()
        {
            // Arrange 
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite utilisateur = new UtilisateursComposite { Pseudo = "utilisateurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };

            utilisateursCad.AddUtilisateurs(utilisateur);

            //Act
            int idUtilisateur = 0;

            List<UtilisateursComposite> utilisateursList = utilisateursCad.GetUtilisateurs();

            foreach (UtilisateursComposite u in utilisateursList)
            {
                if (u.Pseudo.Equals("utilisateurTest"))
                    idUtilisateur = u.IdUtilisateurs;
            }

            utilisateursCad.DeleteUtilisateurs(idUtilisateur);
            utilisateursList = utilisateursCad.GetUtilisateurs();
            bool supprime = utilisateursList.Contains(utilisateur);

            // Assert
            Assert.IsTrue(!supprime);          
        }

        [TestMethod]
        public void AuthentificationUtilisateurTest()
        {
            // Arrange 
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite utilisateur = new UtilisateursComposite { Pseudo = "utilisateurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };

            utilisateursCad.AddUtilisateurs(utilisateur);

            //Act
            int idUtilisateur = 0;

            List<UtilisateursComposite> utilisateursList = utilisateursCad.GetUtilisateurs();

            foreach (UtilisateursComposite u in utilisateursList)
            {
                if (u.Pseudo.Equals("utilisateurTest"))
                    idUtilisateur = u.IdUtilisateurs;
            }

            utilisateur = utilisateursCad.AuthentificationUtilisateur("utilisateurTest", "passwordTest");

            // Assert
            Assert.IsNotNull(utilisateur);

            //Suppression des éléments dans base
            utilisateursCad.DeleteUtilisateurs(idUtilisateur);
        }

        [TestMethod]
        public void ExistePseudoTest()
        {
            // Arrange 
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite utilisateur = new UtilisateursComposite { Pseudo = "utilisateurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };

            utilisateursCad.AddUtilisateurs(utilisateur);

            //Act
            int idUtilisateur = 0;

            List<UtilisateursComposite> utilisateursList = utilisateursCad.GetUtilisateurs();

            foreach (UtilisateursComposite u in utilisateursList)
            {
                if (u.Pseudo.Equals("utilisateurTest"))
                    idUtilisateur = u.IdUtilisateurs;
            }

            bool existe = utilisateursCad.ExistePseudo("utilisateurTest");

            // Assert
            Assert.IsTrue(existe);

            //Suppression des éléments dans base
            utilisateursCad.DeleteUtilisateurs(idUtilisateur);
        }
    }
}
