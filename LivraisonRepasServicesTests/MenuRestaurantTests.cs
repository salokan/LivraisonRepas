using System.Collections.Generic;
using LivraisonRepasServices.CAD;
using LivraisonRepasServices.Composite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LivraisonRepasServicesTests
{
    [TestClass]
    public class MenuRestaurantTests
    {
        [TestMethod]
        public void GetMenusRestaurantTest()
        {
            // Arrange
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

            MenuRestaurantCad menuRestaurantCad = new MenuRestaurantCad();
            MenuRestaurantComposite menuRestaurant = new MenuRestaurantComposite { IdRestaurant = idRestaurant, IdMenu = idMenu };
            int idMenuRestaurant = 0;
            menuRestaurantCad.AddMenuRestaurant(menuRestaurant);

            // Act
            List<MenuRestaurantComposite> menuRestaurantList = menuRestaurantCad.GetMenuRestaurant();

            foreach (MenuRestaurantComposite mr in menuRestaurantList)
            {
                if (mr.IdMenu == idMenu && mr.IdRestaurant == idRestaurant)
                    idMenuRestaurant = mr.IdMenuRestaurant;
            }

            // Assert
            Assert.IsNotNull(menuRestaurantList);

            //Suppression des éléments dans base
            menuRestaurantCad.DeleteMenuRestaurant(idMenuRestaurant);
            menusCad.DeleteMenus(idMenu);
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }

        [TestMethod]
        public void GetMenuRestaurantTest()
        {
            // Arrange
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

            MenuRestaurantCad menuRestaurantCad = new MenuRestaurantCad();
            MenuRestaurantComposite menuRestaurant = new MenuRestaurantComposite { IdRestaurant = idRestaurant, IdMenu = idMenu };
            int idMenuRestaurant = 0;
            menuRestaurantCad.AddMenuRestaurant(menuRestaurant);

            // Act
            List<MenuRestaurantComposite> menuRestaurantList = menuRestaurantCad.GetMenuRestaurant();

            foreach (MenuRestaurantComposite mr in menuRestaurantList)
            {
                if (mr.IdMenu == idMenu && mr.IdRestaurant == idRestaurant)
                    idMenuRestaurant = mr.IdMenuRestaurant;
            }

            MenuRestaurantComposite menuRestaurantTest = menuRestaurantCad.GetMenuRestaurant(idMenuRestaurant);

            // Assert
            Assert.IsNotNull(menuRestaurantTest);

            //Suppression des éléments dans base
            menuRestaurantCad.DeleteMenuRestaurant(idMenuRestaurant);
            menusCad.DeleteMenus(idMenu);
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }

        [TestMethod]
        public void AddMenuRestaurantTest()
        {
            // Arrange
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

            MenuRestaurantCad menuRestaurantCad = new MenuRestaurantCad();
            MenuRestaurantComposite menuRestaurant = new MenuRestaurantComposite { IdRestaurant = idRestaurant, IdMenu = idMenu };
            int idMenuRestaurant = 0;
            menuRestaurantCad.AddMenuRestaurant(menuRestaurant);

            // Act
            List<MenuRestaurantComposite> menuRestaurantList = menuRestaurantCad.GetMenuRestaurant();

            foreach (MenuRestaurantComposite mr in menuRestaurantList)
            {
                if (mr.IdMenu == idMenu && mr.IdRestaurant == idRestaurant)
                    idMenuRestaurant = mr.IdMenuRestaurant;
            }

            MenuRestaurantComposite menuRestaurantTest = menuRestaurantCad.GetMenuRestaurant(idMenuRestaurant);

            // Assert
            Assert.IsNotNull(menuRestaurantTest);

            //Suppression des éléments dans base
            menuRestaurantCad.DeleteMenuRestaurant(idMenuRestaurant);
            menusCad.DeleteMenus(idMenu);
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }

        [TestMethod]
        public void UpdateMenuRestaurantTest()
        {
            // Arrange
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

            RestaurantsComposite restaurant2 = new RestaurantsComposite { NomRestaurants = "restaurantTest2" };
            int idRestaurant2 = 0;
            restaurantsCad.AddRestaurants(restaurant2);

            List<RestaurantsComposite> restaurantsList2 = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r2 in restaurantsList2)
            {
                if (r2.NomRestaurants.Equals("restaurantTest2"))
                    idRestaurant2 = r2.IdRestaurants;
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

            MenuRestaurantCad menuRestaurantCad = new MenuRestaurantCad();
            MenuRestaurantComposite menuRestaurant = new MenuRestaurantComposite { IdRestaurant = idRestaurant, IdMenu = idMenu };
            int idMenuRestaurant = 0;
            menuRestaurantCad.AddMenuRestaurant(menuRestaurant);

            // Act
            List<MenuRestaurantComposite> menuRestaurantList = menuRestaurantCad.GetMenuRestaurant();

            foreach (MenuRestaurantComposite mr in menuRestaurantList)
            {
                if (mr.IdMenu == idMenu && mr.IdRestaurant == idRestaurant)
                    idMenuRestaurant = mr.IdMenuRestaurant;
            }

            menuRestaurant.IdMenuRestaurant = idMenuRestaurant;
            menuRestaurant.IdRestaurant = idRestaurant2;

            menuRestaurantCad.UpdateMenuRestaurant(menuRestaurant);

            MenuRestaurantComposite menuRestaurantUpdate = menuRestaurantCad.GetMenuRestaurant(idMenuRestaurant);

            int idRestaurantUpdate = menuRestaurantUpdate.IdRestaurant;

            // Assert
            Assert.AreEqual(idRestaurant2,idRestaurantUpdate);

            //Suppression des éléments dans base
            menuRestaurantCad.DeleteMenuRestaurant(idMenuRestaurant);
            menusCad.DeleteMenus(idMenu);
            restaurantsCad.DeleteRestaurants(idRestaurant);
            restaurantsCad.DeleteRestaurants(idRestaurant2);
        }

        [TestMethod]
        public void DeleteMenuRestaurantTest()
        {
            // Arrange
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

            MenuRestaurantCad menuRestaurantCad = new MenuRestaurantCad();
            MenuRestaurantComposite menuRestaurant = new MenuRestaurantComposite { IdRestaurant = idRestaurant, IdMenu = idMenu };
            int idMenuRestaurant = 0;
            menuRestaurantCad.AddMenuRestaurant(menuRestaurant);

            // Act
            List<MenuRestaurantComposite> menuRestaurantList = menuRestaurantCad.GetMenuRestaurant();

            foreach (MenuRestaurantComposite mr in menuRestaurantList)
            {
                if (mr.IdMenu == idMenu && mr.IdRestaurant == idRestaurant)
                    idMenuRestaurant = mr.IdMenuRestaurant;
            }

            menuRestaurantCad.DeleteMenuRestaurant(idMenuRestaurant);

            menuRestaurantList = menuRestaurantCad.GetMenuRestaurant();

            bool supprime = menuRestaurantList.Contains(menuRestaurant);
            // Assert
            Assert.IsTrue(!supprime);

            //Suppression des éléments dans base
            menusCad.DeleteMenus(idMenu);
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }
    }
}
