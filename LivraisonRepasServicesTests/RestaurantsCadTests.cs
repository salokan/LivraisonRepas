using System.Collections.Generic;
using LivraisonRepasServices.CAD;
using LivraisonRepasServices.Composite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LivraisonRepasServicesTests
{
    [TestClass]
    public class RestaurantsCadTests
    {
        [TestMethod]
        public void GetUtilisateursTest()
        {
            // Arrange 
            RestaurantsCad restaurantsCad = new RestaurantsCad();
            RestaurantsComposite restaurant = new RestaurantsComposite { NomRestaurants = "restaurantTest" };

            restaurantsCad.AddRestaurants(restaurant);

            //Act
            int idRestaurant = 0;

            List<RestaurantsComposite> restaurantsList = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r in restaurantsList)
            {
                if (r.NomRestaurants.Equals("restaurantTest"))
                    idRestaurant = r.IdRestaurants;
            }

            // Assert
            Assert.IsNotNull(restaurantsList);

            //Suppression des éléments dans base
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }

        [TestMethod]
        public void GetUtilisateurTest()
        {
            // Arrange 
            RestaurantsCad restaurantsCad = new RestaurantsCad();
            RestaurantsComposite restaurant = new RestaurantsComposite { NomRestaurants = "restaurantTest" };

            restaurantsCad.AddRestaurants(restaurant);

            //Act
            int idRestaurant = 0;

            List<RestaurantsComposite> restaurantsList = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r in restaurantsList)
            {
                if (r.NomRestaurants.Equals("restaurantTest"))
                    idRestaurant = r.IdRestaurants;
            }

            restaurant = restaurantsCad.GetRestaurants(idRestaurant);

            // Assert
            Assert.IsNotNull(restaurant);

            //Suppression des éléments dans base
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }

        [TestMethod]
        public void AddUtilisateurTest()
        {
            // Arrange 
            RestaurantsCad restaurantsCad = new RestaurantsCad();
            RestaurantsComposite restaurant = new RestaurantsComposite { NomRestaurants = "restaurantTest" };

            restaurantsCad.AddRestaurants(restaurant);

            //Act
            int idRestaurant = 0;

            List<RestaurantsComposite> restaurantsList = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r in restaurantsList)
            {
                if (r.NomRestaurants.Equals("restaurantTest"))
                    idRestaurant = r.IdRestaurants;
            }

            restaurant = restaurantsCad.GetRestaurants(idRestaurant);

            // Assert
            Assert.IsNotNull(restaurant);

            //Suppression des éléments dans base
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }

        [TestMethod]
        public void UpdateUtilisateurTest()
        {
            // Arrange 
            RestaurantsCad restaurantsCad = new RestaurantsCad();
            RestaurantsComposite restaurant = new RestaurantsComposite { NomRestaurants = "restaurantTest" };

            restaurantsCad.AddRestaurants(restaurant);

            //Act
            int idRestaurant = 0;

            List<RestaurantsComposite> restaurantsList = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r in restaurantsList)
            {
                if (r.NomRestaurants.Equals("restaurantTest"))
                    idRestaurant = r.IdRestaurants;
            }

            restaurant.IdRestaurants = idRestaurant;
            restaurant.NomRestaurants = "restaurantTestUpdate";

            restaurantsCad.UpdateRestaurants(restaurant);
            RestaurantsComposite restaurantsUpdate = restaurantsCad.GetRestaurants(idRestaurant);

            string nomUpdate = restaurantsUpdate.NomRestaurants;

            // Assert
            Assert.AreEqual(nomUpdate, "restaurantTestUpdate");

            //Suppression des éléments dans base
            restaurantsCad.DeleteRestaurants(idRestaurant);
        }

        [TestMethod]
        public void DeleteUtilisateurTest()
        {
            // Arrange 
            RestaurantsCad restaurantsCad = new RestaurantsCad();
            RestaurantsComposite restaurant = new RestaurantsComposite { NomRestaurants = "restaurantTest" };

            restaurantsCad.AddRestaurants(restaurant);

            //Act
            int idRestaurant = 0;

            List<RestaurantsComposite> restaurantsList = restaurantsCad.GetRestaurants();

            foreach (RestaurantsComposite r in restaurantsList)
            {
                if (r.NomRestaurants.Equals("restaurantTest"))
                    idRestaurant = r.IdRestaurants;
            }

            restaurantsCad.DeleteRestaurants(idRestaurant);
            restaurantsList = restaurantsCad.GetRestaurants();
            bool supprime = restaurantsList.Contains(restaurant);

            // Assert
            Assert.IsTrue(!supprime);
        }
    }
}
