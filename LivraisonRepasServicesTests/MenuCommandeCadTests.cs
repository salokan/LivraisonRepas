using System.Collections.Generic;
using LivraisonRepasServices.CAD;
using LivraisonRepasServices.Composite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LivraisonRepasServicesTests
{
    [TestClass]
    public class MenuCommandeCadTests
    {
        [TestMethod]
        public void GetMenusCommandeTest()
        {
            // Arrange
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite livreur = new UtilisateursComposite { Pseudo = "livreurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };
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

            List<CommandesComposite> commandesList;
            commandesList = commandesCad.GetCommandes();

            foreach (CommandesComposite c in commandesList)
            {
                if (c.IdClients == idClient && c.IdLivreurs == idLivreur)
                    idCommande = c.IdCommandes;
            }

            RestaurantsCad restaurantsCad = new RestaurantsCad();
            RestaurantsComposite restaurant = new RestaurantsComposite { NomRestaurants = "restaurantTest" };
            int idRestaurant = 0;
            restaurantsCad.AddRestaurants(restaurant);

            List<RestaurantsComposite> restaurantsList = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r in restaurantsList)
            {
                if (r.NomRestaurants.Equals("restaurantTest"))
                    idRestaurant = r.IdRestaurants;
            }

            MenusCad menusCad = new MenusCad();
            MenusComposite menus = new MenusComposite { NomMenus = "menuTest", Prix = 10.10, Stock = 1, IdRestaurant = idRestaurant };
            int idMenu = 0;
            menusCad.AddMenus(menus);

            List<MenusComposite> menusList = menusCad.GetMenus();

            foreach (MenusComposite m in menusList)
            {
                if (m.NomMenus.Equals("menuTest"))
                    idMenu = m.IdMenus;
            }

            MenuCommandeCad menuCommandeCad = new MenuCommandeCad();
            MenuCommandeComposite menuCommande = new MenuCommandeComposite { IdCommande = idCommande, IdMenu = idMenu };
            int idMenuCommande = 0;
            menuCommandeCad.AddMenuCommande(menuCommande);

            // Act
            List<MenuCommandeComposite> menuCommandeList = menuCommandeCad.GetMenuCommande();

            foreach (MenuCommandeComposite mc in menuCommandeList)
            {
                if (mc.IdMenu == idMenu && mc.IdCommande == idCommande)
                    idMenuCommande = mc.IdMenuCommande;
            }

            // Assert
            Assert.IsNotNull(menuCommandeList);

            //Suppression des éléments dans base
            menuCommandeCad.DeleteMenuCommande(idMenuCommande);
            menusCad.DeleteMenus(idMenu); 
            commandesCad.DeleteCommandes(idCommande);
            restaurantsCad.DeleteRestaurants(idRestaurant);
            utilisateursCad.DeleteUtilisateurs(idClient);
            utilisateursCad.DeleteUtilisateurs(idLivreur);
        }

        [TestMethod]
        public void GetMenuCommandeByCommandeTest()
        {
            // Arrange
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite livreur = new UtilisateursComposite { Pseudo = "livreurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };
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

            List<CommandesComposite> commandesList;
            commandesList = commandesCad.GetCommandes();

            foreach (CommandesComposite c in commandesList)
            {
                if (c.IdClients == idClient && c.IdLivreurs == idLivreur)
                    idCommande = c.IdCommandes;
            }

            RestaurantsCad restaurantsCad = new RestaurantsCad();
            RestaurantsComposite restaurant = new RestaurantsComposite { NomRestaurants = "restaurantTest" };
            int idRestaurant = 0;
            restaurantsCad.AddRestaurants(restaurant);

            List<RestaurantsComposite> restaurantsList = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r in restaurantsList)
            {
                if (r.NomRestaurants.Equals("restaurantTest"))
                    idRestaurant = r.IdRestaurants;
            }

            MenusCad menusCad = new MenusCad();
            MenusComposite menus = new MenusComposite { NomMenus = "menuTest", Prix = 10.10, Stock = 1, IdRestaurant = idRestaurant };
            int idMenu = 0;
            menusCad.AddMenus(menus);

            List<MenusComposite> menusList = menusCad.GetMenus();

            foreach (MenusComposite m in menusList)
            {
                if (m.NomMenus.Equals("menuTest"))
                    idMenu = m.IdMenus;
            }

            MenuCommandeCad menuCommandeCad = new MenuCommandeCad();
            MenuCommandeComposite menuCommande = new MenuCommandeComposite { IdCommande = idCommande, IdMenu = idMenu };
            int idMenuCommande = 0;
            menuCommandeCad.AddMenuCommande(menuCommande);

            // Act
            List<MenuCommandeComposite> menuCommandeList = menuCommandeCad.GetMenuCommande();

            foreach (MenuCommandeComposite mc in menuCommandeList)
            {
                if (mc.IdMenu == idMenu && mc.IdCommande == idCommande)
                    idMenuCommande = mc.IdMenuCommande;
            }

            MenuCommandeComposite menuCommandeTest = menuCommandeCad.GetMenuCommande(idMenuCommande);

            // Assert
            Assert.IsNotNull(menuCommandeTest);

            //Suppression des éléments dans base
            menuCommandeCad.DeleteMenuCommande(idMenuCommande);
            menusCad.DeleteMenus(idMenu);
            commandesCad.DeleteCommandes(idCommande);
            restaurantsCad.DeleteRestaurants(idRestaurant);
            utilisateursCad.DeleteUtilisateurs(idClient);
            utilisateursCad.DeleteUtilisateurs(idLivreur);
        }

        [TestMethod]
        public void AddMenuCommandeTest()
        {
            // Arrange
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite livreur = new UtilisateursComposite { Pseudo = "livreurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };
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

            List<CommandesComposite> commandesList;
            commandesList = commandesCad.GetCommandes();

            foreach (CommandesComposite c in commandesList)
            {
                if (c.IdClients == idClient && c.IdLivreurs == idLivreur)
                    idCommande = c.IdCommandes;
            }

            RestaurantsCad restaurantsCad = new RestaurantsCad();
            RestaurantsComposite restaurant = new RestaurantsComposite { NomRestaurants = "restaurantTest" };
            int idRestaurant = 0;
            restaurantsCad.AddRestaurants(restaurant);

            List<RestaurantsComposite> restaurantsList = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r in restaurantsList)
            {
                if (r.NomRestaurants.Equals("restaurantTest"))
                    idRestaurant = r.IdRestaurants;
            }

            MenusCad menusCad = new MenusCad();
            MenusComposite menus = new MenusComposite { NomMenus = "menuTest", Prix = 10.10, Stock = 1, IdRestaurant = idRestaurant };
            int idMenu = 0;
            menusCad.AddMenus(menus);

            List<MenusComposite> menusList = menusCad.GetMenus();

            foreach (MenusComposite m in menusList)
            {
                if (m.NomMenus.Equals("menuTest"))
                    idMenu = m.IdMenus;
            }

            MenuCommandeCad menuCommandeCad = new MenuCommandeCad();
            MenuCommandeComposite menuCommande = new MenuCommandeComposite { IdCommande = idCommande, IdMenu = idMenu };
            int idMenuCommande = 0;
            menuCommandeCad.AddMenuCommande(menuCommande);

            // Act
            List<MenuCommandeComposite> menuCommandeList = menuCommandeCad.GetMenuCommande();

            foreach (MenuCommandeComposite mc in menuCommandeList)
            {
                if (mc.IdMenu == idMenu && mc.IdCommande == idCommande)
                    idMenuCommande = mc.IdMenuCommande;
            }

            MenuCommandeComposite menuCommandeTest = menuCommandeCad.GetMenuCommande(idMenuCommande);

            // Assert
            Assert.IsNotNull(menuCommandeTest);

            //Suppression des éléments dans base
            menuCommandeCad.DeleteMenuCommande(idMenuCommande);
            menusCad.DeleteMenus(idMenu);
            commandesCad.DeleteCommandes(idCommande);
            restaurantsCad.DeleteRestaurants(idRestaurant);
            utilisateursCad.DeleteUtilisateurs(idClient);
            utilisateursCad.DeleteUtilisateurs(idLivreur);
        }

        [TestMethod]
        public void AddMenuCommandeByCommandeTest()
        {
            // Arrange
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite livreur = new UtilisateursComposite { Pseudo = "livreurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };
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

            List<CommandesComposite> commandesList;
            commandesList = commandesCad.GetCommandes();

            foreach (CommandesComposite c in commandesList)
            {
                if (c.IdClients == idClient && c.IdLivreurs == idLivreur)
                    idCommande = c.IdCommandes;
            }

            RestaurantsCad restaurantsCad = new RestaurantsCad();
            RestaurantsComposite restaurant = new RestaurantsComposite { NomRestaurants = "restaurantTest" };
            int idRestaurant = 0;
            restaurantsCad.AddRestaurants(restaurant);

            List<RestaurantsComposite> restaurantsList = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r in restaurantsList)
            {
                if (r.NomRestaurants.Equals("restaurantTest"))
                    idRestaurant = r.IdRestaurants;
            }

            MenusCad menusCad = new MenusCad();
            MenusComposite menus = new MenusComposite { NomMenus = "menuTest", Prix = 10.10, Stock = 1, IdRestaurant = idRestaurant };
            int idMenu = 0;
            menusCad.AddMenus(menus);

            List<MenusComposite> menusList = menusCad.GetMenus();

            foreach (MenusComposite m in menusList)
            {
                if (m.NomMenus.Equals("menuTest"))
                    idMenu = m.IdMenus;
            }

            MenuCommandeCad menuCommandeCad = new MenuCommandeCad();
            MenuCommandeComposite menuCommande = new MenuCommandeComposite { IdCommande = idCommande, IdMenu = idMenu };
            int idMenuCommande = 0;
            menuCommandeCad.AddMenuCommande(menuCommande);

            // Act
            List<MenuCommandeComposite> menuCommandeList = menuCommandeCad.GetMenuCommandeByCommande(idCommande);

            foreach (MenuCommandeComposite mc in menuCommandeList)
            {
                if (mc.IdMenu == idMenu && mc.IdCommande == idCommande)
                    idMenuCommande = mc.IdMenuCommande;
            }

            // Assert
            Assert.IsNotNull(menuCommandeList);

            //Suppression des éléments dans base
            menuCommandeCad.DeleteMenuCommande(idMenuCommande);
            menusCad.DeleteMenus(idMenu);
            commandesCad.DeleteCommandes(idCommande);
            restaurantsCad.DeleteRestaurants(idRestaurant);
            utilisateursCad.DeleteUtilisateurs(idClient);
            utilisateursCad.DeleteUtilisateurs(idLivreur);
        }

        [TestMethod]
        public void UpdateMenuCommandeTest()
        {
            // Arrange
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite livreur = new UtilisateursComposite { Pseudo = "livreurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };
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

            List<CommandesComposite> commandesList;
            commandesList = commandesCad.GetCommandes();

            foreach (CommandesComposite c in commandesList)
            {
                if (c.IdClients == idClient && c.IdLivreurs == idLivreur)
                    idCommande = c.IdCommandes;
            }

            RestaurantsCad restaurantsCad = new RestaurantsCad();
            RestaurantsComposite restaurant = new RestaurantsComposite { NomRestaurants = "restaurantTest" };
            int idRestaurant = 0;
            restaurantsCad.AddRestaurants(restaurant);

            List<RestaurantsComposite> restaurantsList = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r in restaurantsList)
            {
                if (r.NomRestaurants.Equals("restaurantTest"))
                    idRestaurant = r.IdRestaurants;
            }

            MenusCad menusCad = new MenusCad();
            MenusComposite menus = new MenusComposite { NomMenus = "menuTest", Prix = 10.10, Stock = 1, IdRestaurant = idRestaurant };
            MenusComposite menus2 = new MenusComposite { NomMenus = "menuTest2", Prix = 10.10, Stock = 1, IdRestaurant = idRestaurant };
            int idMenu = 0;
            int idMenu2 = 0;
            menusCad.AddMenus(menus);
            menusCad.AddMenus(menus2);

            List<MenusComposite> menusList = menusCad.GetMenus();

            foreach (MenusComposite m in menusList)
            {
                if (m.NomMenus.Equals("menuTest"))
                    idMenu = m.IdMenus;

                if (m.NomMenus.Equals("menuTest2"))
                    idMenu2 = m.IdMenus;
            }

            MenuCommandeCad menuCommandeCad = new MenuCommandeCad();
            MenuCommandeComposite menuCommande = new MenuCommandeComposite { IdCommande = idCommande, IdMenu = idMenu };
            int idMenuCommande = 0;
            menuCommandeCad.AddMenuCommande(menuCommande);

            // Act
            List<MenuCommandeComposite> menuCommandeList = menuCommandeCad.GetMenuCommande();

            foreach (MenuCommandeComposite mc in menuCommandeList)
            {
                if (mc.IdMenu == idMenu && mc.IdCommande == idCommande)
                    idMenuCommande = mc.IdMenuCommande;
            }

            menuCommande.IdMenuCommande = idMenuCommande;
            menuCommande.IdMenu = idMenu2;

            menuCommandeCad.UpdateMenuCommande(menuCommande);

            MenuCommandeComposite menuCommandeUpdate = menuCommandeCad.GetMenuCommande(idMenuCommande);

            int idMenuUpdate = menuCommandeUpdate.IdMenu;

            // Assert
            Assert.AreEqual(idMenuUpdate, idMenu2);

            //Suppression des éléments dans base
            menuCommandeCad.DeleteMenuCommande(idMenuCommande);
            menusCad.DeleteMenus(idMenu);
            menusCad.DeleteMenus(idMenu2);
            commandesCad.DeleteCommandes(idCommande);
            restaurantsCad.DeleteRestaurants(idRestaurant);
            utilisateursCad.DeleteUtilisateurs(idClient);
            utilisateursCad.DeleteUtilisateurs(idLivreur);
        }



        [TestMethod]
        public void DeleteMenuCommandeTest()
        {
            // Arrange
            UtilisateursCad utilisateursCad = new UtilisateursCad();
            UtilisateursComposite livreur = new UtilisateursComposite { Pseudo = "livreurTest", Password = "passwordTest", Adresse = "adresseTest", Type = "livreur" };
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

            List<CommandesComposite> commandesList;
            commandesList = commandesCad.GetCommandes();

            foreach (CommandesComposite c in commandesList)
            {
                if (c.IdClients == idClient && c.IdLivreurs == idLivreur)
                    idCommande = c.IdCommandes;
            }

            RestaurantsCad restaurantsCad = new RestaurantsCad();
            RestaurantsComposite restaurant = new RestaurantsComposite { NomRestaurants = "restaurantTest" };
            int idRestaurant = 0;
            restaurantsCad.AddRestaurants(restaurant);

            List<RestaurantsComposite> restaurantsList = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r in restaurantsList)
            {
                if (r.NomRestaurants.Equals("restaurantTest"))
                    idRestaurant = r.IdRestaurants;
            }

            MenusCad menusCad = new MenusCad();
            MenusComposite menus = new MenusComposite { NomMenus = "menuTest", Prix = 10.10, Stock = 1, IdRestaurant = idRestaurant };
            int idMenu = 0;
            menusCad.AddMenus(menus);

            List<MenusComposite> menusList = menusCad.GetMenus();

            foreach (MenusComposite m in menusList)
            {
                if (m.NomMenus.Equals("menuTest"))
                    idMenu = m.IdMenus;
            }

            MenuCommandeCad menuCommandeCad = new MenuCommandeCad();
            MenuCommandeComposite menuCommande = new MenuCommandeComposite { IdCommande = idCommande, IdMenu = idMenu };
            int idMenuCommande = 0;
            menuCommandeCad.AddMenuCommande(menuCommande);

            // Act
            List<MenuCommandeComposite> menuCommandeList = menuCommandeCad.GetMenuCommande();

            foreach (MenuCommandeComposite mc in menuCommandeList)
            {
                if (mc.IdMenu == idMenu && mc.IdCommande == idCommande)
                    idMenuCommande = mc.IdMenuCommande;
            }

            menuCommandeCad.DeleteMenuCommande(idMenuCommande);

            bool supprime = menuCommandeList.Contains(menuCommande);
            // Assert
            Assert.IsTrue(!supprime);

            //Suppression des éléments dans base
            menusCad.DeleteMenus(idMenu);
            commandesCad.DeleteCommandes(idCommande);
            restaurantsCad.DeleteRestaurants(idRestaurant);
            utilisateursCad.DeleteUtilisateurs(idClient);
            utilisateursCad.DeleteUtilisateurs(idLivreur);
        }
    }
}
