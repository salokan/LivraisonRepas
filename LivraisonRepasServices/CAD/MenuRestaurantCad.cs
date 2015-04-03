using System.Collections.Generic;
using System.Linq;
using LivraisonRepasServices.Composite;

namespace LivraisonRepasServices.CAD
{
    public class MenuRestaurantCad
    {
        public List<MenuRestaurantComposite> GetMenuRestaurant()
        {
            List<MenuRestaurantComposite> menuRestaurantList = new List<MenuRestaurantComposite>();

            List<MenuRestaurant> menuRestaurant;
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from mr in bdd.MenuRestaurant
                              select mr;

                menuRestaurant = requete.ToList();
            }

            if (menuRestaurant.Count > 0)
            {
                foreach (MenuRestaurant mr in menuRestaurant)
                {
                    MenuRestaurantComposite composite = new MenuRestaurantComposite();
                    composite.IdMenuRestaurant = mr.id;
                    if (mr.idRestaurant != null) composite.IdRestaurant = (int) mr.idRestaurant;
                    if (mr.idMenu != null) composite.IdMenu = (int) mr.idMenu;
                    menuRestaurantList.Add(composite);
                }
            }

            return menuRestaurantList;
        }

        public MenuRestaurantComposite GetMenuRestaurant(int id)
        {
            MenuRestaurantComposite compositeMenuRestaurant = new MenuRestaurantComposite();
            MenuRestaurant menuRestaurant;

            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from mr in bdd.MenuRestaurant
                              where mr.id == id
                              select mr;

                menuRestaurant = requete.FirstOrDefault();
            }

            if (menuRestaurant != null)
            {
                compositeMenuRestaurant.IdMenuRestaurant = menuRestaurant.id;
                if (menuRestaurant.idRestaurant != null)
                    compositeMenuRestaurant.IdRestaurant = (int) menuRestaurant.idRestaurant;
                if (menuRestaurant.idMenu != null) compositeMenuRestaurant.IdMenu = (int) menuRestaurant.idMenu;
            }
            else
            {
                compositeMenuRestaurant.IdMenuRestaurant = 0;
                compositeMenuRestaurant.IdRestaurant = 0;
                compositeMenuRestaurant.IdMenu = 0;
            }

            return compositeMenuRestaurant;
        }

        public void AddMenuRestaurant(MenuRestaurantComposite mrmr)
        {
            MenuRestaurant mr = new MenuRestaurant();

            mr.id = mrmr.IdMenuRestaurant;
            mr.idRestaurant = mrmr.IdRestaurant;
            mr.idMenu = mrmr.IdMenu;

            using (var bdd = new LivraisonRepasEntities())
            {
                bdd.MenuRestaurant.Add(mr);
                bdd.SaveChanges();
            }
        }

        public void DeleteMenuRestaurant(int id)
        {
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from mr in bdd.MenuRestaurant
                              where mr.id == id
                              select mr;

                MenuRestaurant menuRestaurant = requete.FirstOrDefault();

                if (menuRestaurant != null)
                {
                    bdd.MenuRestaurant.Remove(menuRestaurant);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateMenuRestaurant(MenuRestaurantComposite mrmr)
        {
            MenuRestaurant mr = new MenuRestaurant();

            mr.id = mrmr.IdMenuRestaurant;
            mr.idRestaurant = mrmr.IdRestaurant;
            mr.idMenu = mrmr.IdMenu;

            using (var bdd = new LivraisonRepasEntities())
            {
                MenuRestaurant menuRestaurant = bdd.MenuRestaurant.Find(mr.id);

                if (menuRestaurant != null)
                {
                    bdd.Entry(menuRestaurant).CurrentValues.SetValues(mr);
                    bdd.SaveChanges();
                }
            }
        }
    }
}
