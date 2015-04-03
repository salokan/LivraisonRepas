using System.Collections.Generic;
using LivraisonRepasServices.CAD;
using LivraisonRepasServices.Composite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LivraisonRepasServicesTests
{
    [TestClass]
    public class MenusCadTests
    {
        [TestMethod]
        public void GetMenusTest()
        {
            // Arrange
            RestaurantsCad restaurantsCad = new RestaurantsCad();
            RestaurantsComposite restaurant = new RestaurantsComposite {NomRestaurants = "restaurantTest"};
            int idRestaurant = 0;
            restaurantsCad.AddRestaurants(restaurant);

            List<RestaurantsComposite> restaurantsList = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r in restaurantsList)
            {
                if (r.NomRestaurants.Equals("restaurantTest"))
                    idRestaurant = r.IdRestaurants;
            }

            MenusCad menusCad = new MenusCad();
            MenusComposite menus = new MenusComposite{NomMenus = "menuTest", Prix = 10.10, Stock = 1, IdRestaurant = idRestaurant};
            int idMenu = 0;
            menusCad.AddMenus(menus);

            // Act
            List<MenusComposite> menusList = menusCad.GetMenus();

            foreach (MenusComposite m in menusList)
            {
                if (m.NomMenus.Equals("menuTest"))
                    idMenu = m.IdMenus;
            }

            // Assert
            Assert.IsNotNull(menusList);

            //Suppression des éléments dans base
            menusCad.DeleteMenus(idMenu);
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }

        [TestMethod]
        public void GetMenuTest()
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

            // Act
            List<MenusComposite> menusList = menusCad.GetMenus();

            foreach (MenusComposite m in menusList)
            {
                if (m.NomMenus.Equals("menuTest"))
                    idMenu = m.IdMenus;
            }

            MenusComposite menuTest = menusCad.GetMenus(idMenu);

            // Assert
            Assert.IsNotNull(menuTest);

            //Suppression des éléments dans base
            menusCad.DeleteMenus(idMenu);
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }

        [TestMethod]
        public void AddMenuTest()
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

            // Act
            List<MenusComposite> menusList = menusCad.GetMenus();

            foreach (MenusComposite m in menusList)
            {
                if (m.NomMenus.Equals("menuTest"))
                    idMenu = m.IdMenus;
            }

            MenusComposite menuTest = menusCad.GetMenus(idMenu);

            // Assert
            Assert.IsNotNull(menuTest);

            //Suppression des éléments dans base
            menusCad.DeleteMenus(idMenu);
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }

        [TestMethod]
        public void UpdateMenuTest()
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

            // Act
            List<MenusComposite> menusList = menusCad.GetMenus();

            foreach (MenusComposite m in menusList)
            {
                if (m.NomMenus.Equals("menuTest"))
                    idMenu = m.IdMenus;
            }

            menus.IdMenus = idMenu;
            menus.NomMenus = "menuTestUpdate";

            menusCad.UpdateMenus(menus);
            MenusComposite menuTest = menusCad.GetMenus(idMenu);

            string nomUpdate = menuTest.NomMenus;

            // Assert
            Assert.AreEqual(nomUpdate, "menuTestUpdate");

            //Suppression des éléments dans base
            menusCad.DeleteMenus(idMenu);
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }

        [TestMethod]
        public void DeleteMenuTest()
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

            // Act
            List<MenusComposite> menusList = menusCad.GetMenus();

            foreach (MenusComposite m in menusList)
            {
                if (m.NomMenus.Equals("menuTest"))
                    idMenu = m.IdMenus;
            }

            menusCad.DeleteMenus(idMenu);

            menusList = menusCad.GetMenus();

            bool supprime = menusList.Contains(menus);

            // Assert
            Assert.IsTrue(!supprime);

            //Suppression des éléments dans base
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }
    }
}
