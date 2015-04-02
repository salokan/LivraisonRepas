using System.Collections.Generic;
using System.Linq;
using LivraisonRepasServices.Composite;

namespace LivraisonRepasServices.CAD
{
    public class RestaurantsCad
    {
        public List<RestaurantsComposite> GetRestaurants()
        {
            List<RestaurantsComposite> restaurantsList = new List<RestaurantsComposite>();

            List<Restaurant> restaurants;
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from r in bdd.Restaurant
                              select r;

                restaurants = requete.ToList();
            }

            if (restaurants.Count > 0)
            {
                foreach (Restaurant r in restaurants)
                {
                    RestaurantsComposite composite = new RestaurantsComposite();
                    composite.IdRestaurants = r.id;
                    composite.NomRestaurants = r.nom ?? "NULL";
                    restaurantsList.Add(composite);
                }
            }

            return restaurantsList;
        }

        public RestaurantsComposite GetRestaurants(int id)
        {
            RestaurantsComposite compositeRestaurants = new RestaurantsComposite();
            Restaurant restaurants;

            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from r in bdd.Restaurant
                              where r.id == id
                              select r;

                restaurants = requete.FirstOrDefault();
            }

            if (restaurants != null)
            {
                compositeRestaurants.IdRestaurants = restaurants.id;
                compositeRestaurants.NomRestaurants = restaurants.nom ?? "NULL";
            }
            else
            {
                compositeRestaurants.IdRestaurants = 0;
                compositeRestaurants.NomRestaurants = "NULL";
            }

            return compositeRestaurants;
        }

        public void AddRestaurants(RestaurantsComposite rr)
        {
            Restaurant r = new Restaurant();

            r.id = rr.IdRestaurants;
            r.nom = rr.NomRestaurants;

            using (var bdd = new LivraisonRepasEntities())
            {
                bdd.Restaurant.Add(r);
                bdd.SaveChanges();
            }
        }

        public void DeleteRestaurants(int id)
        {
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from r in bdd.Restaurant
                              where r.id == id
                              select r;

                Restaurant restaurants = requete.FirstOrDefault();

                if (restaurants != null)
                {
                    bdd.Restaurant.Remove(restaurants);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateRestaurants(RestaurantsComposite rr)
        {
            Restaurant r = new Restaurant();

            r.id = rr.IdRestaurants;
            r.nom = rr.NomRestaurants;

            using (var bdd = new LivraisonRepasEntities())
            {
                Restaurant restaurants = bdd.Restaurant.Find(r.id);

                if (restaurants != null)
                {
                    bdd.Entry(restaurants).CurrentValues.SetValues(r);
                    bdd.SaveChanges();
                }
            }
        }
    }
}
