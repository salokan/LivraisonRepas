using System.Collections.Generic;
using System.Linq;
using LivraisonRepasService.Composite;

namespace LivraisonRepasService.CAD
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
                    composite.IdCommandesValue = c.Id;
                    composite.IdClientsValue = c.Id_Client;
                    composite.IdLivreursValue = c.Id_Livreur;
                    composite.ContenuValue = c.Contenu;
                    composite.EtatValue = c.Etat;
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
                compositeCommandes.IdCommandesValue = commande.Id;
                compositeCommandes.IdClientsValue = commande.Id_Client;
                compositeCommandes.IdLivreursValue = commande.Id_Livreur;
                compositeCommandes.ContenuValue = commande.Contenu;
                compositeCommandes.EtatValue = commande.Etat;
            }

            return compositeCommandes;
        }

        public void AddCommandes(Commandes c)
        {
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

        public void UpdateCommandes(Commandes c)
        {
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