using System.Collections.Generic;
using System.Linq;
using LivraisonRepasServices.Composite;

namespace LivraisonRepasServices.CAD
{
    public class MenusCad
    {
        public List<MenusComposite> GetMenus()
        {
            List<MenusComposite> menusList = new List<MenusComposite>();

            List<Menu> menus;
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from m in bdd.Menu
                              select m;

                menus = requete.ToList();
            }

            if (menus.Count > 0)
            {
                foreach (Menu m in menus)
                {
                    MenusComposite composite = new MenusComposite();
                    composite.IdMenus = m.id;
                    composite.NomMenus = m.nom ?? "NULL";
                    if (m.prix != null) composite.Prix = (double) m.prix;
                    if (m.stock != null) composite.Stock = (int) m.stock;
                    if (m.idRestaurant != null) composite.IdRestaurant = (int) m.idRestaurant;
                    menusList.Add(composite);
                }
            }

            return menusList;
        }

        public MenusComposite GetMenus(int id)
        {
            MenusComposite compositeMenus = new MenusComposite();
            Menu menus;

            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from m in bdd.Menu
                              where m.id == id
                              select m;

                menus = requete.FirstOrDefault();
            }

            if (menus != null)
            {
                compositeMenus.IdMenus = menus.id;
                compositeMenus.NomMenus = menus.nom ?? "NULL";
                if (menus.prix != null) compositeMenus.Prix = (double) menus.prix;
                if (menus.stock != null) compositeMenus.Stock = (int) menus.stock;
                if (menus.idRestaurant != null) compositeMenus.IdRestaurant = (int) menus.idRestaurant;
            }
            else
            {
                compositeMenus.IdMenus = 0;
                compositeMenus.NomMenus = "NULL";
                compositeMenus.Prix = 0;
                compositeMenus.Stock = 0;
                compositeMenus.IdRestaurant = 0;
            }

            return compositeMenus;
        }

        public void AddMenus(MenusComposite mm)
        {
            Menu m = new Menu();

            m.id = mm.IdMenus;
            m.nom = mm.NomMenus;
            m.prix = mm.Prix;
            m.stock = mm.Stock;
            m.idRestaurant = mm.IdRestaurant;

            using (var bdd = new LivraisonRepasEntities())
            {
                bdd.Menu.Add(m);
                bdd.SaveChanges();
            }
        }

        public void DeleteMenus(int id)
        {
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from m in bdd.Menu
                              where m.id == id
                              select m;

                Menu menus = requete.FirstOrDefault();

                if (menus != null)
                {
                    bdd.Menu.Remove(menus);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateMenus(MenusComposite mm)
        {
            Menu m = new Menu();

            m.id = mm.IdMenus;
            m.nom = mm.NomMenus;
            m.prix = mm.Prix;
            m.stock = mm.Stock;
            m.idRestaurant = mm.IdRestaurant;

            using (var bdd = new LivraisonRepasEntities())
            {
                Menu menus = bdd.Menu.Find(m.id);

                if (menus != null)
                {
                    bdd.Entry(menus).CurrentValues.SetValues(m);
                    bdd.SaveChanges();
                }
            }
        }
    }
}
