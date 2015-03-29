using System.Collections.Generic;
using System.Linq;
using LivraisonRepasServices.Composite;

namespace LivraisonRepasServices.CAD
{
    public class CommandesCad
    {
        public List<CommandesComposite> GetCommandes()
        {
            List<CommandesComposite> commandesList = new List<CommandesComposite>();

            List<Commandes> commandes;
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from c in bdd.Commandes
                              select c;

                commandes = requete.ToList();
            }

            if (commandes.Count > 0)
            {
                foreach (Commandes c in commandes)
                {
                    CommandesComposite composite = new CommandesComposite();
                    composite.IdCommandes = c.Id;
                    composite.IdClients = c.Id_Client;
                    composite.IdLivreurs = c.Id_Livreur;
                    composite.Contenu = c.Contenu;
                    composite.Etat = c.Etat;
                    commandesList.Add(composite);
                }
            }

            return commandesList;
        }

        public CommandesComposite GetCommandes(int id)
        {
            CommandesComposite compositeCommandes = new CommandesComposite();
            Commandes commande;

            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from c in bdd.Commandes
                              where c.Id == id
                              select c;

                commande = requete.FirstOrDefault();
            }

            if (commande != null)
            {
                compositeCommandes.IdCommandes = commande.Id;
                compositeCommandes.IdClients = commande.Id_Client;
                compositeCommandes.IdLivreurs = commande.Id_Livreur;
                compositeCommandes.Contenu = commande.Contenu;
                compositeCommandes.Etat = commande.Etat;
            }

            return compositeCommandes;
        }

        public void AddCommandes(CommandesComposite cc)
        {
            Commandes c = new Commandes();

            c.Id = cc.IdCommandes;
            c.Id_Client = cc.IdClients;
            c.Id_Livreur = cc.IdLivreurs;
            c.Contenu = cc.Contenu;
            c.Etat = cc.Etat;

            using (var bdd = new LivraisonRepasEntities())
            {
                bdd.Commandes.Add(c);
                bdd.SaveChanges();
            }
        }

        public void DeleteCommandes(int id)
        {
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from c in bdd.Commandes
                              where c.Id == id
                              select c;

                Commandes commandes = requete.FirstOrDefault();

                if (commandes != null)
                {
                    bdd.Commandes.Remove(commandes);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateCommandes(CommandesComposite cc)
        {
            Commandes c = new Commandes();

            c.Id = cc.IdCommandes;
            c.Id_Client = cc.IdClients;
            c.Id_Livreur = cc.IdLivreurs;
            c.Contenu = cc.Contenu;
            c.Etat = cc.Etat;

            using (var bdd = new LivraisonRepasEntities())
            {
                Commandes commandes = bdd.Commandes.Find(c.Id);

                if (commandes != null)
                {
                    bdd.Entry(commandes).CurrentValues.SetValues(c);
                    bdd.SaveChanges();
                }
            }
        }
    }
}
