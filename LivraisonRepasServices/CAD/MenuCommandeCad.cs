using System.Collections.Generic;
using System.Linq;
using LivraisonRepasServices.Composite;

namespace LivraisonRepasServices.CAD
{
    public class MenuCommandeCad
    {
        public List<MenuCommandeComposite> GetMenuCommande()
        {
            List<MenuCommandeComposite> menuCommandeList = new List<MenuCommandeComposite>();

            List<MenuCommande> menuCommande;
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from mc in bdd.MenuCommande
                              select mc;

                menuCommande = requete.ToList();
            }

            if (menuCommande.Count > 0)
            {
                foreach (MenuCommande mc in menuCommande)
                {
                    MenuCommandeComposite composite = new MenuCommandeComposite();
                    composite.IdCommande = mc.Id;
                    if (mc.IdCommande != null) composite.IdCommande = (int)mc.IdCommande;
                    if (mc.IdMenu != null) composite.IdMenu = (int)mc.IdMenu;
                    menuCommandeList.Add(composite);
                }
            }

            return menuCommandeList;
        }

        public List<MenuCommandeComposite> GetMenuCommandeByCommande(int idCommande)
        {
            List<MenuCommandeComposite> menuCommandeList = new List<MenuCommandeComposite>();

            List<MenuCommande> menuCommande;
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from mc in bdd.MenuCommande
                              where mc.IdCommande == idCommande
                              select mc;

                menuCommande = requete.ToList();
            }

            if (menuCommande.Count > 0)
            {
                foreach (MenuCommande mc in menuCommande)
                {
                    MenuCommandeComposite composite = new MenuCommandeComposite();
                    composite.IdCommande = mc.Id;
                    if (mc.IdCommande != null) composite.IdCommande = (int)mc.IdCommande;
                    if (mc.IdMenu != null) composite.IdMenu = (int)mc.IdMenu;
                    menuCommandeList.Add(composite);
                }
            }

            return menuCommandeList;
        }

        public MenuCommandeComposite GetMenuCommande(int id)
        {
            MenuCommandeComposite compositeMenuCommande = new MenuCommandeComposite();
            MenuCommande menuCommande;

            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from mc in bdd.MenuCommande
                              where mc.Id == id
                              select mc;

                menuCommande = requete.FirstOrDefault();
            }

            if (menuCommande != null)
            {
                compositeMenuCommande.IdMenuCommande = menuCommande.Id;
                if (menuCommande.IdCommande != null)
                    compositeMenuCommande.IdCommande = (int)menuCommande.IdCommande;
                if (menuCommande.IdMenu != null) compositeMenuCommande.IdMenu = (int)menuCommande.IdMenu;
            }
            else
            {
                compositeMenuCommande.IdMenuCommande = 0;
                compositeMenuCommande.IdCommande = 0;
                compositeMenuCommande.IdMenu = 0;
            }

            return compositeMenuCommande;
        }

        public void AddMenuCommande(MenuCommandeComposite mcmc)
        {
            MenuCommande mc = new MenuCommande();

            mc.Id = mcmc.IdMenuCommande;
            mc.IdCommande = mcmc.IdCommande;
            mc.IdMenu = mcmc.IdMenu;

            using (var bdd = new LivraisonRepasEntities())
            {
                bdd.MenuCommande.Add(mc);
                bdd.SaveChanges();
            }
        }

        public void DeleteMenuCommande(int id)
        {
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from mc in bdd.MenuCommande
                              where mc.Id == id
                              select mc;

                MenuCommande menuCommande = requete.FirstOrDefault();

                if (menuCommande != null)
                {
                    bdd.MenuCommande.Remove(menuCommande);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateMenuCommande(MenuCommandeComposite mcmc)
        {
            MenuCommande mc = new MenuCommande();

            mc.Id = mcmc.IdMenuCommande;
            mc.IdCommande = mcmc.IdCommande;
            mc.IdMenu = mcmc.IdMenu;

            using (var bdd = new LivraisonRepasEntities())
            {
                MenuCommande menuCommande = bdd.MenuCommande.Find(mc.Id);

                if (menuCommande != null)
                {
                    bdd.Entry(menuCommande).CurrentValues.SetValues(mc);
                    bdd.SaveChanges();
                }
            }
        }
    }
}
